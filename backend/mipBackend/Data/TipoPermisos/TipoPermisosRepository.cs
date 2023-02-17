
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoPermisoDtos;

namespace mipBackend.Data.TipoPermisos
{
    public class TipoPermisosRepository : ITipoPermisosRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoPermisosRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoPermiso(Wkf05TipoPermiso tipoflujo)
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
            tipoflujo.createby = Guid.Parse(usuario.Id);
            tipoflujo.wkf05activo = 1;

            await _contexto.Wkf05TipoPermisos!.AddAsync(tipoflujo);

        }

        public async Task DeleteTipoPermiso(int id)
        {

            var tipoflujo = await _contexto.Wkf05TipoPermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == id);

            _contexto.Wkf05TipoPermisos!.Remove(tipoflujo!);
        }

        public async Task<IEnumerable<Wkf05TipoPermiso>> GetAllTipoPermisos()
        {
            return await _contexto.Wkf05TipoPermisos!.ToListAsync();
        }

        public async Task<Wkf05TipoPermiso> GetTipoPermisoById(int id)
        {
            return await _contexto.Wkf05TipoPermisos!.FirstOrDefaultAsync(x => x.wkf05llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoPermiso(Wkf05TipoPermiso request)
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

            var tipoflujo = await _contexto.Wkf05TipoPermisos!
                .FirstOrDefaultAsync(x => x.wkf05llave == request.wkf05llave);

            tipoflujo.fechaactualizacion = DateTime.Now;
            tipoflujo.approveby = Guid.Parse(usuario.Id);
            tipoflujo.wkf05nombre = request.wkf05nombre;
            tipoflujo.wkf05descripcion = request.wkf05descripcion;
            
            _contexto.Wkf05TipoPermisos!.Update(tipoflujo!);

        }

        public async Task DisableTipoPermiso(int id)
        {

            var tipoflujo = await _contexto.Wkf05TipoPermisos!
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

            _contexto.Wkf05TipoPermisos!.Update(tipoflujo);


        }

        public async Task ActivateTipoPermiso(int id)
        {

            var tipoflujo = await _contexto.Wkf05TipoPermisos!
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

            _contexto.Wkf05TipoPermisos!.Update(tipoflujo);


        }
    }
}
