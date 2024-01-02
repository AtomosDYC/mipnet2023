using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MonitorDtos;
using KendoNET.DynamicLinq;
using Microsoft.Data.SqlClient;


namespace mipBackend.Data.Monitores
{
    public class MonitorRepository : IMonitorRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MonitorRepository(
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

        public async Task<DataSourceResult> GetAllMonitorDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                string filtro = null;
                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            filtro = item.Value.ToString();
                        };
                    }

                }

                    var query = await (from mon in db.Mnt01Monitores
                                   join tip in db.Mnt04TipoMonitores! on mon.mnt04llave equals tip.mnt04llave
                                   join per in db.per01personas! on mon.per01llave equals per.per01llave
                                   join tipp in db.per03Tipopersonas! on per.per03llave equals tipp.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   where per.per01nombrerazon!.Contains(filtro)
                                   select new MonitorResponseDto
                                   {

                                       mnt01llave = mon.mnt01llave,
                                       
                                       per01nombre = per.per01nombrerazon,
                                       mnt04llave = tip.mnt04llave,
                                       mnt04nombre = tip.mnt04nombre,
                                       mnt01Cargo = mon.mnt01Cargo,
                                       mnt01Iniciolabores = mon.mnt01Iniciolabores,
                                       mnt01activo = mon.mnt01activo,

                                       per01llave = per.per01llave,

                                       per01rut = per.per01rut,
                                       per03llave = per.per03llave,
                                       per03nombre = tipp.per03nombre,
                                       per08llave = per.per08llave,
                                       per08nombre = tdoc.per08nombre,
                                       per02llave = per.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01giro = per.per01giro,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01activo = per.per01activo
                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }

        public async Task<IEnumerable<MonitorResponseDto>> GetAllMonitores()
        {
            using (var db = _contexto)
            {
                var query = await (from mon in db.Mnt01Monitores
                                   join tip in db.Mnt04TipoMonitores! on mon.mnt04llave equals tip.mnt04llave
                                   join per in db.per01personas! on mon.per01llave equals per.per01llave
                                   select new MonitorResponseDto
                                   {

                                       mnt01llave = mon.mnt01llave,
                                        per01llave = per.per01llave,
                                        per01nombre = per.per01nombrerazon,
                                        mnt04llave = tip.mnt04llave,
                                        mnt04nombre = tip.mnt04nombre,
                                        mnt01Cargo = mon.mnt01Cargo,
                                        mnt01Iniciolabores = mon.mnt01Iniciolabores,
                                        mnt01activo = mon.mnt01activo

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<MonitorResponseDto>>(query);

            }
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task<MonitorResponseDto> GetMonitorById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from mon in db.Mnt01Monitores
                                   join tip in db.Mnt04TipoMonitores! on mon.mnt04llave equals tip.mnt04llave
                                   join per in db.per01personas! on mon.per01llave equals per.per01llave
                                   join tipp in db.per03Tipopersonas! on per.per03llave equals tipp.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   where mon.mnt01llave == id
                                   select new MonitorResponseDto
                                   {

                                       mnt01llave = mon.mnt01llave,
                                       per01llave = per.per01llave,
                                       per01nombre = per.per01nombrerazon,
                                       mnt04llave = tip.mnt04llave,
                                       mnt04nombre = tip.mnt04nombre,
                                       mnt01Cargo = mon.mnt01Cargo,
                                       mnt01Iniciolabores = mon.mnt01Iniciolabores,
                                       mnt01activo = mon.mnt01activo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01giro = per.per01giro,
                                       per01rut = per.per01rut,
                                       per01activo = per.per01activo,
                                       per02llave = sal.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per03llave = tipp.per03llave,
                                       per03nombre = tipp.per03nombre,
                                       per08llave = tdoc.per08llave,
                                       per08nombre = tdoc.per08nombre
                                   
                                   }).FirstAsync();

                return _mapper.Map<MonitorResponseDto>(query);

            }
           
        }

        public async Task<string> CreateMonitores(MonitorRequestDto request)
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

            string sql = "EXEC pa_mipnet_Monitores_iu @MNT01_Llave, @MNT01_Cargo, @MNT04_Llave, @MNT01_iniciolabores, " +
                "@MNT01_Activo, @PER01_Llave, @PER02_LlAVE, @PER03_LlAVE, @PER08_LlAVE, @PER01_Rut, @PER01_NombreRazon, @PER01_Activo, " +
                "@CREATE_BY, @MNT01_Llave_out OUT";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@MNT01_Llave", Value = 0, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MNT01_Cargo", Value = request.mnt01Cargo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@MNT04_Llave", Value = request.mnt04llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MNT01_iniciolabores", Value = DateTime.Now.ToString(), DbType = System.Data.DbType.DateTime2},
                    new SqlParameter { ParameterName = "@MNT01_Activo", Value = 1, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_Llave", Value = request.per01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER02_Llave", Value = request.per02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER03_Llave", Value = request.per03llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER08_Llave", Value = request.per08llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_Rut", Value = request.per01rut, DbType = System.Data.DbType.Int32},
                    new SqlParameter { ParameterName = "@PER01_NombreRazon", Value = request.per01nombrerazon, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@PER01_Activo", Value = 1, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CREATE_BY", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@MNT01_Llave_out", Value = outputparam, Direction = System.Data.ParameterDirection.Output }

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return parms[13].Value.ToString()!;
            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }



        }

        public async Task<string> UpdateMonitores(MonitorResponseDto request)
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

            string sql = "EXEC pa_mipnet_Monitores_iu @MNT01_Llave, @MNT01_Cargo, @MNT04_Llave, @MNT01_iniciolabores, " +
                "@MNT01_Activo, @PER01_Llave, @PER02_LlAVE, @PER03_LlAVE, @PER08_LlAVE, @PER01_Rut, @PER01_NombreRazon, @PER01_Activo, " +
                "@CREATE_BY, @MNT01_Llave_out OUT";

            List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@MNT01_Llave", Value = request.mnt01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MNT01_Cargo", Value = request.mnt01Cargo, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@MNT04_Llave", Value = request.mnt04llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@MNT01_iniciolabores", Value = DateTime.Now.ToString(), DbType = System.Data.DbType.DateTime2},
                    new SqlParameter { ParameterName = "@MNT01_Activo", Value = 1, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_Llave", Value = request.per01llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER02_Llave", Value = request.per02llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER03_Llave", Value = request.per03llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER08_Llave", Value = request.per08llave, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@PER01_Rut", Value = request.per01rut, DbType = System.Data.DbType.Int32},
                    new SqlParameter { ParameterName = "@PER01_NombreRazon", Value = request.per01nombrerazon, DbType = System.Data.DbType.String },
                    new SqlParameter { ParameterName = "@PER01_Activo", Value = 1, DbType = System.Data.DbType.Int32 },
                    new SqlParameter { ParameterName = "@CREATE_BY", Value = usuario.Id, DbType = System.Data.DbType.Guid },
                    new SqlParameter { ParameterName = "@MNT01_Llave_out", Value = outputparam, Direction = System.Data.ParameterDirection.Output }

                };

            try
            {
                rowsAffected = await _contexto.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return parms[13].Value.ToString()!;

            }
            catch (SqlException ex)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = ex.Message }
                   );
            }

        }

       
        public async Task DeleteMonitores(int id)
        {
            
            var monitor = await _contexto.Mnt01Monitores!
                .FirstOrDefaultAsync(x => x.mnt01llave == id);


            if (monitor.mnt01activo == 0)
            {

                _contexto.Mnt01Monitores!.Remove(monitor!);

            } 
            else 
            {
                await DisableMonitores(id);
            }
            
        }

        public async Task DisableMonitores(int id)
        {

            try
            {
                var Monitor = await _contexto.Mnt01Monitores!
                .FirstOrDefaultAsync(x => x.mnt01llave == id);

                    var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                    if (usuario is null)
                    {
                        throw new MiddlewareException(
                            HttpStatusCode.Unauthorized,
                            new { mensaje = "El usuario no es valido para hacer este camnbio" }
                            );
                    }

                    if (Monitor is null)
                    {
                        throw new MiddlewareException(
                           HttpStatusCode.BadRequest,
                           new { mensaje = "La Comuna no existe en los listados" }
                           );
                    }


                    Monitor.mnt01activo = 0;

                _contexto.Mnt01Monitores!.Update(Monitor);

                
            } catch (Exception ex) { 

            }


        }

        public async Task ActivateMonitores(int id)
        {

            var Monitor = await _contexto.Mnt01Monitores!
                .FirstOrDefaultAsync(x => x.mnt01llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Monitor is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Comuna no existe en los listados" }
                   );
            }


            Monitor.mnt01activo = 1;

            _contexto.Mnt01Monitores!.Update(Monitor);


        }
    }
}
