using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.ClienteEstacionDtos;

using KendoNET.DynamicLinq;
using Microsoft.Data.SqlClient;

namespace mipBackend.Data.ClienteEstaciones
{
    public class ClienteEstacionContactoRepository : IClienteEstacionContactoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;
        private ClienteEstacionContactoResponseDto? resultado;

        public ClienteEstacionContactoRepository(
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

        public async Task<DataSourceResult> GetAllClienteEstacionContactoDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {

                int filtro = 0;
                int cnt01 = 0;
                ClienteEstacionComunicacionResponseDto request = new ClienteEstacionComunicacionResponseDto();

                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "cnt01llave":
                                    cnt01 = Convert.ToInt32(item.Value.ToString());
                                    break;
                                case "cnt06llave":
                                    request.cnt06llave = Convert.ToInt32(item.Value.ToString());
                                    break;
                            }
                        };
                    }

                }

                var query = await (from c4 in db.cnt04ContactoClientes
                                   join c5 in db.cnt05TipoContactos! on c4.cnt05llave equals c5.cnt05llave
                                   join c in db.cnt01CuentaClientes! on c4.cnt01llave equals c.cnt01llave
                                   join c2 in db.cnt02TipoCuentas! on c.cnt02llave equals c2.cnt02llave
                                   join per in db.per01personas! on c4.per01llave equals per.per01llave
                                   join gen in db.per02Generos! on per.per02llave equals gen.per02llave
                                   join c3 in db.cnt03TipoClientes! on c.cnt03llave equals c3.cnt03llave
                                   join p3 in db.per03Tipopersonas! on per.per03llave equals p3.per03llave
                                  


                                   where (c.cnt01llave == cnt01)

                                   select new ClienteEstacionContactoResponseDto
                                   {
                                       cnt01llave = c.cnt01llave,
                                       cnt04llave = c4.cnt04llave,
                                       cnt05llave = c5.cnt05llave,
                                       cnt05nombre = c5.cnt05nombre,
                                       per01llave =  per.per01llave,
                                       per02llave = per.per02llave,
                                       per02titulo = gen.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per03llave = p3.per03llave,
                                       per03nombre = p3.per03nombre
                                   }


                                   ).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);



                return query;

            }
        }


        public async Task<ClienteEstacionContactoResponseDto?> GetAllClienteEstacionContactoById(ClienteEstacionContactoRequestDto request)
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

                var query = await (from c4 in db.cnt04ContactoClientes
                                   join c5 in db.cnt05TipoContactos! on c4.cnt05llave equals c5.cnt05llave
                                   join c in db.cnt01CuentaClientes! on c4.cnt01llave equals c.cnt01llave

                                   join p1 in db.per01personas! on c4.per01llave equals p1.per01llave
                                   join p2 in db.per02Generos! on p1.per02llave equals p2.per02llave
                                   join p8 in db.per08TipoDocumentos! on p1.per08llave equals p8.per08llave
                                   join p3 in db.per03Tipopersonas! on p1.per03llave equals p3.per03llave

                                   join p5 in db.per05Comunicaciones! on p1.per01llave equals p5.per01llave into p5Group
                                   from p5 in p5Group.DefaultIfEmpty()

                                   join s3 in db.sist03Comunas! on p5.sist03llave equals s3.sist03llave into s3Group
                                   from s3 in s3Group.DefaultIfEmpty()

                                   join s4 in db.sist04Regiones! on s3.sist04llave equals s4.sist04llave into s4Group
                                   from s4 in s4Group.DefaultIfEmpty()

                                   join p4 in db.per04TipoComunicaciones! on p5.per04llave equals p4.per04llave into p4Group
                                   from p4 in p4Group.DefaultIfEmpty()

                                   where (c.cnt01llave == request.cnt01llave && c4.cnt04llave == request.cnt04llave && p4.per04nombre == "laboral")

                                   select new ClienteEstacionContactoResponseDto
                                   {

                                       cnt01llave = c.cnt01llave,
                                       cnt04llave = c4.cnt04llave,
                                       cnt05llave = c5.cnt05llave,
                                       cnt05nombre = c5.cnt05nombre,
                                       per01llave = p1.per01llave,
                                       per02llave = p2.per02llave,
                                       per02titulo = p2.per02titulo,
                                       per03llave = p3.per03llave,
                                       per03nombre = p3.per03nombre,
                                       per08llave = p8.per08llave,
                                       per08nombre = p8.per08nombre,
                                       per01rut = p1.per01rut,
                                       per01nombrerazon = p1.per01nombrerazon,
                                       per01activo = p1.per01activo,
                                       per05direccion = p5.per05direccion,
                                       sist03llave = s3.sist03llave,
                                       sist03nombre = s3.sist03nombre,
                                       sist04llave = s4.sist04llave,
                                       sist04nombre = s4.sist04nombre,
                                       per05casilla = p5.per05casilla,
                                       per05tienecasilla = p5.per05tienecasilla,
                                       per05codigopostal = p5.per05codigopostal,
                                       per05email = p5.per05email,
                                       per05telefono1 = p5.per05telefono1,
                                       per05telefono2 = p5.per05telefono2,
                                       per05celular1 = p5.per05celular1,
                                       per05celular2 = p5.per05celular2,
                                       per05fax = p5.per05fax,
                                       per05sitioWeb = p5.per05sitioWeb,
                                       createby = c.createby

                                   }
                                   ).FirstAsync();

                return query;

                /*
            string sql = "EXEC pa_mipnet_clienteestacion_contacto_obtener_s @cnt01_llave, @cnt04_llave";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@cnt01_llave", Value = cnt01 , DbType = System.Data.DbType.Int32 },
                new SqlParameter { ParameterName = "@cnt04_llave", Value = cnt04 , DbType = System.Data.DbType.Int32 }

            };

            try
            {

                var query = await _contexto.ClienteEstacionContactoResponse!.FromSqlRaw(sql, parms.ToArray()).FirstOrDefaultAsync();

                ClienteEstacionContactoResponseDto? resutado = query;


                return resultado;

            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }
                */

            }

        }

        public async Task<ClienteEstacionContactoResponseDto> CreateClienteEstacionContacto(ClienteEstacionContactoRequestDto request)
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

            string sql = "EXEC pa_mipnet_clienteestacion_contacto_iu " +
                "@cnt04_llave, " +
                "@cnt01_llave, " +
                "@cnt05_llave, " +
                "@per01_llave, " +
                "@per02_llave, " +
                "@per03_llave, " +
                "@per08_llave, " +
                "@per01_rut, " +
                "@per01_nombrerazon, " +
                "@per05_direccion, " +
                "@sist03_llave, " +
                "@per05_casilla, " +
                "@per05_tienecasilla, " +
                "@per05_codigopostal, " +
                "@per05_email, " +
                "@per05_telefono1, " +
                "@per05_telefono2, " +
                "@per05_celular1, " +
                "@per05_celular2, " +
                "@per05_fax, " +
                "@per05_sitioWeb, " +
                "@create_by, " +
                "@cnt04_Llave_out out";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@cnt04_llave", Value = request.cnt04llave.HasValue ?  request.cnt04llave : DBNull.Value , DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@cnt01_llave", Value = request.cnt01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@cnt05_llave", Value = request.cnt05llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per01_llave", Value = request.per01llave.HasValue ? request.per01llave : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per02_llave", Value = request.per02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per03_llave", Value = request.per03llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per08_llave", Value = request.per08llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per01_rut", Value = request.per01rut, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per01_nombrerazon", Value = request.per01nombrerazon, DbType = System.Data.DbType.String },
                    
                    new SqlParameter { ParameterName = "@per05_direccion", Value = request.per05direccion, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@sist03_llave", Value = request.sist03llave, DbType = System.Data.DbType.Int32 },

                    new SqlParameter { ParameterName = "@per05_casilla", Value = request.per05casilla, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_tienecasilla", Value = request.per05tienecasilla, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@per05_codigopostal", Value = request.per05codigopostal, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_email", Value = request.per05email, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_telefono1", Value = request.per05telefono1, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_telefono2", Value = request.per05telefono2, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_celular1", Value = request.per05celular1, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_celular2", Value = request.per05celular2, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_fax", Value = request.per05fax, DbType = System.Data.DbType.String},
                    new SqlParameter { ParameterName = "@per05_sitioWeb", Value = request.per05sitioWeb, DbType = System.Data.DbType.String},

                    new SqlParameter { ParameterName = "@create_by", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@cnt04_Llave_out", Value = outputparam, Direction = System.Data.ParameterDirection.Output }

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());

                ClienteEstacionContactoResponseDto response = new ClienteEstacionContactoResponseDto();
                response.cnt04llave = Convert.ToInt32(parms[22].Value.ToString()!);

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

        public async Task DeleteClienteEstacionContacto(ClienteEstacionContactoRequestDto request)
        {

            var clientecontacto = await _contexto.cnt04ContactoClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == request.cnt01llave
                                        && x.cnt04llave == request.cnt04llave);

            _contexto.cnt04ContactoClientes!.Remove(clientecontacto!);

        }

    }
}
