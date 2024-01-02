using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.NivelpermisoDtos;

namespace mipBackend.Data.Nivelpermisos
{
    public class NivelpermisoRepository : INivelpermisoRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public NivelpermisoRepository(
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


        public async Task CreateNivelpermiso(wkf04Nivelpermiso Nivelpermiso)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (Nivelpermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            Nivelpermiso.wkf04activo = 1;

            await _contexto.wkf04Nivelpermisos!.AddAsync(Nivelpermiso);

        }

        public async Task DeleteNivelpermiso(int id)
        {

            var Nivelpermiso = await _contexto.wkf04Nivelpermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            _contexto.wkf04Nivelpermisos!.Remove(Nivelpermiso!);
        }

        public async Task<IEnumerable<NivelpermisoResponseDto>> GetAllNivelpermisos()
        {
            using (var db = _contexto)
            {
                var query = await (from nivper in db.wkf04Nivelpermisos
                                   join niv in db.wkf03Niveles! on nivper.wkf03llave equals niv.wkf03llave
                                   join tip in db.wkf05Tipopermisos! on nivper.wkf05llave equals tip.wkf05llave
                                   where (niv.wkf03activo == 1 && tip.wkf05activo == 1)
                                   select new NivelpermisoResponseDto
                                   {
                                       wkf04llave = nivper.wkf04llave,
                                       wkf03llave = nivper.wkf03llave,
                                       wkf05llave = nivper.wkf05llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf05nombre = tip.wkf05nombre,
                                       wkf04activo = nivper.wkf04activo
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<NivelpermisoResponseDto>>(query);

            }
        }

        public async Task<wkf04Nivelpermiso> GetNivelpermisoById(int id)
        {
            return await _contexto.wkf04Nivelpermisos!.FirstOrDefaultAsync(x => x.wkf04llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateNivelpermiso(wkf04Nivelpermiso request)
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

            var Nivelpermiso = await _contexto.wkf04Nivelpermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == request.wkf04llave);

            Nivelpermiso.wkf03llave = request.wkf03llave;
            Nivelpermiso.wkf05llave = request.wkf05llave;
            
            _contexto.wkf04Nivelpermisos!.Update(Nivelpermiso!);

        }

        public async Task DisableNivelpermiso(int id)
        {

            var Nivelpermiso = await _contexto.wkf04Nivelpermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Nivelpermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Nivelpermiso no existe en los listados" }
                   );
            }


            Nivelpermiso.wkf04llave = 0;

            _contexto.wkf04Nivelpermisos!.Update(Nivelpermiso);


        }

        public async Task ActivateNivelpermiso(int id)
        {

            var Nivelpermiso = await _contexto.wkf04Nivelpermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Nivelpermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Nivelpermiso no existe en los listados" }
                   );
            }


            Nivelpermiso.wkf04activo = 1;

            _contexto.wkf04Nivelpermisos!.Update(Nivelpermiso);


        }
    }
}
