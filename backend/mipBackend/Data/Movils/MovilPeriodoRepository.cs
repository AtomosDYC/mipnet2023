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

namespace mipBackend.Data.Movils
{
    public class MovilPeriodoRepository : IMovilPeriodoRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MovilPeriodoRepository(
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


        public async Task<DataSourceResult> GetPeriodosMovil(MovilPeriodoRequestDto request)
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

            string sql = "EXEC pa_mipnet_movil_periodo_s @id_periodo, @predeterminada";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@id_periodo", Value = request.id_periodo.HasValue ? request.id_periodo : DBNull.Value, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@predeterminada", Value = request.predeterminada.HasValue ? request.predeterminada : DBNull.Value, DbType = System.Data.DbType.Boolean },
                    
                };

            try
            {
               
                var query = await _contexto.MovilPeriodoResponse!.FromSqlRaw(sql, parms.ToArray()).ToListAsync();

                DataSourceResult resultado = new DataSourceResult();
                resultado.Total = query.Count();
                resultado.Data = query;

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
}
