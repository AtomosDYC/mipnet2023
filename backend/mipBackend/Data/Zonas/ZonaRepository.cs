using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Zonas
{
    public class ZonaRepository : IZonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public ZonaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }


        public async Task CreateZona(Sist02Zona zona)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (zona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            zona.fechaactivacion = DateTime.Now;
            zona.createby = Guid.Parse(usuario.Id);
            zona.sist02activo = 1;

            await _contexto.Sist02Zonas!.AddAsync(zona);

        }

        public async Task DeleteZona(int id)
        {

            var zona = await _contexto.Sist02Zonas!
                .FirstOrDefaultAsync(x => x.sist02llave == id);

            _contexto.Sist02Zonas!.Remove(zona!);
        }

        public async Task<IEnumerable<Sist02Zona>> GetAllZonas()
        {
            return await _contexto.Sist02Zonas!.ToListAsync();
        }

        public async Task<Sist02Zona> GetZonaById(int id)
        {
            return await _contexto.Sist02Zonas!.FirstOrDefaultAsync(x => x.sist02llave== id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateZona(Sist02Zona request)
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

            var zona = await _contexto.Sist02Zonas!
                .FirstOrDefaultAsync(x => x.sist02llave== request.sist02llave);

            zona.fechaactualizacion = DateTime.Now;
            zona.approveby = Guid.Parse(usuario.Id);
            zona.sist02nombre = request.sist02nombre;
            zona.sist02descripcion = request.sist02descripcion;
            zona.sist02estadoregistro = request.sist02estadoregistro;

            _contexto.Sist02Zonas!.Update(zona!);

        }

        public async Task DisableZona(int id)
        {

            var zona = await _contexto.Sist02Zonas!
                .FirstOrDefaultAsync(x => x.sist02llave== id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (zona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La region no existe en los listados" }
                   );
            }


            zona.sist02activo = 0;

            _contexto.Sist02Zonas!.Update(zona);


        }

        public async Task ActivateZona(int id)
        {

            var zona = await _contexto.Sist02Zonas!
                .FirstOrDefaultAsync(x => x.sist02llave== id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (zona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La region no existe en los listados" }
                   );
            }


            zona.sist02activo = 1;

            _contexto.Sist02Zonas!.Update(zona);


        }


    }
}
