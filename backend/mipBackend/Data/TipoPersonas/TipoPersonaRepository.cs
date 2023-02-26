using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoPersonaDtos;

namespace mipBackend.Data.TipoPersonas 
{
    public class TipoPersonaRepository : ITipoPersonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoPersonaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoPersona(Per03TipoPersona tipopersona)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (tipopersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            tipopersona.fechaactivacion = DateTime.Now;
            tipopersona.createby = Guid.Parse(usuario.Id);
            tipopersona.per03activo = 1;

            await _contexto.Per03TipoPersonas!.AddAsync(tipopersona);

        }

        public async Task DeleteTipoPersona(int id)
        {
            
            var tipopersona = await _contexto.Per03TipoPersonas!
                .FirstOrDefaultAsync(x => x.per03llave == id);

            _contexto.Per03TipoPersonas!.Remove(tipopersona!);
        }

        public async Task<IEnumerable<Per03TipoPersona>> GetAllTipoPersonas()
        {
            return await _contexto.Per03TipoPersonas!.ToListAsync();
        }

        public async Task<Per03TipoPersona> GetTipoPersonaById(int id)
        {
            return await _contexto.Per03TipoPersonas!.FirstOrDefaultAsync(x => x.per03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoPersona(Per03TipoPersona request)
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

            var tipopersona = await _contexto.Per03TipoPersonas!
                .FirstOrDefaultAsync(x => x.per03llave == request.per03llave);

            tipopersona.fechaactualizacion = DateTime.Now;
            tipopersona.approveby = Guid.Parse(usuario.Id);
            tipopersona.per03nombre = request.per03nombre;
            tipopersona.per03descripcion = request.per03descripcion;
            
            _contexto.Per03TipoPersonas!.Update(tipopersona!);

        }

        public async Task DisableTipoPersona(int id)
        {

            var tipopersona = await _contexto.Per03TipoPersonas!
                .FirstOrDefaultAsync(x => x.per03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipopersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipopersona no existe en los listados" }
                   );
            }


            tipopersona.per03activo = 0;

            _contexto.Per03TipoPersonas!.Update(tipopersona);


        }

        public async Task ActivateTipoPersona(int id)
        {

            var tipopersona = await _contexto.Per03TipoPersonas!
                .FirstOrDefaultAsync(x => x.per03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipopersona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipopersona no existe en los listados" }
                   );
            }


            tipopersona.per03activo = 1;

            _contexto.Per03TipoPersonas!.Update(tipopersona);

        }
    }
}
