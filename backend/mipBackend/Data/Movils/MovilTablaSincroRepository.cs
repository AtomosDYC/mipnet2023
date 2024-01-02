using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MovilSincroDtos;
using KendoNET.DynamicLinq;
using Microsoft.Data.SqlClient;

using mipBackend.Services.ints;

using KendoNET.DynamicLinq;
using System.Collections;

namespace mipBackend.Data.Movils
{
    public class MovilTablaSincroRepository : IMovilTablaSincroRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MovilTablaSincroRepository(
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


        public async Task<DataSourceResult> GetTablaBaseSincro()
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            try
            {

                using (var db = _contexto)
                {

                    var query = await (from mvl04 in db.Mvl04AliasTablaSincas
                    select new MovilSincroBaseResponseDto
                    {
                        idtabla = mvl04.idtabla,
                        nombretabla = mvl04.nombretabla,
                        aliastabla = mvl04.mvl04aliastabla


                    }).ToListAsync();

                    DataSourceResult resultado = new DataSourceResult();
                    resultado.Total = query.Count();
                    resultado.Data = query;

                    return resultado;
                }

            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }


        public async Task<DataSourceResult> GetTablaSincro(MovilSincroRequestDto request)
        {

            using (var db = _contexto)
            {

                string? nombre_tabla = request.nombre_tabla ;
                DateTime? fecha_consulta = request.fecha_consulta.HasValue ? request.fecha_consulta : null;
                Guid? llave_usuario = request.llave_usuario;
                int? llave_temporada = request.llave_periodo;
                

                Filter filter = new Filter();


                
                DataSourceResult resultado = new DataSourceResult();
                
                switch (nombre_tabla)
                {
                    case "MVL02_TablaSincronizacion":
                        var query_sincro = await _contexto.Mvl02TablaSincronizaciones!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_sincro.Count();
                        resultado.Data = query_sincro;
                        break;

                    case "SIST04_Region":
                        var query_region = await _contexto.sist04Regiones!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_region.Count();
                        resultado.Data = query_region;
                        break;

                    case "SIST03_Comuna":
                        var query_comuna = await _contexto.sist03Comunas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_comuna.Count();
                        resultado.Data = query_comuna;
                        break;

                    case "ESP08_TipoBase":
                        var query_tipobase = await _contexto.esp08TipoBases!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_tipobase.Count();
                        resultado.Data = query_tipobase;
                        break;

                    case "TEMP02_TemporadaBase":
                        var query_temporada = await _contexto.Temp02TemporadaBases!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_temporada.Count();
                        resultado.Data = query_temporada;
                        break;

                    case "ESP06_MedidaUmbral":
                        var query_umbral = await _contexto.esp06MedidaUmbrales!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_umbral.Count();
                        resultado.Data = query_umbral;
                        break;

                    case "ESP03_EspecieBase":
                        var query_especie = await _contexto.esp03especieBases!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_especie.Count();
                        resultado.Data = query_especie;
                        break;

                    case "ESP04_EstadoDanio":
                        var query_danio = await _contexto.esp04EstadoDanios!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_danio.Count();
                        resultado.Data = query_danio;
                        break;

                    case "PER03_TipoPersona":
                        var query_tipopersona = await _contexto.per03Tipopersonas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_tipopersona.Count();
                        resultado.Data = query_tipopersona;
                        break;


                    case "PER01_Persona":
                        var query_persona = await _contexto.per01personas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_persona.Count();
                        resultado.Data = query_persona;
                        break;

                    case "CNT02_TipoCuenta":
                        var query_tipocuenta = await _contexto.cnt02TipoCuentas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_tipocuenta.Count();
                        resultado.Data = query_tipocuenta;
                        break;

                    case "CNT01_CuentaCliente":
                        var query_cliente = await _contexto.cnt01CuentaClientes!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_cliente.Count();
                        resultado.Data = query_cliente;
                        break;

                    case "CNT08_Segmentacion":
                        var query_segmentacion = await _contexto.cnt08Segmentaciones!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_segmentacion.Count();
                        resultado.Data = query_segmentacion;
                        break;

                    case "ESP01_Especies":
                        var query_especies = await _contexto.esp01especies!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_especies.Count();
                        resultado.Data = query_especies;
                        break;

                    case "TRP01_Trampa":
                        var query_trampa = await _contexto.Trp01Trampas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_trampa.Count();
                        resultado.Data = query_trampa;
                        break;

                    case "MNT01_Monitores":
                        var query_monitores = await _contexto.Mnt01Monitores!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_monitores.Count();
                        resultado.Data = query_monitores;
                        break;

                    case "MNT03_PeriodosTrampas":
                        var query_periodostrampa = await _contexto.Mnt03periodosTrampas!
                                    .FromSqlInterpolated($"EXEC pa_mipnet_movil_tablas_sincro_s {nombre_tabla}, {fecha_consulta}, {llave_usuario}, {llave_temporada}")
                                    .ToListAsync();
                        resultado.Total = query_periodostrampa.Count();
                        resultado.Data = query_periodostrampa;
                        break;

                    default:
                        break;
                }

                return resultado;





            }
        }


        public async Task<int> UpdateTablaSincro(MovilUpdateTablaSincroRequestDto request)
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

            string sql = "EXEC pa_mipnet_movil_tablas_sincro_i @llave_usuario, @nombre_tabla";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@llave_usuario", Value = request.llave_usuario , DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@nombre_tabla", Value = request.nombre_tabla, DbType = System.Data.DbType.String },

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return rowsAffected;
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
