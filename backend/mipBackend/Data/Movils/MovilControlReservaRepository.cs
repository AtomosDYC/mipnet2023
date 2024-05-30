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
    public class MovilControlReservaRepository : IMovilControlReservaRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MovilControlReservaRepository(
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

        public async Task<IEnumerable<MovilControlReservaResponseDto>> listar_control_reserva(MovilControlReservaRequestDto request)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }


            string sql = "EXEC pa_mipnet_control_reserva_s @conteo05_llave, @conteo05_tabla_control, @conteo05_columna_control, @conteo05_valor_control, @id_movil, @id_usuario, @conteo05_estado_control, @conteo05_estado, @conteo05_primer, @conteo05_segundo, @conteo05_tercer, @conteo05_fecha";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@conteo05_llave", Value = request.conteo05_llave.HasValue ? request.conteo05_llave.HasValue : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@conteo05_tabla_control", Value = string.IsNullOrEmpty(request.conteo05_tabla_control) ? DBNull.Value : request.conteo05_tabla_control, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@conteo05_columna_control", Value = string.IsNullOrEmpty(request.conteo05_columna_control) ? DBNull.Value : request.conteo05_columna_control, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@conteo05_valor_control", Value = request.conteo05_valor_control.HasValue ? request.conteo05_valor_control : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@id_movil", Value = request.id_movil.HasValue ? request.id_movil : DBNull.Value, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@id_usuario", Value = request.id_usuario.HasValue ? request.id_usuario : DBNull.Value, DbType = System.Data.DbType.Guid},
                    new SqlParameter { ParameterName = "@conteo05_estado_control", Value = request.conteo05_estado_control.HasValue ? request.conteo05_estado_control : DBNull.Value , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@conteo05_estado", Value = request.conteo05_estado == null ? DBNull.Value :request.conteo05_estado, DbType = System.Data.DbType.Boolean },
                    new SqlParameter { ParameterName = "@conteo05_primer", Value = string.IsNullOrEmpty(request.conteo05_primer) ? DBNull.Value : request.conteo05_primer, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@conteo05_segundo", Value = string.IsNullOrEmpty(request.conteo05_segundo) ? DBNull.Value : request.conteo05_segundo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@conteo05_tercer", Value = string.IsNullOrEmpty(request.conteo05_tercer) ? DBNull.Value : request.conteo05_tercer, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@conteo05_fecha", Value = request.conteo05_fecha.HasValue ? request.conteo05_fecha : DBNull.Value, DbType = System.Data.DbType.DateTime }, 

                };

            try
            {

                var query = await _contexto.MovilControlReservaResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                return query;

            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }
        }


        public async Task<Int32> mantenimiento_control_reserva(MovilControlReservaRequestDto request)
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

            string sql = "EXEC pa_mipnet_control_reserva_iu @CONTEO05_Llave, @CONTEO05_tabla_control, @CONTEO05_columna_control, @CONTEO05_valor_control, " +
                "@id_movil, @id_usuario, @CONTEO05_estado_control, @CONTEO05_Estado, @CONTEO05_primer, @CONTEO05_segundo, @CONTEO05_tercer, @CONTEO05_fecha, @LLAVE_REGISTRO out";
            DateTime? fechaingreso = null;
            if (request.conteo05_fecha.ToString() != "01/01/0001 0:00:00")
            {
                fechaingreso = request.conteo05_fecha;
            }

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CONTEO05_Llave", Value =  request.conteo05_llave.HasValue ? request.conteo05_llave : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CONTEO05_tabla_control", Value = String.IsNullOrEmpty(request.conteo05_tabla_control) ? DBNull.Value : request.conteo05_tabla_control , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO05_columna_control", Value = String.IsNullOrEmpty(request.conteo05_columna_control) ? DBNull.Value :  request.conteo05_columna_control, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO05_valor_control", Value = request.conteo05_valor_control.HasValue ? request.conteo05_valor_control : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@id_movil", Value = request.id_movil.HasValue ? request.id_movil : DBNull.Value, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@id_usuario", Value = request.id_usuario.HasValue ? request.id_usuario : DBNull.Value, DbType = System.Data.DbType.Guid },

                    new SqlParameter { ParameterName = "@CONTEO05_estado_control", Value = request.conteo05_estado_control.HasValue ? request.conteo05_estado_control : DBNull.Value , DbType = System.Data.DbType.Int32},
                    new SqlParameter { ParameterName = "@CONTEO05_Estado", Value = String.IsNullOrEmpty(request.conteo05_estado.ToString()) ? DBNull.Value : request.conteo05_estado , DbType = System.Data.DbType.Boolean },
                    new SqlParameter { ParameterName = "@CONTEO05_primer", Value = String.IsNullOrEmpty(request.conteo05_primer) ? DBNull.Value : request.conteo05_primer , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO05_segundo", Value = String.IsNullOrEmpty(request.conteo05_segundo) ? DBNull.Value :   request.conteo05_segundo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO05_tercer", Value = String.IsNullOrEmpty(request.conteo05_tercer) ? DBNull.Value :   request.conteo05_tercer, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@CONTEO05_fecha", Value = request.conteo05_fecha.HasValue ? request.conteo05_fecha : DBNull.Value , DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@LLAVE_REGISTRO", Value = rowretuned, DbType = System.Data.DbType.Int32, Direction = System.Data.ParameterDirection.Output },


                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                if (rowsAffected > 0)
                {
                    obx_return = Int32.Parse(parms[12].Value.ToString()!);
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


        public async Task<Int32?> existe_llave_control_reserva(MovilControlReservaExisteRequestDto request)
        {

            Int32? returnedvalue = 0;

            MovilControlReservaRequestDto requestmodel = new MovilControlReservaRequestDto();
            requestmodel.conteo05_tabla_control = request.conteo05_tabla_control;
            requestmodel.conteo05_fecha = request.conteo05_fecha;
            requestmodel.conteo05_columna_control = request.conteo05_columna_control;
            requestmodel.conteo05_estado_control = request.conteo05_estado_control;
            requestmodel.conteo05_estado = request.conteo05_estado;
            requestmodel.conteo05_primer = request.conteo05_primer;
            requestmodel.conteo05_segundo = request.conteo05_segundo;
            requestmodel.conteo05_tercer = request.conteo05_tercer; 
            requestmodel.id_movil = request.id_movil;
            requestmodel.id_usuario = request.id_usuario;

            IEnumerable<MovilControlReservaResponseDto> returnmodel = await listar_control_reserva(requestmodel);

            if (returnmodel != null)
            {
                foreach (MovilControlReservaResponseDto item in returnmodel!)
                {
                    returnedvalue = item.conteo05_llave;
                }
            }

            return returnedvalue;

        }


        public async Task<bool> insertar_control_reserva(MovilControlReservaInsertarRequestDto request) 
        {
            bool returnedvalue = false;

            MovilControlReservaRequestDto model = new MovilControlReservaRequestDto();
            model.conteo05_tabla_control = request.conteo05_tabla_control;
            model.conteo05_columna_control = request.conteo05_columna_control;
            model.conteo05_valor_control = request.conteo05_valor_control;
            model.id_movil = request.id_movil;
            model.id_usuario = request.id_usuario;
            model.conteo05_estado_control = request.conteo05_estado_control;
            model.conteo05_primer = request.conteo05_primer;
            model.conteo05_segundo = request.conteo05_segundo;
            model.conteo05_tercer = request.conteo05_tercer;
            model.conteo05_fecha = request.conteo05_fecha;

            Int32? returned = await mantenimiento_control_reserva(model);
            if (returned.HasValue)
            {
                returnedvalue = true;
            }

            return returnedvalue;
        }

    }
}
