using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.EstadosDanioDtos;

namespace mipBackend.Data.TipoFlujos
{
    public class TipoFlujosRepository : ITipoFlujosRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoFlujosRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoFlujo(wkf02TipoFlujo tipoflujo)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (tipoflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            tipoflujo.fechaactivacion = DateTime.Now;
            tipoflujo.createby = usuario.Id;
            tipoflujo.wkf02activo = 1;

            await _contexto.wkf02TipoFlujos!.AddAsync(tipoflujo);

        }

        public async Task DeleteTipoFlujo(int id)
        {




            var tipoflujo = await _contexto.wkf02TipoFlujos!
                .FirstOrDefaultAsync(x => x.wkf02llave == id);

            _contexto.wkf02TipoFlujos!.Remove(tipoflujo!);
        }

        public async Task<IEnumerable<wkf02TipoFlujo>> GetAllTipoFlujos()
        {
            return await _contexto.wkf02TipoFlujos!.ToListAsync();
        }

        public async Task<wkf02TipoFlujo> GetTipoFlujoById(int id)
        {
            return await _contexto.wkf02TipoFlujos!.FirstOrDefaultAsync(x => x.wkf02llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoFlujo(wkf02TipoFlujo request)
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

            var tipoflujo = await _contexto.wkf02TipoFlujos!
                .FirstOrDefaultAsync(x => x.wkf02llave == request.wkf02llave);

            tipoflujo.fechaactualizacion = DateTime.Now;
            tipoflujo.approveby = usuario.Id;
            tipoflujo.wkf02nombre = request.wkf02nombre;
            tipoflujo.wkf02descripcion = request.wkf02descripcion;
            tipoflujo.wkf02orden = request.wkf02orden;

            _contexto.wkf02TipoFlujos!.Update(tipoflujo!);

        }

        public async Task DisableTipoFlujo(int id)
        {

            var tipoflujo = await _contexto.wkf02TipoFlujos!
                .FirstOrDefaultAsync(x => x.wkf02llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipoflujo no existe en los listados" }
                   );
            }


            tipoflujo.wkf02activo = 0;

            _contexto.wkf02TipoFlujos!.Update(tipoflujo);


        }

        public async Task ActivateTipoFlujo(int id)
        {

            var tipoflujo = await _contexto.wkf02TipoFlujos!
                .FirstOrDefaultAsync(x => x.wkf02llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoflujo is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipoflujo no existe en los listados" }
                   );
            }


            tipoflujo.wkf02activo = 1;

            _contexto.wkf02TipoFlujos!.Update(tipoflujo);


        }
    }
}
