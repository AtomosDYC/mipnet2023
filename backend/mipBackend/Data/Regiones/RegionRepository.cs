using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Regiones
{
    public class RegionRepository : IRegionRepository   
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public RegionRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateRegion(Sist04Region region)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (region is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            region.fechaactivacion  = DateTime.Now;
            region.createby = Guid.Parse(usuario.Id);
            region.sist04activo = 1;

            await _contexto.Sist04Regiones!.AddAsync(region);

        }

        public async Task DeleteRegion(int id)
        {




            var region = await _contexto.Sist04Regiones!
                .FirstOrDefaultAsync(x => x.sist04llave == id);

            _contexto.Sist04Regiones!.Remove(region!);
        }

        public async Task<IEnumerable<Sist04Region>> GetAllRegiones()
        {
            return await _contexto.Sist04Regiones!.ToListAsync();
        }

        public async Task<Sist04Region> GetRegionById(int id)
        {
            return await _contexto.Sist04Regiones!.FirstOrDefaultAsync(x => x.sist04llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateRegion(Sist04Region request)
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

            var region = await _contexto.Sist04Regiones!
                .FirstOrDefaultAsync(x => x.sist04llave == request.sist04llave);

            region.fechaactualizacion = DateTime.Now;
            region.approveby = Guid.Parse(usuario.Id);
            region.sist04nombre = request.sist04nombre;
            region.sist04descripcion = request.sist04descripcion;
            region.sist04orden = request.sist04orden;

            _contexto.Sist04Regiones!.Update(region!);

        }

        public async Task DisableRegion(int id)
        {

            var region = await _contexto.Sist04Regiones!
                .FirstOrDefaultAsync(x => x.sist04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (region is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La region no existe en los listados" }
                   );
            }


            region.sist04activo = 0;

            _contexto.Sist04Regiones!.Update(region);
           

        }

        public async Task ActivateRegion(int id)
        {

            var region = await _contexto.Sist04Regiones!
                .FirstOrDefaultAsync(x => x.sist04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (region is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La region no existe en los listados" }
                   );
            }


            region.sist04activo = 1;

            _contexto.Sist04Regiones!.Update(region);


        }

    }
}
