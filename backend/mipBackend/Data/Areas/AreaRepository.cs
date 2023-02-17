using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Areas
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public AreaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateArea(Wkf08Area area)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (area is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            area.fechaactivacion = DateTime.Now;
            area.wfk08activo = true;

            await _contexto.Wkf08Areas!.AddAsync(area);

        }

        public async Task DeleteArea(int id)
        {




            var area = await _contexto.Wkf08Areas!
                .FirstOrDefaultAsync(x => x.wfk08llave== id);

            _contexto.Wkf08Areas!.Remove(area!);
        }

        public async Task<IEnumerable<Wkf08Area>> GetAllAreas()
        {
            return await _contexto.Wkf08Areas!.ToListAsync();
        }

        public async Task<Wkf08Area> GetAreaById(int id)
        {
            return await _contexto.Wkf08Areas!.FirstOrDefaultAsync(x => x.wfk08llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateArea(Wkf08Area request)
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

            var area = await _contexto.Wkf08Areas!
                .FirstOrDefaultAsync(x => x.wfk08llave == request.wfk08llave);

            area.fechaactualizacion = DateTime.Now;
            area.wfk08nombre = request.wfk08nombre;
            area.wfk08descripcion = request.wfk08descripcion;
            
            _contexto.Wkf08Areas!.Update(area!);

        }

        public async Task DisableArea(int id)
        {

            var area = await _contexto.Wkf08Areas!
                .FirstOrDefaultAsync(x => x.wfk08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (area is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La area no existe en los listados" }
                   );
            }


            area.wfk08activo = false;

            _contexto.Wkf08Areas!.Update(area);


        }

        public async Task ActivateArea(int id)
        {

            var area = await _contexto.Wkf08Areas!
                .FirstOrDefaultAsync(x => x.wfk08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (area is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La area no existe en los listados" }
                   );
            }


            area.wfk08activo = true;

            _contexto.Wkf08Areas!.Update(area);


        }
    }
}
