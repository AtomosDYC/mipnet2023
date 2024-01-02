
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipopermisoDtos;

namespace mipBackend.Data.Tipopermisos
{
    public class TipopermisosRepository : ITipopermisosRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipopermisosRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipopermiso(wkf05Tipopermiso tipoflujo)
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
            tipoflujo.wkf05activo = 1;

            await _contexto.wkf05Tipopermisos!.AddAsync(tipoflujo);

        }

        public async Task DeleteTipopermiso(int id)
        {

            var tipoflujo = await _contexto.wkf05Tipopermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == id);

            _contexto.wkf05Tipopermisos!.Remove(tipoflujo!);
        }

        public async Task<IEnumerable<wkf05Tipopermiso>> GetAllTipopermisos()
        {
            return await _contexto.wkf05Tipopermisos!.ToListAsync();
        }

        public async Task<wkf05Tipopermiso> GetTipopermisoById(int id)
        {
            return await _contexto.wkf05Tipopermisos!.FirstOrDefaultAsync(x => x.wkf05llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipopermiso(wkf05Tipopermiso request)
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

            var tipoflujo = await _contexto.wkf05Tipopermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == request.wkf05llave);

            tipoflujo.fechaactualizacion = DateTime.Now;
            tipoflujo.approveby = usuario.Id;
            tipoflujo.wkf05nombre = request.wkf05nombre;
            tipoflujo.wkf05descripcion = request.wkf05descripcion;
            
            _contexto.wkf05Tipopermisos!.Update(tipoflujo!);

        }

        public async Task DisableTipopermiso(int id)
        {

            var tipoflujo = await _contexto.wkf05Tipopermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == id);

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


            tipoflujo.wkf05activo = 0;

            _contexto.wkf05Tipopermisos!.Update(tipoflujo);


        }

        public async Task ActivateTipopermiso(int id)
        {

            var tipoflujo = await _contexto.wkf05Tipopermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == id);

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


            tipoflujo.wkf05activo = 1;

            _contexto.wkf05Tipopermisos!.Update(tipoflujo);


        }
    }
}
