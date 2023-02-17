using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;


namespace mipBackend.Data.TipoEspecie
{
    public class TipoEspecieRepository : ITipoEspecieRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TipoEspecieRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }


        public async Task CreateTipoEspecie(Esp08TipoBase tipoespecie)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (tipoespecie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            tipoespecie.fechaactivacion = DateTime.Now;
            tipoespecie.createby = Guid.Parse(usuario.Id);
            tipoespecie.esp08activo = 1;

            await _contexto.Esp08TipoBases!.AddAsync(tipoespecie);

        }

        public async Task DeleteTipoEspecie(int id)
        {




            var tipoespecie = await _contexto.Esp08TipoBases!
                .FirstOrDefaultAsync(x => x.esp08llave == id);

            _contexto.Esp08TipoBases!.Remove(tipoespecie!);
        }

        public async Task<IEnumerable<Esp08TipoBase>> GetAllTipoEspecies()
        {
            return await _contexto.Esp08TipoBases!.ToListAsync();
        }

        public async Task<Esp08TipoBase> GetTipoEspecieById(int id)
        {
            return await _contexto.Esp08TipoBases!.FirstOrDefaultAsync(x => x.esp08llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTipoEspecie(Esp08TipoBase request)
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

            var tipoespecie = await _contexto.Esp08TipoBases!
                .FirstOrDefaultAsync(x => x.esp08llave == request.esp08llave);

            tipoespecie.fechaactualizacion = DateTime.Now;
            tipoespecie.approveby = Guid.Parse(usuario.Id);
            tipoespecie.esp08nombre = request.esp08nombre;
            tipoespecie.esp08descripcion = request.esp08descripcion;

            _contexto.Esp08TipoBases!.Update(tipoespecie!);

        }

        public async Task DisableTipoEspecie(int id)
        {

            var tipoespecie = await _contexto.Esp08TipoBases!
                .FirstOrDefaultAsync(x => x.esp08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoespecie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }


            tipoespecie.esp08activo = 0;

            _contexto.Esp08TipoBases!.Update(tipoespecie);


        }

        public async Task ActivateTipoEspecie(int id)
        {

            var tipoespecie = await _contexto.Esp08TipoBases!
                .FirstOrDefaultAsync(x => x.esp08llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (tipoespecie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }


            tipoespecie.esp08activo = 1;

            _contexto.Esp08TipoBases!.Update(tipoespecie);


        }


    }
}
