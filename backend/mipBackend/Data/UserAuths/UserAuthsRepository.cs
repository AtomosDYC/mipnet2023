using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using mipBackend.Services.EmailService;
using mipBackend.Dtos.EmailDtos;
using MimeKit;

namespace mipBackend.Data.UserAuths
{
    public class UserAuthsRepository : IUserAuthsRepository
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJwtGenerador _jwtGenerador;
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserAuthsRepository(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IJwtGenerador jwtGenerador,
            AppDbContext contexto,
            IUsuarioSesion usuarioSesion,
            IMapper mapper,
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

        private UserAuthReponseDto TransformerUserToUserDto(Usuario usuario)
        {

            return new UserAuthReponseDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario)
            };


        }

        public async Task<UsuarioLoginResponseDto> GetUsuario()
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
            var Token = _jwtGenerador.CrearToken(usuario);

            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   where (usr.Id == usuario.Id)

                                   select new UsuarioLoginResponseDto
                                   {
                                       Id = usr.Id,
                                       Token = Token,
                                       UserName = usr.UserName,
                                       Email = usr.Email,
                                       roleid = "baaf5b71-10a3-4bd2-9c2f-9cdbf061fc9c",
                                       rolename = "Administrador",
                                       per01llave = 0,
                                       per01nombre = usr.UserName,
                                       prf03llave = 1,
                                       prf03nombre = "Administrador Full"

                                   }).FirstAsync();

                return _mapper.Map<UsuarioLoginResponseDto>(query!);

            }

            /*
            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join urol in db.UserRoles! on usr.Id equals urol.UserId
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   join prsr in db.per07personaUsuarios! on usr.Id equals prsr.userid
                                   join per in db.per01personas! on prsr.per01llave equals per.per01llave
                                   join prf in db.prf01perfiles! on usr.Id equals prf.userid
                                   join prf3 in db.prf03Plantillas! on prf.prf03llave equals prf3.prf03llave


                                   where (prsr.per07activo == 1 && per.per01activo == 1 && prf.prf01activo == 1)
                                   where (usr.Id == usuario.Id)
                                   orderby rol.Name, usr.UserName

                                   select new UsuarioLoginResponseDto
                                   {
                                       Id = usr.Id,
                                       Token = Token,
                                       UserName = usr.UserName,
                                       Email = usr.Email,
                                       roleid = rol.Id,
                                       rolename = rol.Name,
                                       per01llave = per.per01llave,
                                       per01nombre = per.per01nombrerazon,
                                       prf03llave = prf3.prf03llave,
                                       prf03nombre = prf3.prf03nombre

                                   }).FirstAsync();

                return _mapper.Map<UsuarioLoginResponseDto>(query!);

            }
            */

        }

        public async Task<UsuarioLoginResponseDto> Login(UsuarioLoginRequestDto request)
        {

            var usuario = await _userManager.FindByNameAsync(request.Email);

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

                var UsuarioRepsonse = await GetAllUsuariosById(usuario);


                return _mapper.Map<UsuarioLoginResponseDto>(UsuarioRepsonse!); 

            }

            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = "Las credenciales son incorrectas" }
               );

        }

        public async Task<UserAuthReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request)
        {
            var existeEmail = await _contexto.Users.Where(x => x.Email == request.UserName).AnyAsync();

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
                UserName = request.UserName,
            };

            var resultado = await _userManager.CreateAsync(usuario!, request.Password!);

            if (resultado.Succeeded)
            {

                return TransformerUserToUserDto(usuario);

            }

            throw new Exception("EL email del usario no existe en la base de datos");

        }

        public async Task<UsuarioLoginResponseDto> GetAllUsuariosById
            (
                Usuario usuario
            )
        {

            var Token = _jwtGenerador.CrearToken(usuario);

            /*
            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join urol in db.UserRoles! on usr.Id equals urol.UserId
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   join prsr in db.per07personaUsuarios! on usr.Id equals prsr.userid
                                   join per in db.per01personas! on prsr.per01llave equals per.per01llave
                                   join prf in db.prf01perfiles! on usr.Id equals prf.userid
                                   join prf3 in db.prf03Plantillas! on prf.prf03llave equals prf3.prf03llave


                                   where (prsr.per07activo == 1 && per.per01activo == 1 && prf.prf01activo == 1)
                                   where ( usr.Id == usuario.Id)
                                   orderby rol.Name, usr.UserName

                                   select new UsuarioLoginResponseDto
                                   {
                                       Id = usr.Id,
                                       Token = Token,
                                       UserName = usr.UserName,
                                       Email = usr.Email,
                                       roleid = rol.Id,
                                       rolename = rol.Name,
                                       per01llave = per.per01llave,
                                       per01nombre = per.per01nombrerazon,
                                       prf03llave = prf3.prf03llave,
                                       prf03nombre = prf3.prf03nombre

                                   }).FirstAsync();

                return _mapper.Map<UsuarioLoginResponseDto>(query!);

            }

            */
            
            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   where (usr.Id == usuario.Id)
                                   
                                   select new UsuarioLoginResponseDto
                                   {
                                       Id = usr.Id,
                                       Token = Token,
                                       UserName = usr.UserName,
                                       Email = usr.Email,
                                       roleid = "baaf5b71-10a3-4bd2-9c2f-9cdbf061fc9c",
                                       rolename = "Administrador",
                                       per01llave = 0,
                                       per01nombre = usr.UserName,
                                       prf03llave = 1,
                                       prf03nombre = "Administrador Full"

                                   }).FirstAsync();

                return _mapper.Map<UsuarioLoginResponseDto>(query!);

            }

        }

        public async Task ForgotPassword(ForgotPasswordResponseDto request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El E-mail no se encuentra registrado" }
                );

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string?>
            {
                {"token", token },
                {"email", request.Email }
            };

            var callback = QueryHelpers.AddQueryString(request.ClientURI!, param);

            var content = string.Format("<table style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr style=\"vertical-align: top\"><td style=\"word-break: break-word;border-collapse: collapse;vertical-align: top\"><!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #f9f9f9;\"><![endif]--><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:0px 10px 31px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"color: #34495e; line-height: 140%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 28px; line-height: 39.2px;\"><strong><span style=\"line-height: 39.2px; font-size: 28px;\">" +
                "¿OLVIDASTE TU CONTRASEÑA?" +
                "</span></strong></span></p></div></td></tr></tbody></table></div></div></div></div></div><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;background-color: #ffffff;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 160%;\"> <span style=\"font-size: 22px; line-height: 35.2px;\">Hola,</span></p><p style=\"font-size: 14px; line-height: 160%;\">" +
                "Hola {0},<br>Has solicitado una nueva contraseña, puedes hacer clic en el siguiente botón y crear una nueva." +
                "</p></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;\" align=\"left\"><div align=\"center\"><!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" style=\"height:44px; v-text-anchor:middle; width:216px;\" arcsize=\"9%\"  stroke=\"f\" fillcolor=\"#2dc26b\"><w:anchorlock/><center style=\"color:#FFFFFF;font-family:'Cabin',sans-serif;\"><![endif]-->" +
                "<a href=\" {1} \" target=\"_blank\" class=\"v-button\" style=\"box-sizing: border-box;display: inline-block;font-family:'Cabin',sans-serif;text-decoration: none;text-align: center;color: #FFFFFF; background-color: #2dc26b; border-radius: 4px;  width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; font-size: 14px;\"><span style=\"display:block;padding:14px 44px 13px;line-height:120%;\"><span style=\"line-height: 16.8px;\"><strong><span style=\"line-height: 16.8px;\">" +
                "CREAR NUEVA CONTRASEÑA" +
                "</span></strong></span></span></a><!--[if mso]></center></v:roundrect><![endif]--></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px 60px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Gracias,</span></p><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Equipo MIPnet</span></p></div></td></tr></tbody></table></div></div></div></div></div><!--[if (mso)|(IE)]></td></tr></table><![endif]--></td></tr></tbody></table>"
                , "samuel gonzalez", callback.ToString());

            var message = new Message(new string[] { "s.gonzalez@atomos.cl" }, "Recupera tu contraseña", content, null);


            await _emailService.SendEmailAsync(message);

        }
        public async Task ResetPassword(ResetPasswordResponseDto request)
        {

            var user = await _userManager.FindByNameAsync(request.Email);
            if (user == null)
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El E-mail no se encuentra registrado" }
                );

            var resetPassResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);

                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = new { Errors = errors } }
                );
            }

            var callback = "http://localhost:5201/join/login";

            var content = string.Format("<table style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr style=\"vertical-align: top\"><td style=\"word-break: break-word;border-collapse: collapse;vertical-align: top\"><!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #f9f9f9;\"><![endif]--><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:0px 10px 31px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"color: #34495e; line-height: 140%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 28px; line-height: 39.2px;\"><strong><span style=\"line-height: 39.2px; font-size: 28px;\">" +
                "CONTRASEÑA RESTABLECIDA" +
                "</span></strong></span></p></div></td></tr></tbody></table></div></div></div></div></div><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;background-color: #ffffff;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 160%;\"> <span style=\"font-size: 22px; line-height: 35.2px;\">Hola,</span></p><p style=\"font-size: 14px; line-height: 160%;\">" +
                "Hola {0},<br>Has restablecido tu contraseña correctamente." +
                "</p></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;\" align=\"left\"><div align=\"center\"><!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" style=\"height:44px; v-text-anchor:middle; width:216px;\" arcsize=\"9%\"  stroke=\"f\" fillcolor=\"#2dc26b\"><w:anchorlock/><center style=\"color:#FFFFFF;font-family:'Cabin',sans-serif;\"><![endif]-->" +
                "<a href=\"{1}\" target=\"_blank\" class=\"v-button\" style=\"box-sizing: border-box;display: inline-block;font-family:'Cabin',sans-serif;text-decoration: none;text-align: center;color: #FFFFFF; background-color: #2dc26b; border-radius: 4px;  width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; font-size: 14px;\"><span style=\"display:block;padding:14px 44px 13px;line-height:120%;\"><span style=\"line-height: 16.8px;\"><strong><span style=\"line-height: 16.8px;\">" +
                "Ir al sitio web de MIPnet" +
                "</span></strong></span></span></a><!--[if mso]></center></v:roundrect><![endif]--></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px 60px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Gracias,</span></p><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Equipo MIPnet</span></p></div></td></tr></tbody></table></div></div></div></div></div><!--[if (mso)|(IE)]></td></tr></table><![endif]--></td></tr></tbody></table>"
                , "samuel gonzalez", callback.ToString());

            var message = new Message(new string[] { "s.gonzalez@atomos.cl" }, "Recupera tu contraseña", content, null);


            await _emailService.SendEmailAsync(message);

        }

        public async Task EmailConfirmation(string email, string token)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = new { Errors = "E-mail de confirmación invalido " } }
               );
            
            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = new { Errors = "Token de confirmación invalido " } }
               );

        }


    }
}
