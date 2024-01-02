using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipopersonaDtos;

namespace mipBackend.Data.Tipopersonas 
{
    public class TipopersonaRepository : ITipopersonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipopersonaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipopersona(per03Tipopersona tipopersona)
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
            tipopersona.createby = usuario.Id;
            tipopersona.per03activo = 1;

            await _contexto.per03Tipopersonas!.AddAsync(tipopersona);

        }

        public async Task DeleteTipopersona(int id)
        {
            
            var tipopersona = await _contexto.per03Tipopersonas!
                .FirstOrDefaultAsync(x => x.per03llave == id);

            _contexto.per03Tipopersonas!.Remove(tipopersona!);
        }

        public async Task<IEnumerable<per03Tipopersona>> GetAllTipopersonas()
        {
            return await _contexto.per03Tipopersonas!.ToListAsync();
        }

        public async Task<per03Tipopersona> GetTipopersonaById(int id)
        {
            return await _contexto.per03Tipopersonas!.FirstOrDefaultAsync(x => x.per03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipopersona(per03Tipopersona request)
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

            var tipopersona = await _contexto.per03Tipopersonas!
                .FirstOrDefaultAsync(x => x.per03llave == request.per03llave);

            tipopersona.fechaactualizacion = DateTime.Now;
            tipopersona.approveby = usuario.Id;
            tipopersona.per03nombre = request.per03nombre;
            tipopersona.per03descripcion = request.per03descripcion;
            
            _contexto.per03Tipopersonas!.Update(tipopersona!);

        }

        public async Task DisableTipopersona(int id)
        {

            var tipopersona = await _contexto.per03Tipopersonas!
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

            _contexto.per03Tipopersonas!.Update(tipopersona);


        }

        public async Task ActivateTipopersona(int id)
        {

            var tipopersona = await _contexto.per03Tipopersonas!
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

            _contexto.per03Tipopersonas!.Update(tipopersona);

        }
    }
}
