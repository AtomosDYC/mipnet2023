using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;
using AutoMapper;
using Microsoft.Data.SqlClient;
using mipBackend.Services.EmailService;
using mipBackend.Dtos.EmailDtos;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;


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
        private readonly IEmailService _emailService;

        public UsuarioRepository(
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
        private UserAuthReponseDto TransformerUserToUserDto(Usuario usuario) {

            return new UserAuthReponseDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario)
            };

        
        }

        public async Task<IEnumerable<UsuarioRegistroResponseDto>> GetAllUsuarios()
        {
            
            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join urol in db.UserRoles! on usr.Id equals urol.UserId
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   join prsr in db.per07personaUsuarios! on usr.Id equals prsr.userid
                                   join per in db.per01personas! on prsr.per01llave equals per.per01llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   join tiper in db.per03Tipopersonas! on per.per03llave equals tiper.per03llave
                                   join doc in db.per08TipoDocumentos! on per.per08llave equals doc.per08llave
                                   join prf in db.prf01perfiles! on usr.Id equals prf.userid
                                   join prf3 in db.prf03Plantillas! on prf.prf03llave equals prf3.prf03llave


                                   where (prsr.per07activo == 1 && per.per01activo == 1 && prf.prf01activo == 1)
                                   orderby rol.Name, usr.UserName

                                   select new UsuarioRegistroResponseDto
                                   {
                                       userid = usr.Id,
                                       username = usr.UserName,
                                       emailconfirmed = usr.EmailConfirmed,
                                       email = usr.Email,
                                       roleid = rol.Id,
                                       rolename = rol.Name,
                                       per01llave = per.per01llave,
                                       per01nombre = per.per01nombrerazon,
                                       plantillaid = prf3.prf03llave,
                                       plantillanombre = prf3.prf03nombre,
                                       saludoid = sal.per02llave,
                                       saludonombre = sal.per02titulo,
                                       tipodocumentoid = doc.per08llave,
                                       tipodocumentonombre = doc.per08nombre,
                                       tipopersonaid = tiper.per03llave,
                                       tipopersonanombre = tiper.per03nombre,


                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<UsuarioRegistroResponseDto>>(query!);

            }

        }

        public async Task<UsuarioRegistroResponseDto> GetAllUsuariosById(string id)
        {

            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join urol in db.UserRoles! on usr.Id equals urol.UserId
                                   join rol in db.Roles! on urol.RoleId equals rol.Id
                                   join prsr in db.per07personaUsuarios! on usr.Id equals prsr.userid
                                   join per in db.per01personas! on prsr.per01llave equals per.per01llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   join tiper in db.per03Tipopersonas! on per.per03llave equals tiper.per03llave
                                   join doc in db.per08TipoDocumentos! on per.per08llave equals doc.per08llave
                                   join prf in db.prf01perfiles! on usr.Id equals prf.userid
                                   join prf3 in db.prf03Plantillas! on prf.prf03llave equals prf3.prf03llave


                                   where (prsr.per07activo == 1 && per.per01activo == 1 && prf.prf01activo == 1)
                                   where (usr.Id.ToString() ==  id)
                                   orderby rol.Name, usr.UserName

                                   select new UsuarioRegistroResponseDto
                                   {
                                       userid = usr.Id,
                                       username = usr.UserName,
                                       emailconfirmed = usr.EmailConfirmed,
                                       email = usr.Email,
                                       roleid = rol.Id,
                                       rolename = rol.Name,
                                       per01llave = per.per01llave,
                                       per01nombre = per.per01nombrerazon,
                                       plantillaid = prf3.prf03llave,
                                       plantillanombre = prf3.prf03nombre,
                                       saludoid = sal.per02llave,
                                       saludonombre = sal.per02titulo,
                                       tipodocumentoid = doc.per08llave,
                                       tipodocumentonombre = doc.per08nombre,
                                       tipopersonaid = tiper.per03llave,
                                       tipopersonanombre = tiper.per03nombre,
                                      
                                   }).FirstAsync();

                return _mapper.Map<UsuarioRegistroResponseDto>(query!);

            }

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



                string sql = "EXEC pa_mipnet_usuarioDefault_i @NAME, @USERNAME, @PASSWORD, @USUARIO_ID ";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@NAME", Value = request.Name },
                    new SqlParameter { ParameterName = "@USERNAME", Value = request.UserName },
                    new SqlParameter { ParameterName = "@PASSWORD", Value = request.Password },
                    new SqlParameter { ParameterName = "@USUARIO_ID", Value = createdby.Id}

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

        public async Task UpdateUsuario
            (
            UsuarioRegistroResponseDto request
            )
        {

            var usuario = await _contexto.Users!.FirstOrDefaultAsync(x => x.Id == request.userid);

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.BadRequest,
                    new { mensaje = "El Usuario no existe en la base de datos" }
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


            usuario.Email = request.email;
           
            var resultado = await _userManager.UpdateAsync(usuario!);

            if (resultado.Succeeded)
            {
                int rowsAffected;

                string sql = "EXEC pa_mipnet_usuarioDefault_u @USER_Id, @ROL_ID, @TIPODOCUMENTO_ID, @PLANTILLA_ID, @TIPOPERSONA_ID, @SALUDO_ID, @PER01_NOMBRE  ";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@USER_Id", Value = request.userid },
                    new SqlParameter { ParameterName = "@ROL_ID", Value = request.roleid },
                    new SqlParameter { ParameterName = "@TIPODOCUMENTO_ID", Value = request.tipodocumentoid },
                    new SqlParameter { ParameterName = "@PLANTILLA_ID", Value = request.plantillaid},
                    new SqlParameter { ParameterName = "@TIPOPERSONA_ID", Value = request.tipopersonaid },
                    new SqlParameter { ParameterName = "@SALUDO_ID", Value = request.saludoid },
                    new SqlParameter { ParameterName = "@PER01_NOMBRE", Value = request.per01nombre},


                };

                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());

                return;

            }


            throw new MiddlewareException(
                   HttpStatusCode.Unauthorized,
                   new { mensaje = resultado.Errors }
               );

        }


        public async Task SendMailConfirmation(Usuario usuario)
        {
            try
            {

            
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                var param = new Dictionary<string, string?>
                    {
                        {"token", token },
                        {"email", usuario.Email }
                    };

                var callback = QueryHelpers.AddQueryString("http://localhost:5201/mailconfirmation", param);

            
                var content = string.Format("<table style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr style=\"vertical-align: top\"><td style=\"word-break: break-word;border-collapse: collapse;vertical-align: top\"><!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #f9f9f9;\"><![endif]--><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:0px 10px 31px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"color: #34495e; line-height: 140%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 28px; line-height: 39.2px;\"><strong><span style=\"line-height: 39.2px; font-size: 28px;\">Confirmaci&oacute;n de E-mail</span></strong></span></p></div></td></tr></tbody></table></div></div></div></div></div><div style=\"padding: 0px;\"><div style=\"max-width: 600px;margin: 0 auto;background-color: #ffffff;\"><div class=\"u-row\"><div class=\"u-col u-col-100\" style=\"display:flex;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><div style=\"width: 100%;padding:0px;\"><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"font-size: 14px; line-height: 160%;\"><span style=\"font-size: 22px; line-height: 35.2px;\">Hola,</span></p><p style=\"font-size: 14px; line-height: 160%;\">Estás casi listo para empezar. ¡Haga clic en el botón a continuación para verificar su dirección de correo electrónico y disfrutar de servicios de limpieza exclusivos con nosotros!</p></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;\" align=\"left\"><div align=\"center\"><!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" style=\"height:44px; v-text-anchor:middle; width:216px;\" arcsize=\"9%\"  stroke=\"f\" fillcolor=\"#2dc26b\"><w:anchorlock/><center style=\"color:#FFFFFF;font-family:'Cabin',sans-serif;\"><![endif]--><a href=\" {0} \" target=\"_blank\" class=\"v-button\" style=\"box-sizing: border-box;display: inline-block;font-family:'Cabin',sans-serif;text-decoration: none;text-align: center;color: #FFFFFF; background-color: #2dc26b; border-radius: 4px;  width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; font-size: 14px;\"><span style=\"display:block;padding:14px 44px 13px;line-height:120%;\"><span style=\"line-height: 16.8px;\"><strong><span style=\"line-height: 16.8px;\">VERIFICAR TU E-MAIL</span></strong></span></span></a><!--[if mso]></center></v:roundrect><![endif]--></div></td></tr></tbody></table><table style=\"font-family:'Cabin',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:33px 55px 60px;font-family:'Cabin',sans-serif;\" align=\"left\"><div style=\"line-height: 160%; text-align: center; word-wrap: break-word;\"><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Gracias,</span></p><p style=\"line-height: 160%; font-size: 14px;\"><span style=\"font-size: 18px; line-height: 28.8px;\">Equipo MIPnet</span></p></div></td></tr></tbody></table></div></div></div></div></div><!--[if (mso)|(IE)]></td></tr></table><![endif]--></td></tr></tbody></table>", callback.ToString());

                var message = new Message(new string[] { "s.gonzalez@atomos.cl" }, "confirmacion e-mail", content ,null);
                /* await _emailSender.SendEmailAsync(message); */

                _emailService.SendEmail(message);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
