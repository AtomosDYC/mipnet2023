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
    public class SegmentarTemporadaRepository : ISegmentarTemporadaRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public SegmentarTemporadaRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }



        public async Task CreateSegmentarTemporada(Temp03Segmentacion SegmentarTemporada)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (SegmentarTemporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            SegmentarTemporada.fechaactivacion = DateTime.Now;
            SegmentarTemporada.createby = usuario.Id;
            SegmentarTemporada.temp03activo = 1;

            await _contexto.Temp03Segmentaciones!.AddAsync(SegmentarTemporada);

        }

        public async Task DeleteSegmentarTemporada(int id)
        {

            var SegmentarTemporada = await _contexto.Temp03Segmentaciones!
                .FirstOrDefaultAsync(x => x.temp03llave == id);

            _contexto.Temp03Segmentaciones!.Remove(SegmentarTemporada!);
        }

        public async Task<IEnumerable<Temp03Segmentacion>> GetAllSegmentarTemporada()
        {
            return await _contexto.Temp03Segmentaciones!.ToListAsync();
        }

        public async Task<Temp03Segmentacion> GetSegmentarTemporadaById(int id)
        {
            return await _contexto.Temp03Segmentaciones!.FirstOrDefaultAsync(x => x.temp03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateSegmentarTemporada(Temp03Segmentacion request)
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

            var SegmentarTemporada = await _contexto.Temp03Segmentaciones!
                .FirstOrDefaultAsync(x => x.temp03llave == request.temp03llave);

            SegmentarTemporada.fechaactualizacion = DateTime.Now;
            SegmentarTemporada.approveby = usuario.Id;
            SegmentarTemporada.temp03nombre = request.temp03nombre;
            SegmentarTemporada.temp03descripcion = request.temp03descripcion;
            SegmentarTemporada.temp03numeromeses = request.temp03numeromeses;
            SegmentarTemporada.temp03numerosegmentostotal = request.temp03numerosegmentostotal;


            _contexto.Temp03Segmentaciones!.Update(SegmentarTemporada!);

        }

        public async Task DisableSegmentarTemporada(int id)
        {

            var SegmentarTemporada = await _contexto.Temp03Segmentaciones!
                .FirstOrDefaultAsync(x => x.temp03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (SegmentarTemporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La SegmentarTemporada no existe en los listados" }
                   );
            }


            SegmentarTemporada.temp03activo = 0;

            _contexto.Temp03Segmentaciones!.Update(SegmentarTemporada);


        }

        public async Task ActivateSegmentarTemporada(int id)
        {

            var SegmentarTemporada = await _contexto.Temp03Segmentaciones!
                .FirstOrDefaultAsync(x => x.temp03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (SegmentarTemporada is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La SegmentarTemporada no existe en los listados" }
                   );
            }


            SegmentarTemporada.temp03activo = 1;

            _contexto.Temp03Segmentaciones!.Update(SegmentarTemporada);

        }

    }
}
