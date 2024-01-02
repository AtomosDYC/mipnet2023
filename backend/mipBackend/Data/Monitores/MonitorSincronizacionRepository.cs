using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MonitorDtos;

using Microsoft.Data.SqlClient;

using mipBackend.Services.ints;

using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public class MonitorSincronizacionRepository : IMonitorSincronizacionRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MonitorSincronizacionRepository(
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

        public async Task<DataSourceResult> GetAllMonitorSincronizacionDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {

                int? MNT01_Llave = null;


                if (options.Filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "mnt01llave":
                                    MNT01_Llave = Ints.ParseNullableInt(item.Value);
                                    break;
                            }
                        }
                    }
                }

                Filter filter = new Filter();

                var query = await _contexto.MonitorTrampaBuscarResponse!
                    .FromSqlInterpolated($"EXEC pa_mipnet_monitores_datosCelular_s {MNT01_Llave}")
                .ToListAsync();

                DataSourceResult resultado = new DataSourceResult();
                resultado.Total = query.Count();
                resultado.Data = query.Skip(options.Skip).Take(options.Take);



                return resultado;



            }

        }

        public async Task<int> sincronizartodo(int mnt01llave)
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

            string sql = "EXEC pa_mipnet_monitores_ActualizarCelular_iu @MNT01_Llave";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@MNT01_Llave", Value = mnt01llave, DbType = System.Data.DbType.Int32 }
                    
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
