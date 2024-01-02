using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Saludos
{
    public class SaludoRepository : ISaludoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public SaludoRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateSaludo(per02Genero region)
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

            region.fechaactivacion = DateTime.Now;
            region.createby = usuario.Id;
            region.per02activo = 1;

            await _contexto.per02Generos!.AddAsync(region);

        }

        public async Task DeleteSaludo(int id)
        {




            var region = await _contexto.per02Generos!
                .FirstOrDefaultAsync(x => x.per02llave == id);

            _contexto.per02Generos!.Remove(region!);
        }

        public async Task<IEnumerable<per02Genero>> GetAllSaludos()
        {
            return await _contexto.per02Generos!.ToListAsync();
        }

        public async Task<per02Genero> GetSaludoById(int id)
        {
            return await _contexto.per02Generos!.FirstOrDefaultAsync(x => x.per02llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateSaludo(per02Genero request)
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

            var region = await _contexto.per02Generos!
                .FirstOrDefaultAsync(x => x.per02llave == request.per02llave);

            region.fechaactualizacion = DateTime.Now;
            region.approveby = usuario.Id;
            region.per02titulo = request.per02titulo;
            region.per02orden = request.per02orden;

            _contexto.per02Generos!.Update(region!);

        }

        public async Task DisableSaludo(int id)
        {

            var region = await _contexto.per02Generos!
                .FirstOrDefaultAsync(x => x.per02llave == id);

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


            region.per02activo = 0;

            _contexto.per02Generos!.Update(region);


        }

        public async Task ActivateSaludo(int id)
        {

            var region = await _contexto.per02Generos!
                .FirstOrDefaultAsync(x => x.per02llave == id);

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


            region.per02activo = 1;

            _contexto.per02Generos!.Update(region);


        }

    }
}
