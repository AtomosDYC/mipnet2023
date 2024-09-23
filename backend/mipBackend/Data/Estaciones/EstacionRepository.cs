using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.EstacionDtos;
using KendoNET.DynamicLinq;
using mipBackend.Services.Rut;

using Microsoft.Data.SqlClient;
using System.Linq;

namespace mipBackend.Data.Estaciones
{
    
    public class EstacionRepository : IEstacionRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public EstacionRepository(
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

        public async Task<DataSourceResult> GetAllEstacionesDatasource(DataSourceRequest requestModel)
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
                    string? stx_cnt01 = "";
                    string stx_cnt08 = "";
                    string stx_quecontenga = "";

                    Filter filter = new Filter();
                    if (filter != null)
                    {
                        IEnumerable<Filter> fil = requestModel.Filter!.Filters;
                        if (fil != null)
                        {
                            foreach (var item in fil)
                            {
                                switch (item.Field)
                                {
                                    case "cnt01llave":
                                        stx_cnt01 = item.Value.ToString();
                                        break;
                                    case "cnt06llave":
                                        stx_cnt08 = item.Value.ToString();
                                        break;
                                    case "quecontenga":
                                        stx_quecontenga = item.Value.ToString();
                                        break;
                                }
                            };
                        }
                    }

                    
                    string sql = "EXEC pa_mipnet_ClienteSegmentacion_Obtener_s @cnt01llave, @cnt08llave, @quecontenga";

                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                        // Create parameter(s)    
                        new SqlParameter { ParameterName = "@cnt01llave", Value = string.IsNullOrEmpty(stx_cnt01) ? DBNull.Value : stx_cnt01 , DbType = System.Data.DbType.Int32 },
                        new SqlParameter { ParameterName = "@cnt08llave", Value = string.IsNullOrEmpty(stx_cnt08) ? DBNull.Value : stx_cnt08 , DbType = System.Data.DbType.Int32 },
                        new SqlParameter { ParameterName = "@quecontenga", Value = string.IsNullOrEmpty(stx_quecontenga) ? DBNull.Value : stx_quecontenga , DbType = System.Data.DbType.Int32 },

                    };
                    
                    var query = await _contexto.EstacionResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

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



        public async Task<IEnumerable<MenuEstacionResponseDto>> getMenuEstacion(string id, string encoid)
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

                    string sql = "EXEC pa_mipnet_ClienteEstacion_Obtener_Menu @cnt01llave, @encodeid";

                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                        // Create parameter(s)    
                        new SqlParameter { ParameterName = "@cnt01llave", Value = id.ToString() , DbType = System.Data.DbType.Int32 },
                        new SqlParameter { ParameterName = "@encodeid", Value = id.ToString() , DbType = System.Data.DbType.Int32 }

                    };

                    var query = await _contexto.MenuEstacionResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();
                    
                    return _mapper.Map<IEnumerable<MenuEstacionResponseDto>>(query);
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


}
