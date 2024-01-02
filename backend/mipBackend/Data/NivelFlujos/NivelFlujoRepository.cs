using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.NivelFlujoDtos;

namespace mipBackend.Data.NivelFlujos
{
    public class NivelFlujoRepository : INivelFlujoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public NivelFlujoRepository(
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


        public async Task CreateNivelFlujo(wkf03Nivel nivelflujo)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (nivelflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            nivelflujo.fechaactivacion = DateTime.Now;
            nivelflujo.createby = usuario.Id;
            nivelflujo.wkf03activo = 1;

            await _contexto.wkf03Niveles!.AddAsync(nivelflujo);

        }

        public async Task DeleteNivelFlujo(int id)
        {
            var NivelFlujo = await _contexto.wkf03Niveles!
                .FirstOrDefaultAsync(x => x.wkf03llave == id);

            _contexto.wkf03Niveles!.Remove(NivelFlujo!);
        }

        public async Task<IEnumerable<NivelFlujoResponseDto>> GetAllNivelFlujos()
        {
            using (var db = _contexto)
            {
                var query = await (from niv in db.wkf03Niveles
                                   join flu in db.wkf02TipoFlujos! on niv.wkf02llave equals flu.wkf02llave
                                   where (flu.wkf02activo == 1)
                                   select new NivelFlujoResponseDto
                                   {
                                       wkf03llave = niv.wkf03llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf03descripcion = niv.wkf03descripcion,
                                       wkf03activo = niv.wkf03activo,
                                       wkf02llave = flu.wkf02llave,
                                       wkf03nivel1 = niv.wkf03nivel1,
                                       wkf02nombre = flu.wkf02nombre
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<NivelFlujoResponseDto>>(query);

            }
        }

        public async Task<wkf03Nivel> GetNivelFlujoById(int id)
        {
            return await _contexto.wkf03Niveles!.FirstOrDefaultAsync(x => x.wkf03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateNivelFlujo(wkf03Nivel request)
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

            var nivelflujo = await _contexto.wkf03Niveles!
                .FirstOrDefaultAsync(x => x.wkf03llave == request.wkf03llave);

            nivelflujo.fechaactualizacion = DateTime.Now;
            nivelflujo.approveby = usuario.Id;
            nivelflujo.wkf03nombre = request.wkf03nombre;
            nivelflujo.wkf03descripcion = request.wkf03descripcion;
            nivelflujo.wkf02llave = request.wkf02llave;
            
            _contexto.wkf03Niveles!.Update(nivelflujo!);

        }

        public async Task DisableNivelFlujo(int id)
        {

            var nivelflujo = await _contexto.wkf03Niveles!
                .FirstOrDefaultAsync(x => x.wkf03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (nivelflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La NivelFlujo no existe en los listados" }
                   );
            }


            nivelflujo.wkf03activo = 0;

            _contexto.wkf03Niveles!.Update(nivelflujo);


        }

        public async Task ActivateNivelFlujo(int id)
        {

            var nivelflujo = await _contexto.wkf03Niveles!
                .FirstOrDefaultAsync(x => x.wkf03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (nivelflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La NivelFlujo no existe en los listados" }
                   );
            }

            nivelflujo.wkf03activo = 1;

            _contexto.wkf03Niveles!.Update(nivelflujo);

        }

    }
}
