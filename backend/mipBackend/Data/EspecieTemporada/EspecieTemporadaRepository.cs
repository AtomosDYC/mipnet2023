using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.EspecieTemporadaDtos;

using KendoNET.DynamicLinq;

namespace mipBackend.Data.EspecieTemporada
{
    public class EspecieTemporadaRepository : IEspecietemporadaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public EspecieTemporadaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager,
             IMapper mapper)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task<DataSourceResult> GetAllEspecieTemporadaDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                string filtro = "";
                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            filtro = item.Value.ToString();
                        };
                    }

                }

                var query = await (from esp2 in db.esp02Temporadaespecies
                                   join esp1 in db.esp01especies! on esp2.esp01llave equals esp1.esp01llave
                                   join esp3 in db.esp03especieBases! on esp1.esp03llave equals esp3.esp03llave
                                   join esp4 in db.esp04EstadoDanios! on esp1.esp04llave equals esp4.esp04llave
                                   join esp8 in db.esp08TipoBases! on esp3.esp08llave equals esp8.esp08llave
                                   join temp1 in db.Temp01Temporadas! on esp2.Temp01llave equals temp1.temp01llave
                                   join temp2 in db.Temp02TemporadaBases! on temp1.temp02llave equals temp2.temp02llave

                                   where esp3.esp03nombre!.Contains(filtro)
                                   orderby temp2.temp02llave descending, esp3.esp03nombre

                                   select new EspecieTemporadaResponseDto
                                   {

                                       esp02llave = esp2.esp02llave,
                                       esp01llave = esp1.esp01llave,
                                       esp03llave = esp3.esp03llave,
                                       esp03nombre = esp3.esp03nombre,
                                       esp04llave = esp4.esp04llave,
                                       esp04nombre = esp4.esp04nombre,
                                       esp08llave = esp8.esp08llave,
                                       esp08nombre = esp8.esp08nombre,
                                       temp01llave = temp1.temp01llave,
                                       temp02llave = temp2.temp02llave,
                                       temp02nombre = temp2.temp02nombre,
                                       esp02iniciotemporada = esp2.esp02InicioTemporada,
                                       esp02terminotemporada = esp2.esp02TerminoTemporada,
                                       esp02sag = esp2.esp02Sag,
                                       esp02mexico = esp2.esp02Mexico,
                                       esp02activo = esp2.esp02activo


                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }

        public async Task<EspecieTemporadaResponseDto> GetEspecieTemporadaById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from esp2 in db.esp02Temporadaespecies
                                   join esp1 in db.esp01especies! on esp2.esp01llave equals esp1.esp01llave
                                   join esp3 in db.esp03especieBases! on esp1.esp03llave equals esp3.esp03llave
                                   join esp4 in db.esp04EstadoDanios! on esp1.esp04llave equals esp4.esp04llave
                                   join esp8 in db.esp08TipoBases! on esp3.esp08llave equals esp8.esp08llave
                                   join temp1 in db.Temp01Temporadas! on esp2.Temp01llave equals temp1.temp01llave
                                   join temp2 in db.Temp02TemporadaBases! on temp1.temp02llave equals temp2.temp02llave

                                   where esp2.esp02llave! == (id)

                                   select new EspecieTemporadaResponseDto
                                   {

                                       esp02llave = esp2.esp02llave,
                                       esp01llave = esp1.esp01llave,
                                       esp03llave = esp3.esp03llave,
                                       esp03nombre = esp3.esp03nombre,
                                       esp04llave = esp4.esp04llave,
                                       esp04nombre = esp4.esp04nombre,
                                       esp08llave = esp8.esp08llave,
                                       esp08nombre = esp8.esp08nombre,
                                       temp01llave = temp1.temp01llave,
                                       temp02llave = temp2.temp02llave,
                                       temp02nombre = temp2.temp02nombre,
                                       esp02iniciotemporada = esp2.esp02InicioTemporada,
                                       esp02terminotemporada = esp2.esp02TerminoTemporada,
                                       esp02sag = esp2.esp02Sag,
                                       esp02mexico = esp2.esp02Mexico,
                                       esp02activo = esp2.esp02activo



                                   }).FirstOrDefaultAsync();

                return query;
            }
        }

        public async Task Create(esp02Temporadaespecie request)
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
                   new { mensaje = "La temporada de especie no es valida para hacer esta insercion" }
                   );
            }

            request.fechaactualizacion = DateTime.Now;
            request.createby = usuario.Id;
            request.esp02activo = 1;

            await _contexto.esp02Temporadaespecies!.AddAsync(request);


        }

        public async Task Update(EspecieTemporadaResponseDto request)
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

            var EspecieTemporada = await _contexto.esp02Temporadaespecies
                .FirstOrDefaultAsync(x => x.esp02llave == request.esp02llave);

            EspecieTemporada.esp02llave = request.esp02llave; 
            EspecieTemporada.esp01llave = request.esp01llave;
            EspecieTemporada.Temp01llave = request.temp01llave;
            EspecieTemporada.esp02InicioTemporada = request.esp02iniciotemporada;
            EspecieTemporada.esp02TerminoTemporada = request.esp02terminotemporada;
            EspecieTemporada.esp02Sag = request.esp02sag;
            EspecieTemporada.esp02Mexico = request.esp02mexico;

            EspecieTemporada.fechaactivacion = DateTime.Now;
            EspecieTemporada.createby = usuario.Id;
            EspecieTemporada.esp02activo = 1;

            _contexto.esp02Temporadaespecies!.Update(EspecieTemporada);

        }

        public async Task Delete(int id)
        {

            var Temporadadto = await _contexto.esp02Temporadaespecies!
               .FirstOrDefaultAsync(x => x.esp02llave == id);

            if (Temporadadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Temporada por este id {id}" }
                );
            }
            else
            {
                if (Temporadadto.esp02activo == 0)
                {
                    _contexto.esp02Temporadaespecies!.Remove(Temporadadto!);
                }
                else
                {
                    Temporadadto.esp02activo = 0;
                    _contexto.esp02Temporadaespecies!.Update(Temporadadto);
                }
            }

           
           

        }

        public async Task Disable(int id)
        {


            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            var EspecieTemporada = await _contexto.esp02Temporadaespecies!
                .FirstOrDefaultAsync(x => x.esp02llave == id);

            if (EspecieTemporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Temporada no existe en los listados" }
                   );
            }


            EspecieTemporada.esp02activo = 0;

            _contexto.esp02Temporadaespecies!.Update(EspecieTemporada);

        }

        public async Task Activate(int id)
        {

            var EspecieTemporada = await _contexto.esp02Temporadaespecies!
                .FirstOrDefaultAsync(x => x.esp02llave== id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (EspecieTemporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Temporada no existe en los listados" }
                   );
            }

            EspecieTemporada.esp02activo = 1;

            _contexto.esp02Temporadaespecies!.Update(EspecieTemporada);

        }

    }
}
