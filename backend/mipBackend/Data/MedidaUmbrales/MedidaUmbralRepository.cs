using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.MedidaUmbrales
{
    public class MedidaUmbralRepository : IMedidaUmbralRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public MedidaUmbralRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }


        public async Task CreateMedidaUmbral(Esp06MedidaUmbral medidaumbral)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            medidaumbral.fechaactivacion = DateTime.Now;
            medidaumbral.createby = Guid.Parse(usuario.Id);
            medidaumbral.esp06activo = 1;

            await _contexto.Esp06MedidaUmbrales!.AddAsync(medidaumbral);

        }

        public async Task DeleteMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.Esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            _contexto.Esp06MedidaUmbrales!.Remove(medidaumbral!);
        }

        public async Task<IEnumerable<Esp06MedidaUmbral>> GetAllMedidaUmbrales()
        {
            return await _contexto.Esp06MedidaUmbrales!.ToListAsync();
        }

        public async Task<Esp06MedidaUmbral> GetMedidaUmbralById(int id)
        {
            return await _contexto.Esp06MedidaUmbrales!.FirstOrDefaultAsync(x => x.esp06llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateMedidaUmbral(Esp06MedidaUmbral request)
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

            var medidaumbral = await _contexto.Esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == request.esp06llave);

            medidaumbral.fechaactualizacion = DateTime.Now;
            medidaumbral.approveby = Guid.Parse(usuario.Id);
            medidaumbral.esp06nombre = request.esp06nombre;
            medidaumbral.esp06descripcion = request.esp06descripcion;

            _contexto.Esp06MedidaUmbrales!.Update(medidaumbral!);

        }

        public async Task DisableMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.Esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }


            medidaumbral.esp06activo = 0;

            _contexto.Esp06MedidaUmbrales!.Update(medidaumbral);


        }

        public async Task ActivateMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.Esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }

            medidaumbral.esp06activo = 1;

            _contexto.Esp06MedidaUmbrales!.Update(medidaumbral);

        }


    }
}
