using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;

namespace mipBackend.Data.Temporada
{
    public class TemporadaBaseRepository : ITemporadaBaseRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public TemporadaBaseRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateTemporadaBase(Temp02TemporadaBase TemporadaBase)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (TemporadaBase is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            TemporadaBase.fechaactivacion = DateTime.Now;
            TemporadaBase.createby = usuario.Id;
            TemporadaBase.temp02activo = 1;

            await _contexto.Temp02TemporadaBases!.AddAsync(TemporadaBase);

        }

        public async Task DeleteTemporadaBase(int id)
        {

            var TemporadaBase = await _contexto.Temp02TemporadaBases!
                .FirstOrDefaultAsync(x => x.temp02llave == id);

            _contexto.Temp02TemporadaBases!.Remove(TemporadaBase!);
        }

        public async Task<IEnumerable<Temp02TemporadaBase>> GetAllTemporadaBase()
        {
            return await _contexto.Temp02TemporadaBases!.ToListAsync();
        }

        public async Task<Temp02TemporadaBase> GetTemporadaBaseById(int id)
        {
            return await _contexto.Temp02TemporadaBases!.FirstOrDefaultAsync(x => x.temp02llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTemporadaBase(Temp02TemporadaBase request)
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

            var TemporadaBase = await _contexto.Temp02TemporadaBases!
                .FirstOrDefaultAsync(x => x.temp02llave == request.temp02llave);

            TemporadaBase.fechaactualizacion = DateTime.Now;
            TemporadaBase.approveby = usuario.Id;
            TemporadaBase.temp02nombre = request.temp02nombre;
            TemporadaBase.temp02descripcion = request.temp02descripcion;
            TemporadaBase.temp02predeterminada = request.temp02predeterminada;



            _contexto.Temp02TemporadaBases!.Update(TemporadaBase!);

        }

        public async Task DisableTemporadaBase(int id)
        {

            var TemporadaBase = await _contexto.Temp02TemporadaBases!
                .FirstOrDefaultAsync(x => x.temp02llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TemporadaBase is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TemporadaBase no existe en los listados" }
                   );
            }


            TemporadaBase.temp02activo = 0;

            _contexto.Temp02TemporadaBases!.Update(TemporadaBase);


        }

        public async Task ActivateTemporadaBase(int id)
        {

            var TemporadaBase = await _contexto.Temp02TemporadaBases!
                .FirstOrDefaultAsync(x => x.temp02llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (TemporadaBase is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La TemporadaBase no existe en los listados" }
                   );
            }


            TemporadaBase.temp02activo = 1;

            _contexto.Temp02TemporadaBases!.Update(TemporadaBase);

        }

    }
}
