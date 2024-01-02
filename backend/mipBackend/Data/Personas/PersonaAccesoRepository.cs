using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Dtos.UsuarioDtos;

using KendoNET.DynamicLinq;
using Microsoft.AspNetCore.WebUtilities;
using mipBackend.Services.EmailService;

using Microsoft.Data.SqlClient;
using mipBackend.Services.EmailService;
using mipBackend.Dtos.EmailDtos;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;



namespace mipBackend.Data.Personas
{
    public class PersonaAccesoRepository : IPersonaAccesoRepository
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJwtGenerador _jwtGenerador;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;

        private IMapper _mapper;

        public PersonaAccesoRepository(
            AppDbContext contexto,
            IUsuarioSesion usuarioSesion,
            UserManager<Usuario> userManager,
            IMapper mapper,
            SignInManager<Usuario> signInManager,
            IJwtGenerador jwtGenerador,
            IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerador = jwtGenerador;
            _contexto = contexto;
            _usuarioSesion = usuarioSesion;
            _mapper = mapper;
            _emailService = emailService;

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task<PersonaAccesoResponseDto> GetPersonaAccesoById(int id)
        {
            using (var db = _contexto)
            {
                PersonaAccesoResponseDto? query = await (from per in db.per01personas
                                   join peusu in db.per07personaUsuarios! on per.per01llave equals peusu.per01llave
                                   join usr in db.Users! on peusu.userid equals usr.Id
                                   where per.per01llave == (id)
                                   select new PersonaAccesoResponseDto
                                   {

                                       per01llave = per.per01llave,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per07activo = peusu.per07activo,
                                       per07llave = peusu.per07llave,
                                       userid = usr.Id,
                                       username = usr.UserName


                                   }).FirstAsync();

                return query;

            }

        }

        public async Task<int> RegistroPersonaAcceso(PersonaAccesoRequestDto request)
        {

            var existeEmail = await _contexto.Users.Where(x => x.Email == request.username).AnyAsync();

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


            var existeUserName = await _contexto.Users.Where(x => x.UserName == request.username).AnyAsync();

            if (existeUserName)
            {
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El UserName del usario ya existe en la base de datos" }
                );
            }

            var usuario = new Usuario
            {
                Email = request.username,
                UserName = request.username,
            };


            var resultado = await _userManager.CreateAsync(usuario!, request.password!);

            if (resultado.Succeeded)
            {


                var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                var param = new Dictionary<string, string?>
                {
                    {"token", token },
                    {"email", usuario.Email }
                };

                var callback = QueryHelpers.AddQueryString("http://localhost:5201/mailconfirmation", param);

                var message = new Message(new string[] { "s.gonzalez@atomos.cl" }, "Email Confirmation token", callback, null);
                /* await _emailSender.SendEmailAsync(message); */

                _emailService.SendEmail(message);

                int rowsAffected;

                string sql = "EXEC pa_mipnet_personaacceso_i @PER01_LLAVE, @USERNAME, @PASSWORD, @USUARIO_ID ";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@PER01_LLAVE", Value = request.per01llave },
                    new SqlParameter { ParameterName = "@USERNAME", Value = request.username },
                    new SqlParameter { ParameterName = "@PASSWORD", Value = request.password },
                    new SqlParameter { ParameterName = "@USUARIO_ID", Value = createdby.Id}

                };

                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());

                return rowsAffected;
               
            }

            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = resultado.Errors }
               );

        }

    }
}
