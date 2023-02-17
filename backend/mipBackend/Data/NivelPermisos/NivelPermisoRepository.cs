using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.NivelPermisoDtos;

namespace mipBackend.Data.NivelPermisos
{
    public class NivelPermisoRepository : INivelPermisoRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public NivelPermisoRepository(
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


        public async Task CreateNivelPermiso(Wkf04NivelPermiso NivelPermiso)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (NivelPermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            NivelPermiso.wkf04activo = 1;

            await _contexto.Wkf04NivelPermisos!.AddAsync(NivelPermiso);

        }

        public async Task DeleteNivelPermiso(int id)
        {

            var NivelPermiso = await _contexto.Wkf04NivelPermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            _contexto.Wkf04NivelPermisos!.Remove(NivelPermiso!);
        }

        public async Task<IEnumerable<NivelPermisoResponseDto>> GetAllNivelPermisos()
        {
            using (var db = _contexto)
            {
                var query = await (from nivper in db.Wkf04NivelPermisos
                                   join niv in db.Wkf03Niveles! on nivper.wkf03llave equals niv.wkf03llave
                                   join tip in db.Wkf05TipoPermisos! on nivper.wkf05llave equals tip.wkf05llave
                                   where (niv.wkf03activo == 1 && tip.wkf05activo == 1)
                                   select new NivelPermisoResponseDto
                                   {
                                       wkf04llave = nivper.wkf04llave,
                                       wkf03llave = nivper.wkf03llave,
                                       wkf05llave = nivper.wkf05llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf05nombre = tip.wkf05nombre,
                                       wkf04activo = nivper.wkf04activo
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<NivelPermisoResponseDto>>(query);

            }
        }

        public async Task<Wkf04NivelPermiso> GetNivelPermisoById(int id)
        {
            return await _contexto.Wkf04NivelPermisos!.FirstOrDefaultAsync(x => x.wkf04llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateNivelPermiso(Wkf04NivelPermiso request)
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

            var NivelPermiso = await _contexto.Wkf04NivelPermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == request.wkf04llave);

            NivelPermiso.wkf03llave = request.wkf03llave;
            NivelPermiso.wkf05llave = request.wkf05llave;
            
            _contexto.Wkf04NivelPermisos!.Update(NivelPermiso!);

        }

        public async Task DisableNivelPermiso(int id)
        {

            var NivelPermiso = await _contexto.Wkf04NivelPermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (NivelPermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La NivelPermiso no existe en los listados" }
                   );
            }


            NivelPermiso.wkf04llave = 0;

            _contexto.Wkf04NivelPermisos!.Update(NivelPermiso);


        }

        public async Task ActivateNivelPermiso(int id)
        {

            var NivelPermiso = await _contexto.Wkf04NivelPermisos!
                .FirstOrDefaultAsync(x => x.wkf04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (NivelPermiso is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La NivelPermiso no existe en los listados" }
                   );
            }


            NivelPermiso.wkf04activo = 1;

            _contexto.Wkf04NivelPermisos!.Update(NivelPermiso);


        }
    }
}
