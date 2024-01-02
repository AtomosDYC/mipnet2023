using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.TipoParametros
{
    public class TipoParametroRepository : ITipoParametroRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoParametroRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTipoParametro(wkf10TipoParametro tipoparametro)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (tipoparametro is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            tipoparametro.fechaactivacion = DateTime.Now;
            tipoparametro.createby = usuario.Id;
            tipoparametro.wkf10activo = 1;

            await _contexto.wkf10TipoParametros!.AddAsync(tipoparametro);

        }

        public async Task DeleteTipoParametro(int id)
        {

            var tipoparametro = await _contexto.wkf10TipoParametros!
                .FirstOrDefaultAsync(x => x.wkf10llave == id);

            _contexto.wkf10TipoParametros!.Remove(tipoparametro!);
        }

        public async Task<IEnumerable<wkf10TipoParametro>> GetAllTipoParametros()
        {
            return await _contexto.wkf10TipoParametros!.ToListAsync();
        }

        public async Task<wkf10TipoParametro> GetTipoParametroById(int id)
        {
            return await _contexto.wkf10TipoParametros!.FirstOrDefaultAsync(x => x.wkf10llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoParametro(wkf10TipoParametro request)
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

            var tipoparametro = await _contexto.wkf10TipoParametros!
                .FirstOrDefaultAsync(x => x.wkf10llave == request.wkf10llave);

            tipoparametro.fechaactualizacion = DateTime.Now;
            tipoparametro.approveby = usuario.Id;
            tipoparametro.wkf10nombre = request.wkf10nombre;
            tipoparametro.wkf10descripcion = request.wkf10descripcion;

            _contexto.wkf10TipoParametros!.Update(tipoparametro!);

        }

        public async Task DisableTipoParametro(int id)
        {

            var tipoparametro = await _contexto.wkf10TipoParametros!
                .FirstOrDefaultAsync(x => x.wkf10llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoparametro is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipoparametro no existe en los listados" }
                   );
            }


            tipoparametro.wkf10activo = 0;

            _contexto.wkf10TipoParametros!.Update(tipoparametro);


        }

        public async Task ActivateTipoParametro(int id)
        {

            var tipoparametro = await _contexto.wkf10TipoParametros!
                .FirstOrDefaultAsync(x => x.wkf10llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoparametro is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La tipoparametro no existe en los listados" }
                   );
            }


            tipoparametro.wkf10activo = 1;

            _contexto.wkf10TipoParametros!.Update(tipoparametro);


        }

    }
}
