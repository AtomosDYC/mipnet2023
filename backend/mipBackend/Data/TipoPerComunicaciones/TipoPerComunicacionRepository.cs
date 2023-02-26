using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoPerComunicacionDtos;
using Microsoft.Data.SqlClient;

namespace mipBackend.Data.TipoPerComunicaciones
{
    public class TipoPerComunicacionRepository : ITipoPerComunicacionRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public TipoPerComunicacionRepository(
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



        public async Task CreateTipoPerComunicacion(Per06TipoPersonaComunicacion TipoPerComunicacion)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (TipoPerComunicacion is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            TipoPerComunicacion.fechaactualizacion = DateTime.Now;
            TipoPerComunicacion.createby = Guid.Parse(usuario.Id);

            await _contexto.Per06TipoPersonaComunicaciones!.AddAsync(TipoPerComunicacion);

        }

        public async Task DeleteTipoPerComunicacion(TipoPerComunicacionRequestDto request)
        {

            var tipoparametro = await _contexto.Per06TipoPersonaComunicaciones!
                .Where(x => x.per04llave == request.per04llave && x.per03llave == request.per03llave)
                .ToListAsync();

            _contexto.RemoveRange(tipoparametro!);

        }

        public async Task<IEnumerable<TipoPerComunicacionResponseDto>> GetAllTipoPerComunicaciones()
        {
                var query = await (from tpc in _contexto.Per06TipoPersonaComunicaciones
                                   join tp in _contexto.Per03TipoPersonas! on tpc.per03llave equals tp.per03llave
                                   join tcp in _contexto.Per04TipoComunicaciones! on tpc.per04llave equals tcp.per04llave
                                   //where (flu.wkf02activo == 1)
                                   select new TipoPerComunicacionResponseDto
                                   {
                                       per03llave = tpc.per03llave,
                                       per03nombre = tp.per03nombre,
                                       per04llave = tpc.per04llave,
                                       per04nombre = tcp.per04nombre,
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<TipoPerComunicacionResponseDto>>(query);

        }

        public async Task<IEnumerable<TipoPerComunicacionResponseDto>> GetTipoPerComunicacionById(int id)
        {
            
                var query = await (from tpc in _contexto.Per06TipoPersonaComunicaciones
                                   join tp in _contexto.Per03TipoPersonas! on tpc.per03llave equals tp.per03llave
                                   join tcp in _contexto.Per04TipoComunicaciones! on tpc.per04llave equals tcp.per04llave
                                   where (tpc.per04llave == id)
                                   select new TipoPerComunicacionResponseDto
                                   {
                                       per03llave = tpc.per03llave,
                                       per03nombre = tp.per03nombre,
                                       per04llave = tpc.per04llave,
                                       per04nombre = tcp.per04nombre,
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<TipoPerComunicacionResponseDto>>(query);

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

    }
}
