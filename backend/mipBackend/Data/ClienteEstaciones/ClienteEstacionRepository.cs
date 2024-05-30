using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.ClienteEstacionDtos;
using KendoNET.DynamicLinq;
using mipBackend.Services.Rut;

using Microsoft.Data.SqlClient;

namespace mipBackend.Data.ClienteEstaciones
{
    public class ClienteEstacionRepository : IClienteEstacionRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public ClienteEstacionRepository(
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

        public async Task<DataSourceResult> GetAllClienteEstacionActivaDatasource(DataSourceRequest requestModel)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            using (var db = _contexto)
            {

                ClienteEstacionActivaRequestDto request = new ClienteEstacionActivaRequestDto();

                try { 

                

                } catch (Exception ex) 
                { 
                }


                string sql = "EXEC pa_mipnet_ClienteUsuario_ObtenerEstacionesActivas_s @quecontenga";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@quecontenga", Value = string.IsNullOrEmpty(request.quecontenga) ? DBNull.Value : request.quecontenga , DbType = System.Data.DbType.Int32 },

                };

                try
                {


                    Filter filter = new Filter();
                    if (filter != null)
                    {
                        IEnumerable<Filter> fil = requestModel.Filter!.Filters;
                        if (fil != null)
                        {
                            foreach (var item in fil)
                            {
                                request.quecontenga = item.Value.ToString();
                            };
                        }

                    }


                    var query = await _contexto.ClienteEstacionActivaResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();



                    DataSourceResult resultado = new DataSourceResult();
                    resultado.Total = query.Count();
                    resultado.Data = query.Skip(requestModel.Skip).Take(requestModel.Take);

                    return resultado;

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

        public async Task<ClienteEstacionResponseDto> GetClienteEstacion(ClienteEstacionRequestDto requestModel)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            using (var db = _contexto)
            {


                var query = await (from c in db.cnt01CuentaClientes
                                   join tcu in db.cnt02TipoCuentas! on c.cnt02llave equals tcu.cnt02llave
                                   join tcl in db.cnt03TipoClientes! on c.cnt03llave equals tcl.cnt03llave
                                   join tpe in db.per03Tipopersonas! on tcl.per03llave equals tpe.per03llave
                                   join per in db.per01personas! on c.per01llave equals per.per01llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   join tper in db.per03Tipopersonas! on per.per03llave equals tper.per03llave
                                   where tcu.cnt02activo == 1 &&
                                    tpe.per03activo == 1 &&
                                    tcl.cnt03activo == 1 &&
                                    tper.per03activo == 1 &&
                                    sal.per02activo == 1 &&
                                    (per.per01rut == (requestModel.per01rut.HasValue ? requestModel.per01rut : per.per01rut)) &&
                                    (c.cnt01llave == (requestModel.cnt01llave.HasValue ? requestModel.cnt01llave : c.cnt01llave))
                                   select new ClienteEstacionResponseDto
                                   {
                                       cnt01llave = c.cnt01llave,
                                       cnt01nombre = c.cnt01nombre,
                                       cnt01activo = c.cnt01activo,
                                       cnt02llave = tcu.cnt02llave,
                                       cnt02nombre = tcu.cnt02nombre,
                                       per01llave = per.per01llave,
                                       per01rut = per.per01rut,
                                       rutformato = Convert.ToString(per.per01rut),
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per03llave = tpe.per03llave,
                                       per03nombre = tpe.per03nombre,
                                       cnt03llave =  tcl.cnt03llave,
                                       cnt03nombre =  tcl.cnt03nombre,
                                       per02llave = sal.per02llave,
                                       per02titulo = sal.per02titulo

                                   }).FirstAsync();

                return query;

            }

        }


        public async Task<ClienteEstacionResponseDto> GetClienteEstacionbyrut(int rut) 
        {

            ClienteEstacionRequestDto request = new ClienteEstacionRequestDto();
            request.per01rut = rut;

            var query = await GetClienteEstacion(request);

            return query;

        }

        public async Task<ClienteEstacionResponseDto> GetClienteEstacionbyid(int id)
        {

            ClienteEstacionRequestDto request = new ClienteEstacionRequestDto();
            request.cnt01llave = id;

            var query = await GetClienteEstacion(request);

            return query;

        }

        public async Task<ClienteEstacionResponseDto> CreateClienteEstacion(ClienteEstacionRequestDto request)
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

            string sql = "EXEC pa_mipnet_ClienteEstacion_iu @CNT01_Llave, @PER02_Llave, @PER01_RUT, @CNT01_Nombre, @PER01_NombreFantasia, " +
                "@CNT03_Llave, @CREATE_BY, @CNT01_Llave_out OUT";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CNT01_Llave", Value = 0, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER02_Llave", Value = request.per02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_RUT", Value = request.per01rut, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CNT01_Nombre", Value = request.cnt01nombre, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@PER01_NombreFantasia", Value = request.per01nombrefantasia, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@CNT03_Llave", Value = request.cnt03llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CREATE_BY", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@CNT01_Llave_out", Value = outputparam, Direction = System.Data.ParameterDirection.Output }

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());

                ClienteEstacionResponseDto response = new ClienteEstacionResponseDto();
                response.cnt01llave = Convert.ToInt32(parms[7].Value.ToString()!);

                return response;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }



        }



        public async Task<ClienteEstacionResponseDto> updateclienteestacion(ClienteEstacionRequestDto request)
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

            string sql = "EXEC pa_mipnet_ClienteEstacion_iu @CNT01_Llave, @PER02_Llave, @PER01_RUT, @CNT01_Nombre, @PER01_NombreFantasia, " +
                "@CNT03_Llave, @CREATE_BY, @CNT01_Llave_out OUT";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@CNT01_Llave", Value = request.cnt01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER02_Llave", Value = request.per02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_RUT", Value = request.per01rut, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CNT01_Nombre", Value = request.cnt01nombre, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@PER01_NombreFantasia", Value = request.per01nombrefantasia, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@CNT03_Llave", Value = request.cnt03llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CREATE_BY", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@CNT01_Llave_out", Value = outputparam, Direction = System.Data.ParameterDirection.Output }

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());

                ClienteEstacionResponseDto response = new ClienteEstacionResponseDto();
                response.cnt01llave = request.cnt01llave;

                return response;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }

        public async Task deleteclienteestacion(int id) 
        {
            var clienteestacion = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == id);


            if (clienteestacion.cnt01activo == 0)
            {

                _contexto.cnt01CuentaClientes!.Remove(clienteestacion!);

            }
            else
            {
                await disableclienteestacion(id);
            }
        }

        public async Task disableclienteestacion(int? id)
        {
            try
            {
                var clienteestacion = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave== id);

                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                if (usuario is null)
                {
                    throw new MiddlewareException(
                        HttpStatusCode.Unauthorized,
                        new { mensaje = "El usuario no es valido para hacer este camnbio" }
                        );
                }

                if (clienteestacion is null)
                {
                    throw new MiddlewareException(
                       HttpStatusCode.BadRequest,
                       new { mensaje = "La Comuna no existe en los listados" }
                       );
                }


                clienteestacion.cnt01activo = 0;

                _contexto.cnt01CuentaClientes!.Update(clienteestacion);


            }
            catch (Exception ex)
            {

            }
        }

        public async Task activateclienteestacion(int? id)
        {

            var Clienteestacion = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Clienteestacion is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Comuna no existe en los listados" }
                   );
            }


            Clienteestacion.cnt01activo = 1;

            _contexto.cnt01CuentaClientes!.Update(Clienteestacion);

        }

    }
}