using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJwtGenerador _jwtGenerador;
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;

        public UsuarioRepository(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IJwtGenerador jwtGenerador,
            AppDbContext contexto,
            IUsuarioSesion usuarioSesion
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerador = jwtGenerador;
            _contexto = contexto;
            _usuarioSesion = usuarioSesion;

        }

        private UsuarioReponseDto TransformerUserToUserDto(Usuario usuario) {

            return new UsuarioReponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.apellido,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario)
            };

        
        }

        public async Task<UsuarioReponseDto> GetUsuario()
        {
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

        public async Task<UsuarioReponseDto> Login(UsuarioLoginRequestDto request)
        {

            var usuario = await _userManager.FindByEmailAsync(request.LoginName);

            if (usuario == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "EL email del usario no existe en la base de datos" }
                );
            }

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario!, request.LoginPassword!, false);

            if (resultado.Succeeded)
            {

                return TransformerUserToUserDto(usuario!);

            }

            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = "Las credenciales son incorrectas" }
               );

        }

        public async Task<UsuarioReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request)
        {
            var existeEmail = await _contexto.Users.Where(x => x.Email == request.Email).AnyAsync();

            if (existeEmail)
            {
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El email del usario ya existe en la base de datos" }
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
                Nombre = request.Nombre,
                apellido = request.Apellido,
                Telefono = request.Telefono,
                Email = request.Email,
                UserName = request.UserName,
            };

            var resultado = await _userManager.CreateAsync(usuario!, request.Password!);

            if (resultado.Succeeded)
            {

                return TransformerUserToUserDto(usuario);

            }

            throw new Exception("EL email del usario no existe en la base de datos");

        }
    }
}
