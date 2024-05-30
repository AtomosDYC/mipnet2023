using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MovilDtos;
using KendoNET.DynamicLinq;
using Microsoft.Data.SqlClient;
using mipBackend.Services;
using mipBackend.Services.ints;

namespace mipBackend.Data.Movils
{
    public class MovilMonitoreoRepository : IMovilMonitoreoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MovilMonitoreoRepository(
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

        public async Task<Int32> mantenimiento_monitoreo(MovilMonitoreoRequestDto request)
        {
            Int32 obx_return = 0;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            int rowsAffected;
            Int32 rowretuned = 0;
            var obx_fechaahora = FDate.DateToString(DateTime.Now); 

            string sql = "EXEC pa_mipnet_movil_conteo_reserva_iu @CONTEO01_Llave, @TRP01_Llave, @CONTEO01_Valor, @CONTEO01_FechaIngreso, @CONTEO01_HoraIngreso, @CONTEO01_EstadoVisado," +
                " @CONTEO01_x, @CONTEO01_y, @CONTEO01_observacion, @CONTEO01_EstadoConteo, @CONTEO01_TipoSistema, @TEMP02_Llave, @MVL01_Llave, @FECHAACTUALIZACION, @CREATE_BY, @LLAVE_REGISTRO out";
            DateTime? fechaingreso = null;
            if(request.CONTEO01_FechaIngreso.ToString() != "01/01/0001 0:00:00")
            {
                fechaingreso = request.CONTEO01_FechaIngreso;
            }

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CONTEO01_Llave", Value =  String.IsNullOrEmpty(request.CONTEO01_Llave.ToString()) ? DBNull.Value :  request.CONTEO01_Llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@TRP01_Llave", Value = String.IsNullOrEmpty(request.TRP01_Llave.ToString()) ? DBNull.Value : request.TRP01_Llave , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CONTEO01_Valor", Value = String.IsNullOrEmpty(request.CONTEO01_Valor.ToString()) ? DBNull.Value :  request.CONTEO01_Valor, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CONTEO01_FechaIngreso", Value = fechaingreso.HasValue ? fechaingreso : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@CONTEO01_HoraIngreso", Value = fechaingreso.HasValue ? fechaingreso : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@CONTEO01_EstadoVisado", Value = String.IsNullOrEmpty(request.CONTEO01_EstadoVisado.ToString()) ? DBNull.Value : request.CONTEO01_EstadoVisado, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CONTEO01_x", Value = String.IsNullOrEmpty(request.CONTEO01_x) ? DBNull.Value : request.CONTEO01_x , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO01_y", Value = String.IsNullOrEmpty(request.CONTEO01_y) ? DBNull.Value : request.CONTEO01_y , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO01_observacion", Value = String.IsNullOrEmpty(request.CONTEO01_observacion) ? DBNull.Value : request.CONTEO01_observacion , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO01_EstadoConteo", Value = String.IsNullOrEmpty(request.CONTEO01_EstadoConteo.ToString()) ? DBNull.Value : request.CONTEO01_EstadoConteo , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CONTEO01_TipoSistema", Value = String.IsNullOrEmpty(request.CONTEO01_TipoSistema.ToString()) ? DBNull.Value : request.CONTEO01_TipoSistema , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@TEMP02_Llave", Value = String.IsNullOrEmpty(request.TEMP02_Llave.ToString()) ? DBNull.Value : request.TEMP02_Llave , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MVL01_Llave", Value = request.MVL01_Llave.HasValue ? request.MVL01_Llave : DBNull.Value , DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@FECHAACTUALIZACION", Value = obx_fechaahora, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@CREATE_BY", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@LLAVE_REGISTRO", Value = rowretuned, DbType = System.Data.DbType.Int32, Direction = System.Data.ParameterDirection.Output },
                    

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                if (rowsAffected > 0)
                {
                    obx_return = Int32.Parse(parms[15].Value.ToString()!);
                }
                return obx_return;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }

        public async Task<Int32> reservar_registro_monitoreo() 
        {

            Int32 obx_return = 0;
            MovilMonitoreoRequestDto request = new MovilMonitoreoRequestDto();

            obx_return = await mantenimiento_monitoreo(request);

            return obx_return;

        }

        public async Task<bool> actualizar_registro_monitoreo(MovilMonitoreoActualizarRequest requestapdate) 
        {

            bool obx_return = false;
            MovilMonitoreoRequestDto request = new MovilMonitoreoRequestDto();
            request.CONTEO01_Llave = requestapdate.CONTEO01_Llave;
            request.TRP01_Llave = requestapdate.TRP01_Llave;
            request.CONTEO01_Valor = requestapdate.CONTEO01_Valor;
            request.CONTEO01_FechaIngreso = requestapdate.CONTEO01_FechaIngreso;
            request.CONTEO01_HoraIngreso = requestapdate.CONTEO01_HoraIngreso;
            request.CONTEO01_EstadoVisado = requestapdate.CONTEO01_EstadoVisado;
            request.CONTEO01_x = requestapdate.CONTEO01_x;
            request.CONTEO01_y = requestapdate.CONTEO01_y;
            request.CONTEO01_observacion = requestapdate.CONTEO01_observacion;
            request.CONTEO01_EstadoConteo = requestapdate.CONTEO01_EstadoConteo;
            request.CONTEO01_TipoSistema = requestapdate.CONTEO01_TipoSistema;
            request.TEMP02_Llave = requestapdate.TEMP02_Llave;
            request.MVL01_Llave = requestapdate.MVL01_Llave;




            Int32? returned = await mantenimiento_monitoreo(request);
            if (returned.HasValue)
            {
                obx_return = true;
            }

            return obx_return;

        }

    }
}
