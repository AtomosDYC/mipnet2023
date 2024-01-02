using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.DefaultUserDtos;

namespace mipBackend.Data.DefaultUsers
{
    public class DefaultUserRepository : IDefaultUserRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public DefaultUserRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager,
            IMapper mapper)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task CreateDefaultUser(per09DefaultUser defaultuser)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (defaultuser is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var ID = 1;
            var defaults = await _contexto.per09DefaultUsers!.FirstOrDefaultAsync(x => x.per09llave == ID)!;

            if (defaults is null)
            {
                await _contexto.per09DefaultUsers!.AddAsync(defaultuser!);
            } 
            else
            {

                defaultuser.per09llave = defaults.per09llave;
                _contexto.per09DefaultUsers!.Update(defaultuser);
            }

            

        }

        public async Task<DefaultUserResponseDto> GetAllDefaultUsers()
        {
            using (var db = _contexto)
            {
                var query = await (from df in db.per09DefaultUsers!

                                   join rol in db.Roles! on df.rolid equals rol.Id into nubrol
                                   from rl in nubrol.DefaultIfEmpty()

                                   join plan in db.prf03Plantillas! on df.plantillaid equals plan.prf03llave into nubplan
                                   from pl in nubplan.DefaultIfEmpty()

                                   join saludo in db.per02Generos! on df.saludoid equals saludo.per02llave into nubsaludo
                                   from sl in nubsaludo.DefaultIfEmpty()

                                   join doc in db.per08TipoDocumentos! on df.tipodocumentoid equals doc.per08llave into nubdoc
                                   from dc in nubdoc.DefaultIfEmpty()

                                   join persona in db.per03Tipopersonas! on df.tipopersonaid equals persona.per03llave into nubpersona
                                   from pr in nubpersona.DefaultIfEmpty()


                                   where (df.per09llave == 1)
                                   
                                   select new DefaultUserResponseDto
                                   {
                                       per09llave = df.per09llave,
                                       per09nombre = df.per09nombre,
                                       rolid = df.rolid,
                                       rolnombre = rl.Name,
                                       plantillaid = df.plantillaid,
                                       plantillanombre = pl.prf03nombre,
                                       saludoid=df.saludoid,
                                       saludonombre = sl.per02titulo,
                                       tipodocumentoid = df.tipodocumentoid,
                                       tipodocumentonombre = dc.per08nombre,
                                       tipopersonaid=df.tipopersonaid,
                                       tipopersonanombre = pr.per03nombre

                                   }).FirstAsync();

                return _mapper.Map<DefaultUserResponseDto>(query!);
            }
        }

        public async Task<per09DefaultUser> GetDefaultUserById(int id)
        {
            return await _contexto.per09DefaultUsers!.FirstOrDefaultAsync(x => x.per09llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateDefaultUser(per09DefaultUser request)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (request is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var defaultuser = await _contexto.per09DefaultUsers!
                .FirstOrDefaultAsync(x => x.per09llave == request.per09llave);

            defaultuser.per09nombre = request.per09nombre;


            _contexto.per09DefaultUsers!.Update(defaultuser!);

        }

       
    }
}
