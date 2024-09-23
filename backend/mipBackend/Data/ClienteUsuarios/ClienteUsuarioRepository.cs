using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.ClienteUsuarioDtos;
using KendoNET.DynamicLinq;
using mipBackend.Services.Rut;

using Microsoft.Data.SqlClient;

namespace mipBackend.Data.ClienteUsuarios
{
    public class ClienteUsuarioRepository : IClienteUsuarioRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public ClienteUsuarioRepository(
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

        public async Task<DataSourceResult> GetAllClienteUsuarioActivaDatasource(DataSourceRequest requestModel)
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

                ClienteUsuarioActivaRequestDto request = new ClienteUsuarioActivaRequestDto();

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
                                quecontenga = item.Value.ToString();
                            };
                        }
                    }

                }
                catch (Exception ex)
                {

                }

                string sql = "EXEC pa_mipnet_ClienteUsuarioActivos_Obtener_s @quecontenga";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@quecontenga", Value = string.IsNullOrEmpty(quecontenga) ? DBNull.Value : request.quecontenga , DbType = System.Data.DbType.Int32 },
                };

                try
                {

                    

                    var query = await _contexto.ClienteUsuarioActivaResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                    DataSourceResult resultado = new DataSourceResult();
                    resultado.Total = query.Count();
                    resultado.Data = query.Skip(requestModel.Skip).Take(requestModel.Take).OrderBy(e => requestModel.Sort);

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

        public async Task<DataSourceResult> GetAllClienteUsuarioInactivoDatasource(DataSourceRequest requestModel)
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

                ClienteUsuarioActivaRequestDto request = new ClienteUsuarioActivaRequestDto();

                
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
                

                string sql = "EXEC pa_mipnet_ClienteUsuarioInactivos_Obtener_s @quecontenga";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@quecontenga", Value = string.IsNullOrEmpty(quecontenga) ? DBNull.Value : quecontenga , DbType = System.Data.DbType.String },
                };

                try
                {

                    

                    var query = await _contexto.ClienteUsuarioActivaResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                    DataSourceResult resultado = new DataSourceResult();
                    resultado.Total = query.Count();
                    resultado.Data = query.Skip(requestModel.Skip).Take(requestModel.Take).OrderBy(e => requestModel.Sort);

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

        public async Task<IEnumerable<MenuClienteusuarioDto>> getMenuCienteUsuario(string id)
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
                try
                {

                    bool blx_disable = true;

                    string sql = "EXEC pa_mipnet_ClienteUsuario_Obtener_Menu @cnt01llave";

                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                        // Create parameter(s)    
                        new SqlParameter { ParameterName = "@cnt01llave", Value = id.ToString() , DbType = System.Data.DbType.Int32 },
                        new SqlParameter { ParameterName = "@encodeid", Value = id.ToString() , DbType = System.Data.DbType.Int32 }

                    };

                    var query = await _contexto.MenuEstacionResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                    return _mapper.Map<IEnumerable<MenuClienteusuarioDto>>(query);
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

        public async Task<ClienteUsuarioResponseDto> GetClienteUsuario(ClienteUsuarioRequestDto requestModel)
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
                                   select new ClienteUsuarioResponseDto
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
                                       cnt03llave = tcl.cnt03llave,
                                       cnt03nombre = tcl.cnt03nombre,
                                       per02llave = sal.per02llave,
                                       per02titulo = sal.per02titulo

                                   }).FirstAsync();

                return query;

            }

        }

        public async Task<ClienteUsuarioResponseDto> GetClienteUsuariobyrut(int rut)
        {

            ClienteUsuarioRequestDto request = new ClienteUsuarioRequestDto();
            request.per01rut = rut;

            var query = await GetClienteUsuario(request);

            return query;

        }

        public async Task<ClienteUsuarioResponseDto> GetClienteUsuariobyid(int id)
        {

            ClienteUsuarioRequestDto request = new ClienteUsuarioRequestDto();
            request.cnt01llave = id;

            var query = await GetClienteUsuario(request);

            return query;

        }

        public async Task<ClienteUsuarioResponseDto> CreateClienteUsuario(ClienteUsuarioRequestDto request)
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

            string sql = "EXEC pa_mipnet_ClienteUsuario_iu @CNT01_Llave, @PER02_Llave, @PER01_RUT, @CNT01_Nombre, @PER01_NombreFantasia, " +
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

                ClienteUsuarioResponseDto response = new ClienteUsuarioResponseDto();
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

        public async Task<ClienteUsuarioResponseDto> updateclienteUsuario(ClienteUsuarioRequestDto request)
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

            string sql = "EXEC pa_mipnet_ClienteUsuario_iu @CNT01_Llave, @PER02_Llave, @PER01_RUT, @CNT01_Nombre, @PER01_NombreFantasia, " +
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

                ClienteUsuarioResponseDto response = new ClienteUsuarioResponseDto();
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

        public async Task deleteclienteUsuario(int id)
        {
            var clienteUsuario = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == id);


            if (clienteUsuario.cnt01activo == 0)
            {

                _contexto.cnt01CuentaClientes!.Remove(clienteUsuario!);

            }
            else
            {
                await disableclienteUsuario(id);
            }
        }

        public async Task disableclienteUsuario(int? id)
        {
            try
            {
                var clienteUsuario = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == id);

                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                if (usuario is null)
                {
                    throw new MiddlewareException(
                        HttpStatusCode.Unauthorized,
                        new { mensaje = "El usuario no es valido para hacer este camnbio" }
                        );
                }

                if (clienteUsuario is null)
                {
                    throw new MiddlewareException(
                       HttpStatusCode.BadRequest,
                       new { mensaje = "La Comuna no existe en los listados" }
                       );
                }


                clienteUsuario.cnt01activo = 0;

                _contexto.cnt01CuentaClientes!.Update(clienteUsuario);


            }
            catch (Exception ex)
            {

            }
        }

        public async Task activateclienteUsuario(int? id)
        {

            var ClienteUsuario = await _contexto.cnt01CuentaClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (ClienteUsuario is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Comuna no existe en los listados" }
                   );
            }


            ClienteUsuario.cnt01activo = 1;

            _contexto.cnt01CuentaClientes!.Update(ClienteUsuario);

        }

    }
}
