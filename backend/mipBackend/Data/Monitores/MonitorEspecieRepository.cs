using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MonitorDtos;


using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public class MonitorEspecieRepository : IMonitorEspecieRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MonitorEspecieRepository(
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

        public async Task<DataSourceResult> GetAllMonitorEspecieDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                int filtro = 0;
                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            filtro = Convert.ToInt32(item.Value.ToString());
                        };
                    }

                }


                var query = await (from mnt in db.Mnt01Monitores
                                   join espm in db.Mnt02EspeciesAsignadas! on mnt.mnt01llave equals espm.mnt01llave
                                   join esp2 in db.esp02Temporadaespecies! on espm.esp02llave equals esp2.esp02llave
                                   join tem in db.Temp01Temporadas! on esp2.Temp01llave equals tem.temp01llave
                                   join temb in db.Temp02TemporadaBases! on tem.temp02llave equals temb.temp02llave
                                   join seg in db.Temp03Segmentaciones! on tem.temp03llave equals seg.temp03llave
                                   join esp1 in db.esp01especies! on esp2.esp01llave equals esp1.esp01llave
                                   join esp3 in db.esp03especieBases! on esp1.esp03llave equals esp3.esp03llave
                                   join esp4 in db.esp04EstadoDanios! on esp1.esp04llave equals esp4.esp04llave
                                   join esp8 in db.esp08TipoBases! on esp3.esp08llave equals esp8.esp08llave
                                   where mnt.mnt01llave == filtro && temb.temp02predeterminada == 1



                                   select new MonitorEspecieResponseDto
                                   {

                                       mnt01llave = mnt.mnt01llave,
                                       esp02llave = espm.esp02llave,
                                       esp01llave = esp1.esp01llave,
                                       temp01llave = tem.temp01llave,
                                       esp03llave = esp3.esp03llave,
                                       esp03nombre = esp3.esp03nombre,
                                       esp04llave = esp4.esp04llave,
                                       esp04nombre = esp4.esp04nombre,
                                       esp08llave = esp8.esp08llave,
                                       esp08nombre = esp8.esp08nombre,
                                       temp02llave = temb.temp02llave,
                                       temp02nombre = temb.temp02nombre,

                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }

        public async Task CreateMonitorEspecie(MonitorEspecieRequestDto especieasignada)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            
            var monitorespecies = await _contexto.Mnt02EspeciesAsignadas!
               .FirstOrDefaultAsync(x => x.mnt01llave == especieasignada.mnt01llave
               && x.esp02llave == especieasignada.esp02llave);

            if (monitorespecies == null)
            {

                var newMonitorespecie = new Mnt02EspeciesAsignada();
                newMonitorespecie.mnt01llave = especieasignada.mnt01llave;
                newMonitorespecie.esp02llave = especieasignada.esp02llave;
                
                await _contexto.Mnt02EspeciesAsignadas!.AddAsync(newMonitorespecie);

            }
            else
            {

                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "La especie ya se encuentra registrada para la temporada selecciona" }
                    );


            }


        }

        public async Task DeleteMonitorEspecie(MonitorEspecieRequestDto request)
        {

            var especieasignada = await _contexto.Mnt02EspeciesAsignadas!
                .FirstOrDefaultAsync(x => x.mnt01llave == request.mnt01llave
                                        && x.esp02llave == request.esp02llave);

            _contexto.Mnt02EspeciesAsignadas!.Remove(especieasignada!);

        }

    }
}
