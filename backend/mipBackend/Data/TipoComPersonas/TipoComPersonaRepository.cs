using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoCompersonaDtos;

namespace mipBackend.Data.TipoCompersonas
{
    public class TipoCompersonaRepository : ITipoCompersonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoCompersonaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoCompersona(per04TipoComunicacion TipoCompersona)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (TipoCompersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            TipoCompersona.fechaactivacion = DateTime.Now;
            TipoCompersona.createby = usuario.Id;
            TipoCompersona.per04activo = 1;

            await _contexto.per04TipoComunicaciones!.AddAsync(TipoCompersona);

        }

        public async Task DeleteTipoCompersona(int id)
        {
            
            var TipoCompersona = await _contexto.per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            _contexto.per04TipoComunicaciones!.Remove(TipoCompersona!);
        }

        public async Task<IEnumerable<per04TipoComunicacion>> GetAllTipoCompersonas()
        {
            return await _contexto.per04TipoComunicaciones!.ToListAsync();
        }

        public async Task<per04TipoComunicacion> GetTipoCompersonaById(int id)
        {
            return await _contexto.per04TipoComunicaciones!.FirstOrDefaultAsync(x => x.per04llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoCompersona(per04TipoComunicacion request)
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

            var TipoCompersona = await _contexto.per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == request.per04llave);

            TipoCompersona.fechaactualizacion = DateTime.Now;
            TipoCompersona.approveby = usuario.Id;
            TipoCompersona.per04nombre = request.per04nombre;
            TipoCompersona.per04descripcion = request.per04descripcion;
            
            _contexto.per04TipoComunicaciones!.Update(TipoCompersona!);

        }

        public async Task DisableTipoCompersona(int id)
        {

            var TipoCompersona = await _contexto.per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TipoCompersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TipoCompersona no existe en los listados" }
                   );
            }


            TipoCompersona.per04activo = 0;

            _contexto.per04TipoComunicaciones!.Update(TipoCompersona);


        }

        public async Task ActivateTipoCompersona(int id)
        {

            var TipoCompersona = await _contexto.per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TipoCompersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TipoCompersona no existe en los listados" }
                   );
            }


            TipoCompersona.per04activo = 1;

            _contexto.per04TipoComunicaciones!.Update(TipoCompersona);


        }
    }
}
