using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;
using KendoNET.DynamicLinq;

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



        public async Task<DataSourceResult> GetAllTemporadaBase(DataSourceRequest requestModel)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
            string quecontenga = "";


            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            using (var db = _contexto)
            {

                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = requestModel.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            quecontenga = item.Value.ToString();
                        };
                    }
                }

                var query = await (from temp2 in db.Temp02TemporadaBases!

                                   where temp2.temp02nombre!.Contains(quecontenga)
                                   orderby temp2.temp02nombre

                                   select new TemporadaBaseResponseDto
                                   {

                                       temp02llave = temp2.temp02llave,
                                       temp02nombre = temp2.temp02nombre,
                                       temp02descripcion = temp2.temp02descripcion,
                                       temp02predeterminada = temp2.temp02predeterminada,
                                       temp02activo = temp2.temp02activo


                                   }).ToDataSourceResultAsync(requestModel.Take, requestModel.Skip, requestModel.Sort, filter);





                return query;
            }
        }

        public async Task<Temp02TemporadaBase> GetTemporadaBaseById(int id)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
            string quecontenga = "";


            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            using (var db = _contexto)
            {

                var query = await (from temp2 in db.Temp02TemporadaBases!

                                   where temp2.temp02llave == id
                                   orderby temp2.temp02nombre

                                   select new Temp02TemporadaBase
                                   {

                                       temp02llave = temp2.temp02llave,
                                       temp02nombre = temp2.temp02nombre,
                                       temp02descripcion = temp2.temp02descripcion,
                                       temp02predeterminada = temp2.temp02predeterminada,
                                       temp02activo = temp2.temp02activo


                                   }).FirstAsync();





                return query;
            }
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

        public async Task DeleteTemporadaBase(int id)
        {

            var TemporadaBase = await _contexto.Temp02TemporadaBases!
                .FirstOrDefaultAsync(x => x.temp02llave == id);


            if (TemporadaBase.temp02activo == 0)
            {

                _contexto.Temp02TemporadaBases!.Remove(TemporadaBase!);

            }
            else
            {
                await DisableTemporadaBase(id);
            }

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
