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

namespace mipBackend.Data.Movils
{
    public class MovilAccesoRepository : IMovilAccesoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MovilAccesoRepository(
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

        public async Task<DataSourceResult> GetMonitorMovilAcceso(DataSourceRequest options)
        {

            using (var db = _contexto)
            {

                Guid? id_movil = null;
                Guid? id_usuario = null;
                string? numero_movil = null;
                string? sistema_operativo = null;
                string? version_sistema = null ;
                string? version_aplicacion = null;
                Boolean? esta_bloqueado = null;
                DateTime? fecha_mensaje_desde = null;
                DateTime? fecha_mensaje_hasta = null;
                DateTime? fecha_registro_desde = null;
                DateTime? fecha_registro_hasta = null;
                DateTime? fecha_ultimo_acceso_desde = null;
                DateTime? fecha_ultimo_acceso_hasta = null;
                DateTime? fecha_ultima_actividad_desde = null;
                DateTime? fecha_ultima_actividad_hasta = null;
                DateTime? fecha_ultima_sincro_desde = null;
                DateTime? fecha_ultima_sincro_hasta = null;


                if (options.Filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "id_movil":
                                    id_movil = Guid.Parse(item.Value.ToString());
                                    break;
                                case "id_usuario":
                                    id_usuario = Guid.Parse(item.Value.ToString());
                                    break;
                                case "numero_movil":
                                    numero_movil = item.Value.ToString();
                                    break;
                                case "sistema_operativo":
                                    sistema_operativo = item.Value.ToString();
                                    break;
                                case "version_sistema":
                                    version_sistema = item.Value.ToString();
                                    break;
                                case "version_aplicacion":
                                    version_aplicacion = item.Value.ToString();
                                    break;
                                case "esta_bloqueado":
                                    esta_bloqueado = Boolean.Parse(item.Value.ToString());
                                    break;
                                case "fecha_mensaje_desde":
                                    fecha_mensaje_desde = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_mensaje_hasta":
                                    fecha_mensaje_hasta = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_registro_desde":
                                    fecha_registro_desde = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_registro_hasta":
                                    fecha_registro_hasta = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultimo_acceso_desde":
                                    fecha_ultimo_acceso_desde = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultimo_acceso_hasta":
                                    fecha_ultimo_acceso_hasta = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultima_actividad_desde":
                                    fecha_ultima_actividad_desde = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultima_actividad_hasta":
                                    fecha_ultima_actividad_hasta = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultima_sincro_desde":
                                    fecha_ultima_sincro_desde = DateTime.Parse(item.Value.ToString());
                                    break;
                                case "fecha_ultima_sincro_hasta":
                                    fecha_ultima_sincro_hasta = DateTime.Parse(item.Value.ToString());
                                    break;
                                default:
                                    break;


                            }
                        }
                    }
                }

             Filter filter = new Filter();

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@id_movil", Value = id_movil.HasValue ? id_movil : DBNull.Value, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@id_usuario", Value = id_usuario.HasValue ? id_usuario : DBNull.Value , DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@numero_movil", Value = string.IsNullOrEmpty(numero_movil) ? DBNull.Value : numero_movil , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@sistema_operativo", Value = string.IsNullOrEmpty(sistema_operativo) ? DBNull.Value : sistema_operativo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@version_sistema", Value = string.IsNullOrEmpty(version_sistema) ? DBNull.Value : version_sistema, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@version_aplicacion", Value = string.IsNullOrEmpty(version_aplicacion) ? DBNull.Value :  version_aplicacion, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@fecha_mensaje_desde", Value = fecha_mensaje_desde.HasValue ? fecha_mensaje_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_mensaje_hasta", Value = fecha_mensaje_hasta.HasValue ? fecha_mensaje_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_registro_desde", Value = fecha_registro_desde.HasValue ? fecha_registro_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_registro_hasta", Value = fecha_registro_hasta.HasValue ? fecha_registro_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultimo_acceso_desde", Value = fecha_ultimo_acceso_desde.HasValue ? fecha_ultimo_acceso_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultimo_acceso_hasta", Value = fecha_ultimo_acceso_hasta.HasValue ? fecha_ultimo_acceso_hasta :DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_actividad_desde", Value = fecha_ultima_actividad_desde.HasValue ? fecha_ultima_actividad_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_actividad_hasta", Value = fecha_ultima_actividad_hasta.HasValue ? fecha_ultima_actividad_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_sincro_desde", Value = fecha_ultima_sincro_desde.HasValue ? fecha_ultima_sincro_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_sincro_hasta", Value = fecha_ultima_sincro_hasta.HasValue ? fecha_ultima_sincro_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },

                };


                var sql = "EXEC pa_mipnet_movil_acceso_s @id_movil, @id_usuario, @numero_movil, @sistema_operativo, @version_sistema, @version_aplicacion, @fecha_mensaje_desde, @fecha_mensaje_hasta, @fecha_registro_desde, @fecha_registro_hasta, @fecha_ultimo_acceso_desde, @fecha_ultimo_acceso_hasta, @fecha_ultima_actividad_desde, @fecha_ultima_actividad_hasta, @fecha_ultima_sincro_desde, @fecha_ultima_sincro_hasta";
                var query = await _contexto.MovilAccesoResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                DataSourceResult resultado = new DataSourceResult();
                resultado.Total = query.Count();
                resultado.Data = query.Skip(options.Skip).Take(options.Take);

                return resultado;

            }



        }

        public async Task<IEnumerable<MovilAccesoResponseDto>> listMovilAcceso(MovilAccesoRequestDto request) 
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create  parameter(s)    
                    new SqlParameter { ParameterName = "@id_movil", Value = request.id_movil.HasValue ? request.id_movil : DBNull.Value, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@id_usuario", Value = request.id_usuario.HasValue ? request.id_usuario : DBNull.Value , DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@numero_movil", Value = string.IsNullOrEmpty(request.numero_movil) ? DBNull.Value : request.numero_movil , DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@sistema_operativo", Value = string.IsNullOrEmpty(request.sistema_operativo) ? DBNull.Value : request.sistema_operativo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@version_sistema", Value = string.IsNullOrEmpty(request.version_sistema) ? DBNull.Value : request.version_sistema, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@version_aplicacion", Value = string.IsNullOrEmpty(request.version_aplicacion) ? DBNull.Value :  request.version_aplicacion, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@fecha_mensaje_desde", Value = request.fecha_mensaje_desde.HasValue ? request.fecha_mensaje_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_mensaje_hasta", Value = request.fecha_mensaje_hasta.HasValue ? request.fecha_mensaje_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_registro_desde", Value = request.fecha_registro_desde.HasValue ? request.fecha_registro_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_registro_hasta", Value = request.fecha_registro_hasta.HasValue ? request.fecha_registro_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultimo_acceso_desde", Value = request.fecha_ultimo_acceso_desde.HasValue ? request.fecha_ultimo_acceso_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultimo_acceso_hasta", Value = request.fecha_ultimo_acceso_hasta.HasValue ? request.fecha_ultimo_acceso_hasta :DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_actividad_desde", Value = request.fecha_ultima_actividad_desde.HasValue ? request.fecha_ultima_actividad_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_actividad_hasta", Value = request.fecha_ultima_actividad_hasta.HasValue ? request.fecha_ultima_actividad_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_sincro_desde", Value = request.fecha_ultima_sincro_desde.HasValue ? request.fecha_ultima_sincro_desde : DBNull.Value, DbType = System.Data.DbType.DateTime },
                    new SqlParameter { ParameterName = "@fecha_ultima_sincro_hasta", Value = request.fecha_ultima_sincro_hasta.HasValue ? request.fecha_ultima_sincro_hasta : DBNull.Value, DbType = System.Data.DbType.DateTime },

                };


            var sql = "EXEC pa_mipnet_movil_acceso_s @id_movil, @id_usuario, @numero_movil, @sistema_operativo, @version_sistema, @version_aplicacion, @fecha_mensaje_desde, @fecha_mensaje_hasta, @fecha_registro_desde, @fecha_registro_hasta, @fecha_ultimo_acceso_desde, @fecha_ultimo_acceso_hasta, @fecha_ultima_actividad_desde, @fecha_ultima_actividad_hasta, @fecha_ultima_sincro_desde, @fecha_ultima_sincro_hasta";
            IEnumerable<MovilAccesoResponseDto> query = await _contexto.MovilAccesoResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

            return query;

        }

        public async Task CreateMonitorMovilAcceso(MovilAccesoCreateRequestDto request)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            var existe_usuario = await _userManager.FindByNameAsync(request.id_usuario.ToString());

            if (existe_usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario ingresado no es valido" }
                    );
            }

            var acceso = await _contexto.Mvl01AccesoMoviles!.FirstOrDefaultAsync(x => x.Mvl01IdUsuario == request.id_usuario! &&  x.Mvl01llave == request.id_movil);

            if (acceso == null)
            {

                var newAcceso = new Mvl01AccesoMovil();

                newAcceso.Mvl01llave = Guid.Parse(request.id_movil.ToString());
                newAcceso.Mvl01IdUsuario = Guid.Parse(request.id_usuario.ToString());

                newAcceso.Mvl01NumeroMovil = request.numero_movil;
                newAcceso.Mvl01sistemaAndroid = request.sistema_operativo;
                newAcceso.Mvl01VersionAndroid = request.version_sistema;
                newAcceso.Mvl01VersionAplicacion = request.version_aplicacion;
                newAcceso.Mvl01EstaBloqueado = request.esta_bloqueado;
                newAcceso.Mvl01MensajeMovil = request.mensaje_movil;
                newAcceso.Mvl01FechaMensaje = request.fecha_mensaje;
                newAcceso.Mvl01FechaRegistro = request.fecha_registro;
                newAcceso.Mvl01FechaUltimoAcceso = request.fecha_ultimo_acceso;
                newAcceso.Mvl01FechaUltimaActividad = request.fecha_ultima_actividad;
                newAcceso.Mvl01FechaUltimaSincro = request.fecha_ultima_sincro;
                newAcceso.Mvl01TamanoBasedatosCliente = request.tamano_basedatos_cliente;
                newAcceso.Mvl01UbicacionActividadX = request.ubicacionactividadx;
                newAcceso.Mvl01UbicacionActividadY = request.ubicacionactividady;

                await _contexto.Mvl01AccesoMoviles!.AddAsync(newAcceso);

            }
            else
            {

                acceso.Mvl01NumeroMovil = string.IsNullOrEmpty(request.numero_movil) ? acceso.Mvl01NumeroMovil : request.numero_movil;
                acceso.Mvl01sistemaAndroid = string.IsNullOrEmpty(request.sistema_operativo) ? acceso.Mvl01sistemaAndroid : request.sistema_operativo;
                acceso.Mvl01VersionAndroid = string.IsNullOrEmpty(request.version_sistema) ? acceso.Mvl01VersionAndroid : request.version_sistema;
                acceso.Mvl01VersionAplicacion = string.IsNullOrEmpty(request.version_aplicacion) ? acceso.Mvl01VersionAplicacion : request.version_aplicacion;
                acceso.Mvl01EstaBloqueado = request.esta_bloqueado.HasValue ? request.esta_bloqueado : acceso.Mvl01EstaBloqueado;
                acceso.Mvl01MensajeMovil = string.IsNullOrEmpty(request.mensaje_movil) ? acceso.Mvl01MensajeMovil : request.mensaje_movil;
                acceso.Mvl01FechaMensaje = request.fecha_mensaje.HasValue ? request.fecha_mensaje : acceso.Mvl01FechaMensaje;
                acceso.Mvl01FechaRegistro = request.fecha_registro.HasValue  ? request.fecha_registro : acceso.Mvl01FechaRegistro;
                acceso.Mvl01FechaUltimoAcceso = request.fecha_ultimo_acceso.HasValue ? request.fecha_ultimo_acceso : acceso.Mvl01FechaUltimoAcceso;
                acceso.Mvl01FechaUltimaActividad = request.fecha_ultima_actividad.HasValue ? request.fecha_ultima_actividad : acceso.Mvl01FechaUltimaActividad;
                acceso.Mvl01FechaUltimaSincro = request.fecha_ultima_sincro.HasValue ? request.fecha_ultima_sincro : acceso.Mvl01FechaUltimaSincro;
                acceso.Mvl01TamanoBasedatosCliente = request.tamano_basedatos_cliente.HasValue ? request.tamano_basedatos_cliente : acceso.Mvl01TamanoBasedatosCliente;
                acceso.Mvl01UbicacionActividadX = request.ubicacionactividadx.HasValue ? request.ubicacionactividadx : acceso.Mvl01UbicacionActividadX;
                acceso.Mvl01UbicacionActividadY = request.ubicacionactividady.HasValue ? request.ubicacionactividady : acceso.Mvl01UbicacionActividadY;

                _contexto.Mvl01AccesoMoviles!.Update(acceso);

            }

        }


        public async Task DesactivarMonitorMovilAcceso(MovilAccesoDesactivateRequestDto request)
        {

            var acceso = await _contexto.Mvl01AccesoMoviles!
                .FirstOrDefaultAsync(x => x.Mvl01IdUsuario == Guid.Parse(request.id_usuario!) &&  x.Mvl01llave == Guid.Parse(request.id_movil!));

            _contexto.Mvl01AccesoMoviles!.Remove(acceso!);

        }

        public async Task<int> RegistrarAccesoMovil(MovilAccesoCreateRequestDto request)
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

            string sql = "EXEC pa_mipnet_movil_registro_i @id_movil, @id_usuario";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@id_movil", Value = request.id_movil, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@id_usuario", Value = request.id_usuario, DbType = System.Data.DbType.Guid },
                    
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

        public async Task<bool> Existe_movil_acceso(MovilAccesoExisteRequestDto request)
        {
            Boolean bbx_Existe = false;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            var listardto = new MovilAccesoRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;

            IEnumerable<MovilAccesoResponseDto> obx_Data = await listMovilAcceso(listardto);

            if (obx_Data != null)
            {
                if (obx_Data.Count() > 0)
                {
                    bbx_Existe = true;
                }
            } 

            return bbx_Existe;
        }

        public async Task<bool> Agregar_movil_acceso(MovilAccesoRegistrarRequestDto request)
        {
            Boolean bbx_Existe = false;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            

            var listardto = new MovilAccesoCreateRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;
            listardto.numero_movil = request.numero_movil;
            listardto.sistema_operativo = request.sistema_operativo;
            listardto.version_sistema = request.version_sistema;
            listardto.version_aplicacion = request.version_aplicacion;
            listardto.fecha_registro = DateTime.Now;

            var obx_Data = CreateMonitorMovilAcceso(listardto);

            if (obx_Data.IsCompleted)
            {
                bbx_Existe = true;
            } 
            
            return bbx_Existe;
        }

        public async Task<bool> Registrar_actividad_movil(MovilAccesoActividadRequestDto request)
        {
            Boolean bbx_Existe = false;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }



            var listardto = new MovilAccesoCreateRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;
            listardto.ubicacionactividadx = request.ubicacionactividadx;
            listardto.ubicacionactividady = request.ubicacionactividady;
            listardto.fecha_ultima_actividad = DateTime.Now;

            var obx_Data = CreateMonitorMovilAcceso(listardto);

            if (obx_Data.IsCompleted)
            {
                bbx_Existe = true;
            }

            return bbx_Existe;
        }


        public async Task<bool> registrar_sincro_movil(MovilAccesoSincroResponseDto request)
        {
            Boolean bbx_Existe = false;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }



            var listardto = new MovilAccesoCreateRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;
            listardto.tamano_basedatos_cliente = request.tamano_basedatos_cliente;
            listardto.fecha_ultima_sincro = DateTime.Now;

            var obx_Data = CreateMonitorMovilAcceso(listardto);

            if (obx_Data.IsCompleted)
            {
                bbx_Existe = true;
            }

            return bbx_Existe;
        }

        public async Task<bool> estado_bloqueado_movil(MovilAccesoExisteRequestDto request)
        {
            bool bbx_Existe = true;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            var listardto = new MovilAccesoRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;

            IEnumerable<MovilAccesoResponseDto> obx_Data = await listMovilAcceso(listardto);

            if (obx_Data != null)
            {
                foreach( MovilAccesoResponseDto item in obx_Data)
                {
                    bbx_Existe = (bool)item.esta_bloqueado!;
                }
            }

            return bbx_Existe;
        }

        public async Task<MovilAccesoEditarFechaResponseDto> edita_fecha_monitoreo_movil(MovilAccesoExisteRequestDto request)
        {
            bool bbx_Existe = true;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            MovilAccesoEditarFechaResponseDto response = new MovilAccesoEditarFechaResponseDto();

            var listardto = new MovilAccesoRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;

            IEnumerable<MovilAccesoResponseDto> obx_Data = await listMovilAcceso(listardto);

            if (obx_Data != null)
            {
                foreach (MovilAccesoResponseDto item in obx_Data)
                {
                    response.edita_fecha_monitoreo = item.edita_fecha_monitoreo;
                    response.dias_umbral_edicion = item.dias_umbral_edicion;
                }
            }

            return response;
        }

        public async Task<MovilAccesoVersionResponseDto> version_descarga_movil(MovilAccesoExisteRequestDto request)
        {
            bool bbx_Existe = true;
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            MovilAccesoVersionResponseDto response = new MovilAccesoVersionResponseDto();

            var listardto = new MovilAccesoRequestDto();
            listardto.id_movil = request.id_movil;
            listardto.id_usuario = request.id_usuario;

            IEnumerable<MovilAccesoResponseDto> obx_Data = await listMovilAcceso(listardto);

            if (obx_Data != null)
            {
                foreach (MovilAccesoResponseDto item in obx_Data)
                {
                    response.version_descarga = item.version_descarga;
                }
            }

            return response;
        }


    }
}
