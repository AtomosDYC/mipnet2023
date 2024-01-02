using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MonitorDtos;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;

using mipBackend.Services.ints;

using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public class MonitorTrampaRepository : IMonitorTrampaRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        


        public MonitorTrampaRepository(
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

        public async Task<DataSourceResult> GetAllMonitorTrampaDatasource(DataSourceRequest options)
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


                var query = await (from mnt01 in db.Mnt01Monitores
                                   join per01 in db.per01personas! on  mnt01.per01llave equals per01.per01llave
                                   join mnt03 in db.Mnt03periodosTrampas! on mnt01.mnt01llave equals mnt03.mnt01llave
                                   join trp01 in db.Trp01Trampas! on mnt03.trp01llave equals trp01.Trp01llave
                                   join cnt08 in db.cnt08Segmentaciones! on trp01.cnt08llave equals cnt08.cnt08llave
                                   join sist03 in db.sist03Comunas! on cnt08.sist03llave equals sist03.sist03llave
                                   join sist04 in db.sist04Regiones! on sist03.sist04llave equals sist04.sist04llave
                                   join esp01 in db.esp01especies! on trp01.esp01llave equals esp01.esp01llave
                                   join esp03 in db.esp03especieBases! on esp01.esp03llave equals esp03.esp03llave
                                   join esp04 in db.esp04EstadoDanios! on esp01.esp04llave equals esp04.esp04llave
                                   join temp02 in db.Temp02TemporadaBases! on mnt03.temp02llave equals temp02.temp02llave
                                   where mnt01.mnt01llave == filtro && temp02.temp02predeterminada == 1



                                   select new MonitorTrampasResponseDto
                                   {
                                       mnt01llave = mnt01.mnt01llave,
                                       per01llave = per01.per01llave,
                                       per01nombrerazon = per01.per01nombrerazon,
                                       trp01llave = trp01.Trp01llave,
                                       trp01nombre = trp01.Trp01nombre,
                                       cnt08llave = cnt08.cnt01llave,
                                       cnt08nombre = cnt08.cnt08nombre,
                                       esp01llave = esp01.esp01llave,
                                       esp03llave = esp03.esp03llave,
                                       esp03nombre = esp03.esp03nombre,
                                       esp04llave = esp04.esp04llave,
                                       esp04nombre = esp04.esp04nombre,
                                       Temp02llave = temp02.temp02llave,
                                       temp02nombre = temp02.temp02nombre,
                                       mnt03activo = mnt03.mnt03activo,
                                       sist03llave = sist03.sist03llave,
                                       sist03nombre = sist03.sist03nombre,
                                       sist04llave = sist04.sist04llave,
                                       sist04nombre = sist04.sist04nombre


                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }

        public async Task<DataSourceResult> GetAllMonitorTrampaBuscadorDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                int filtro = 0;
                string filtrobusqueda = "";
                Filter filter = new Filter();

                int MNT01_Llave = 18;
                int TEMP02_Llave = 24;
                string MNT03_disponible = "1";
                string SIST04_Llave = null;
                string SIST03_Llave = null;
                string CNT08_Llave = null;
                string ESP03_Llave = null;
                string ESP08_Llave = null;

                if (options.Filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "MNT01_Llave":
                                    MNT01_Llave = Convert.ToInt32(item.Value.ToString());
                                    break;
                                case "TEMP02_Llave":
                                    TEMP02_Llave = Convert.ToInt32(item.Value.ToString());
                                    break;
                            }
                        }
                    }

                }



                var query = (from temporadaBase in db.Temp02TemporadaBases!
                                    join temporada in db.Temp01Temporadas! on temporadaBase.temp02llave equals temporada.temp02llave
                                    join temporadaEspecie in db.esp02Temporadaespecies! on temporada.temp01llave equals temporadaEspecie.Temp01llave
                                    join trampa in db.Trp01Trampas! on temporadaEspecie.esp01llave equals trampa.esp01llave
                                    join especie in db.esp01especies! on trampa.esp01llave equals especie.esp01llave
                                    join especieBase in db.esp03especieBases! on especie.esp03llave equals especieBase.esp03llave
                                    join tipoBase in db.esp08TipoBases! on especieBase.esp08llave equals tipoBase.esp08llave
                                    join estadoDanio in db.esp04EstadoDanios! on especie.esp04llave equals estadoDanio.esp04llave
                                    join segmentacion in db.cnt08Segmentaciones! on trampa.cnt08llave equals segmentacion.cnt08llave
                                    join tipoSegmentacion in db.cnt07TipoSegmentaciones! on segmentacion.cnt07llave equals tipoSegmentacion.cnt07llave
                                    join nivelSegmentacion in db.cnt18NivelSegmentaciones! on tipoSegmentacion.cnt18llave equals nivelSegmentacion.cnt18llave
                                    join comuna in db.sist03Comunas! on segmentacion.sist03llave equals comuna.sist03llave
                                    join region in db.sist04Regiones! on comuna.sist04llave equals region.sist04llave
                                    join cuentaCliente in db.cnt01CuentaClientes! on segmentacion.cnt01llave equals cuentaCliente.cnt01llave
                                    join tipoCuenta in db.cnt02TipoCuentas! on cuentaCliente.cnt02llave equals tipoCuenta.cnt02llave
                                    join persona in db.per01personas! on cuentaCliente.per01llave equals persona.per01llave
                                    join tipoPersona in db.per03Tipopersonas! on persona.per03llave equals tipoPersona.per03llave
                                    join genero in db.per02Generos! on persona.per02llave equals genero.per02llave
                                    where temporadaBase.temp02activo == 1 &&
                                    temporadaBase.temp02predeterminada == 1
                                    where (temporadaBase.temp02llave) == TEMP02_Llave

                             select new 
                                    {
                                        trp01llave = trampa.Trp01llave,
                                        trp01nombre =  trampa.Trp01nombre,
                                        esp01llave = especie.esp01llave,
                                        esp03llave = especieBase.esp03llave,
                                        esp03nombre = especieBase.esp03nombre,
                                        esp08llave = tipoBase.esp08llave,
                                        esp08nombre = tipoBase.esp08nombre,
                                        esp04llave = estadoDanio.esp04llave,
                                        esp04nombre = estadoDanio.esp04nombre,
                                        cnt08llave = segmentacion.cnt08llave,
                                        cnt01llave = segmentacion.cnt01llave,
                                        cnt08nombre =  segmentacion.cnt08nombre,
                                        sist03llave =  segmentacion.sist03llave,
                                        sist03nombre = comuna.sist03nombre,
                                        sist04llave = region.sist04llave,
                                        sist04nombre = region.sist04nombre,
                                        per01llave = persona.per01llave,
                                        temp02llave = temporadaBase.temp02llave,
                                        temp02nombre = temporadaBase.temp02nombre,
                                        usuario = (from mnt in db.Mnt03periodosTrampas!
                                                   join mn in db.Mnt01Monitores! on mnt.mnt01llave equals mn.mnt01llave
                                                   join per in db.per01personas! on mn.per01llave equals per.per01llave
                                                   where mnt.trp01llave == trampa.Trp01llave
                                                   where mnt.temp02llave == temporadaBase.temp02llave
                                                   select per.per01nombrerazon)

                             }).Distinct();

              
               


                return await query.ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                

            }
        }

        public async Task<DataSourceResult> GetAllMonitorTrampaBuscadorDatasourceRaw(DataSourceRequest options)
        {

            using (var db = _contexto)
            {

                int? MNT01_Llave = 18;
                int? TEMP02_Llave = 24;
                int? MNT03_disponible = 1;
                int? SIST04_Llave = null;
                int? SIST03_Llave = null;
                int? CNT08_Llave = null;
                int? ESP03_Llave = null;
                int? ESP08_Llave = null;


                if (options.Filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "MNT01_Llave":
                                    MNT01_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "TEMP02_Llave":
                                    TEMP02_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "MNT03_disponible":
                                    MNT03_disponible = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "SIST04_Llave":
                                    SIST04_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "SIST03_Llave":
                                    SIST03_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "CNT08_Llave":
                                    CNT08_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "ESP03_Llave":
                                    ESP03_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                                case "ESP08_Llave":
                                    ESP08_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                            }
                        }
                    }
                }



                Filter filter = new Filter();

                    var query = await _contexto.MonitorTrampaBuscarResponse!
                        .FromSqlInterpolated($"EXEC pa_mipnet_Monitores_AsignarTrampas_Obtener_s {MNT01_Llave}, {TEMP02_Llave}, {MNT03_disponible}, {SIST04_Llave}, {SIST03_Llave}, {CNT08_Llave}, {ESP03_Llave}, {ESP08_Llave}")
                  .ToListAsync();

                DataSourceResult resultado = new DataSourceResult();
                resultado.Total = query.Count();
                resultado.Data = query.Skip(options.Skip).Take(options.Take);
                
                

                return resultado;



            }
        }

        public async Task<int> asignarTrampas(MonitorAsignarTrampaRequestDto request) {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            int rowsAffected;
            int outputparam = 0;

            string sql = "EXEC pa_mipnet_Monitores_AsignarTrampas_i @MNT01_Llave, @TRP01_Llave, @TEMP02_Llave, @MNT03_Activo, " +
                "@USUARIO_ID";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@MNT01_Llave", Value = request.mnt01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@TRP01_Llave", Value = request.trp01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@TEMP02_Llave", Value = request.temp02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MNT03_Activo", Value = 1, DbType = System.Data.DbType.Int32},
                    new SqlParameter { ParameterName = "@USUARIO_ID", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    
                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return rowsAffected!;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }

        public async Task<int> replicarTrampas(int mnt01llave)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            int rowsAffected;
            int outputparam = 0;

            string sql = "EXEC pa_mipnet_Monitores_replicartemporada_i @MNT01_Llave, @USUARIO_ID";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@MNT01_Llave", Value = mnt01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@USUARIO_ID", Value = usuario.Id, DbType = System.Data.DbType.Guid },

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return rowsAffected!;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }
    }
}
