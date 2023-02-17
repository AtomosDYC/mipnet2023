using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Plantillas
{
    public class PlantillaRepository : IPlantillaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public PlantillaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreatePlantilla(Prf03Plantilla plantilla)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (plantilla is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            plantilla.fechaactivacion  = DateTime.Now;
            plantilla.createby = Guid.Parse(usuario.Id);
            plantilla.prf03activo = 1;

            await _contexto.Prf03Plantillas!.AddAsync(plantilla);

        }

        public async Task DeletePlantilla(int id)
        {




            var plantilla = await _contexto.Prf03Plantillas!
                .FirstOrDefaultAsync(x => x.prf03llave == id);

            _contexto.Prf03Plantillas!.Remove(plantilla!);
        }

        public async Task<IEnumerable<Prf03Plantilla>> GetAllPlantillas()
        {
            return await _contexto.Prf03Plantillas!.ToListAsync();
        }

        public async Task<Prf03Plantilla> GetPlantillaById(int id)
        {
            return await _contexto.Prf03Plantillas!.FirstOrDefaultAsync(x => x.prf03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdatePlantilla(Prf03Plantilla request)
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

            var plantilla = await _contexto.Prf03Plantillas!
                .FirstOrDefaultAsync(x => x.prf03llave == request.prf03llave);

            plantilla.fechaactualizacion = DateTime.Now;
            plantilla.approveby = Guid.Parse(usuario.Id);
            plantilla.prf03nombre = request.prf03nombre;
            plantilla.prf03descripcion = request.prf03descripcion;
            

            _contexto.Prf03Plantillas!.Update(plantilla!);

        }

        public async Task DisablePlantilla(int id)
        {

            var plantilla = await _contexto.Prf03Plantillas!
                .FirstOrDefaultAsync(x => x.prf03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (plantilla is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La plantilla no existe en los listados" }
                   );
            }


            plantilla.prf03activo = 0;

            _contexto.Prf03Plantillas!.Update(plantilla);
           

        }

        public async Task ActivatePlantilla(int id)
        {

            var plantilla = await _contexto.Prf03Plantillas!
                .FirstOrDefaultAsync(x => x.prf03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (plantilla is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La plantilla no existe en los listados" }
                   );
            }


            plantilla.prf03activo = 1;

            _contexto.Prf03Plantillas!.Update(plantilla);


        }
    }
}
