using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace mipBackend.Data.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJwtGenerador _jwtGenerador;
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private IMapper _mapper;

        public UsuarioRepository(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IJwtGenerador jwtGenerador,
            AppDbContext contexto,
            IUsuarioSesion usuarioSesion,
            IMapper mapper
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerador = jwtGenerador;
            _contexto = contexto;
            _usuarioSesion = usuarioSesion;
            _mapper = mapper;

        }

        private UserAuthReponseDto TransformerUserToUserDto(Usuario usuario) {

            return new UserAuthReponseDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario)
            };

        
        }

        public async Task<UserAuthReponseDto> GetUsuario()
        {

            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join urol in db.UserRoles! on usr.Id equals urol.UserId
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   where (niv.wkf03activo == 1 && wf.wkf01activo == 1 && tip.wkf02activo == 1)
                                   orderby wf.wkf01llavepadre, wf.wkf01orden,
                                   wf.wkf01prioridad

                                   select new WorkflowResponseDto
                                   {
                                       wkf01llave = wf.wkf01llave,
                                       wkf01nombre = wf.wkf01nombre,
                                       wkf01descripcion = wf.wkf01descripcion,
                                       wkf01llavepadre = wf.wkf01llavepadre,
                                       wkf02llave = tip.wkf02llave,
                                       wkf02nombre = tip.wkf02nombre,
                                       wkf03llave = niv.wkf03llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf01esinicio = wf.wkf01esinicio,
                                       wkf01orden = wf.wkf01orden,
                                       wkf01prioridad = wf.wkf01prioridad,
                                       wkf01activo = wf.wkf01activo,
                                       wkf01directorio = wf.wkf01nombre,
                                       wkf01url = wf.wkf01nombre,
                                       wkf01iconourl = wf.wkf01nombre,
                                       wkf01visiblemenu = wf.wkf01llave,
                                       wkf01imagengrande = wf.wkf01nombre,
                                       wkf01imagenpequena = wf.wkf01nombre,
                                       wkf01estadoregistro = wf.wkf01nombre,

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<WorkflowResponseDto>>(query!);

            }

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
            if(usuario == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "EL usuario del token noexiste en la base de datos" }
                );
            }

            return TransformerUserToUserDto(usuario!);

        }

        public async Task<UserAuthReponseDto> Login(UsuarioLoginRequestDto request)
        {

            var usuario = await _userManager.FindByEmailAsync(request.Email);

            if (usuario == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "EL email del usario no existe en la base de datos" }
                );
            }

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario!, request.Password!, false);

            if (resultado.Succeeded)
            {

                return TransformerUserToUserDto(usuario!);

            }

            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = "Las credenciales son incorrectas" }
               );

        }

        public async Task<IEnumerable<UsuarioRegistroResponseDto>> RegistroUsuario(UsuarioRegistroRequestDto request)
        {

            
            var existeEmail = await _contexto.Users.Where(x => x.Email == request.UserName).AnyAsync();

            if (existeEmail)
            {
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El email del usario ya existe en la base de datos" }
                );
            }

            var createdby = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (createdby is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            
            var existeUserName = await _contexto.Users.Where(x => x.UserName == request.UserName).AnyAsync();

            if (existeUserName)
            {
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El UserName del usario ya existe en la base de datos" }
                );
            }

            var usuario = new Usuario
            {
                Email = request.UserName,
                UserName = request.UserName,
            };


            var resultado = await _userManager.CreateAsync(usuario!, request.Password!);

            if (resultado.Succeeded)
            {

                

                string sql = "EXEC pa_mipnet_usuarioDefault_i @NAME, @USERNAME, @PASSWORD, @USUARIO_ID ";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@NAME", Value = request.Name },
                    new SqlParameter { ParameterName = "@USERNAME", Value = request.UserName },
                    new SqlParameter { ParameterName = "@PASSWORD", Value = request.Password },
                    new SqlParameter { ParameterName = "@USUARIO_ID", Value = Guid.Parse(createdby.Id)}

                };

                var result = await _contexto.UsuarioRegistros!.FromSqlRaw<UsuarioRegistroResponseDto>(sql, parms.ToArray())
                    .IgnoreQueryFilters()
                    .ToListAsync();

                return _mapper.Map<IEnumerable<UsuarioRegistroResponseDto>>(result);

            }

           
            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = resultado.Errors }
               );

        }

        public async Task<IEnumerable<UsuarioResponseDto>> GetAllUsuarios()
        {
            using (var db = _contexto)
            {
                var query = await (from usr in db.Users
                                   select new UsuarioResponseDto
                                   {
                                       Id = usr.Id,
                                       UserName = usr.UserName,
                                       Email = usr.Email
                                     
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<UsuarioResponseDto>>(query);

            }
        }


    }
}
