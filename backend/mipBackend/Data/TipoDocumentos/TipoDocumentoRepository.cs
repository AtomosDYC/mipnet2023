using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoDocumentoDtos;

namespace mipBackend.Data.TipoDocumentos
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoDocumentoRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoDocumento(per08TipoDocumento tipodocumento)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (tipodocumento is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            tipodocumento.fechaactivacion = DateTime.Now;
            tipodocumento.createby = usuario.Id;
            tipodocumento.per08activo = 1;

            await _contexto.per08TipoDocumentos!.AddAsync(tipodocumento);

        }

        public async Task DeleteTipoDocumento(int id)
        {

            var tipodocumento = await _contexto.per08TipoDocumentos!
                .FirstOrDefaultAsync(x => x.per08llave == id);

            _contexto.per08TipoDocumentos!.Remove(tipodocumento!);
        }

        public async Task<IEnumerable<per08TipoDocumento>> GetAllTipoDocumentos()
        {
            return await _contexto.per08TipoDocumentos!.ToListAsync();
        }

        public async Task<per08TipoDocumento> GetTipoDocumentoById(int id)
        {
            return await _contexto.per08TipoDocumentos!.FirstOrDefaultAsync(x => x.per08llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoDocumento(per08TipoDocumento request)
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

            var tipodocumento = await _contexto.per08TipoDocumentos!
                .FirstOrDefaultAsync(x => x.per08llave == request.per08llave);

            tipodocumento.fechaactualizacion = DateTime.Now;
            tipodocumento.approveby = usuario.Id;
            tipodocumento.per08nombre = request.per08nombre;
            tipodocumento.per08descripcion = request.per08descripcion;

            _contexto.per08TipoDocumentos!.Update(tipodocumento!);

        }

        public async Task DisableTipoDocumento(int id)
        {

            var tipodocumento = await _contexto.per08TipoDocumentos!
                .FirstOrDefaultAsync(x => x.per08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipodocumento is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipodocumento no existe en los listados" }
                   );
            }


            tipodocumento.per08activo = 0;

            _contexto.per08TipoDocumentos!.Update(tipodocumento);


        }

        public async Task ActivateTipoDocumento(int id)
        {

            var tipodocumento = await _contexto.per08TipoDocumentos!
                .FirstOrDefaultAsync(x => x.per08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipodocumento is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipodocumento no existe en los listados" }
                   );
            }


            tipodocumento.per08activo = 1;

            _contexto.per08TipoDocumentos!.Update(tipodocumento);

        }
    }
}