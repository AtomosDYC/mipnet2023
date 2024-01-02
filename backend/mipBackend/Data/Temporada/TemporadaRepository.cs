using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;

namespace mipBackend.Data.Temporada
{
    public class TemporadaRepository : ITemporadaRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public TemporadaRepository(
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



        public async Task CreateTemporada(Temp01Temporada Temporada)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (Temporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            Temporada.fechaactivacion = DateTime.Now;
            Temporada.createby = usuario.Id;
            Temporada.temp01activo = 1;

            await _contexto.Temp01Temporadas!.AddAsync(Temporada);

        }

        public async Task DeleteTemporada(int id)
        {

            var Temporada = await _contexto.Temp01Temporadas!
                .FirstOrDefaultAsync(x => x.temp01llave == id);

            _contexto.Temp01Temporadas!.Remove(Temporada!);
        }

        public async Task<IEnumerable<TemporadaResponseDto>> GetAllTemporada()
        {

            using (var db = _contexto)
            {
                var query = await (from tem in db.Temp01Temporadas
                                   join tb in db.Temp02TemporadaBases! on tem.temp02llave equals tb.temp02llave
                                   join st in db.Temp03Segmentaciones! on tem.temp03llave equals st.temp03llave
                                   select new TemporadaResponseDto
                                   {

                                       temp01llave = tem.temp01llave,
                                       temp01nombre = tem.temp01nombre,
                                       temp01descripcion = tem.temp01descripcion,
                                       temp01maxfecha = tem.temp01maxfecha,
                                       temp01minfecha = tem.temp01minfecha,
                                       temp01minmes = tem.temp01minmes,
                                       temp01maxmes = tem.temp01maxmes,
                                       temp01activo = tem.temp01activo,
                                       temp01periodo = tem.temp01periodo,
                                       temp02llave = tem.temp02llave,
                                       temp02nombre = tb.temp02nombre,
                                       temp03llave = tem.temp03llave,
                                       temp03nombre = st.temp03nombre

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<TemporadaResponseDto>>(query);

            }

        }

        public async Task<TemporadaResponseDto> GetTemporadaById(int id)
        {

            using (var db = _contexto)
            {
                var query = await (from tem in db.Temp01Temporadas
                                   join tb in db.Temp02TemporadaBases! on tem.temp02llave equals tb.temp02llave
                                   join st in db.Temp03Segmentaciones! on tem.temp03llave equals st.temp03llave
                                   where tem.temp01llave == id
                                   select new TemporadaResponseDto
                                   {

                                       temp01llave = tem.temp01llave,
                                       temp01nombre = tem.temp01nombre,
                                       temp01descripcion = tem.temp01descripcion,
                                       temp01maxfecha = tem.temp01maxfecha,
                                       temp01minfecha = tem.temp01minfecha,
                                       temp01minmes = tem.temp01minmes,
                                       temp01maxmes = tem.temp01maxmes,
                                       temp01activo = tem.temp01activo,
                                       temp01periodo = tem.temp01periodo,
                                       temp02llave = tem.temp02llave,
                                       temp02nombre = tb.temp02nombre,
                                       temp03llave = tem.temp03llave,
                                       temp03nombre = st.temp03nombre

                                   }).FirstAsync();

                return _mapper.Map<TemporadaResponseDto>(query);
            }

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateTemporada(Temp01Temporada request)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (request is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var Temporada = await _contexto.Temp01Temporadas!
                .FirstOrDefaultAsync(x => x.temp01llave == request.temp01llave);

            Temporada.fechaactualizacion = DateTime.Now;
            Temporada.approveby = usuario.Id;
            Temporada.temp01nombre = request.temp01nombre;
            Temporada.temp01descripcion = request.temp01descripcion;
            Temporada.temp01maxfecha = request.temp01maxfecha;
            Temporada.temp01minfecha = request.temp01minfecha;
            Temporada.temp01minmes = request.temp01minmes;
            Temporada.temp01maxmes = request.temp01maxmes;
            Temporada.temp01periodo = request.temp01periodo;
            Temporada.temp02llave = request.temp02llave;
            Temporada.temp03llave = request.temp03llave;

            _contexto.Temp01Temporadas!.Update(Temporada!);

        }

        public async Task DisableTemporada(int id)
        {

            var Temporada = await _contexto.Temp01Temporadas!
                .FirstOrDefaultAsync(x => x.temp01llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Temporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Temporada no existe en los listados" }
                   );
            }


            Temporada.temp01activo = 0;

            _contexto.Temp01Temporadas!.Update(Temporada);

        }

        public async Task ActivateTemporada(int id)
        {

            var Temporada = await _contexto.Temp01Temporadas!
                .FirstOrDefaultAsync(x => x.temp01llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Temporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Temporada no existe en los listados" }
                   );
            }

            Temporada.temp01activo = 1;

            _contexto.Temp01Temporadas!.Update(Temporada);

        }

    }
}
