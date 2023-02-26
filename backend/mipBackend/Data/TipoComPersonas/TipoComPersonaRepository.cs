using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoComPersonaDtos;

namespace mipBackend.Data.TipoComPersonas
{
    public class TipoComPersonaRepository : ITipoComPersonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoComPersonaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoComPersona(Per04TipoComunicacion TipoComPersona)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (TipoComPersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            TipoComPersona.fechaactivacion = DateTime.Now;
            TipoComPersona.createby = Guid.Parse(usuario.Id);
            TipoComPersona.per04activo = 1;

            await _contexto.Per04TipoComunicaciones!.AddAsync(TipoComPersona);

        }

        public async Task DeleteTipoComPersona(int id)
        {
            
            var TipoComPersona = await _contexto.Per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            _contexto.Per04TipoComunicaciones!.Remove(TipoComPersona!);
        }

        public async Task<IEnumerable<Per04TipoComunicacion>> GetAllTipoComPersonas()
        {
            return await _contexto.Per04TipoComunicaciones!.ToListAsync();
        }

        public async Task<Per04TipoComunicacion> GetTipoComPersonaById(int id)
        {
            return await _contexto.Per04TipoComunicaciones!.FirstOrDefaultAsync(x => x.per04llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoComPersona(Per04TipoComunicacion request)
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

            var TipoComPersona = await _contexto.Per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == request.per04llave);

            TipoComPersona.fechaactualizacion = DateTime.Now;
            TipoComPersona.approveby = Guid.Parse(usuario.Id);
            TipoComPersona.per04nombre = request.per04nombre;
            TipoComPersona.per04descripcion = request.per04descripcion;
            
            _contexto.Per04TipoComunicaciones!.Update(TipoComPersona!);

        }

        public async Task DisableTipoComPersona(int id)
        {

            var TipoComPersona = await _contexto.Per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TipoComPersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TipoComPersona no existe en los listados" }
                   );
            }


            TipoComPersona.per04activo = 0;

            _contexto.Per04TipoComunicaciones!.Update(TipoComPersona);


        }

        public async Task ActivateTipoComPersona(int id)
        {

            var TipoComPersona = await _contexto.Per04TipoComunicaciones!
                .FirstOrDefaultAsync(x => x.per04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TipoComPersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TipoComPersona no existe en los listados" }
                   );
            }


            TipoComPersona.per04activo = 1;

            _contexto.Per04TipoComunicaciones!.Update(TipoComPersona);


        }
    }
}
