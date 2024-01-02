using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.TipoperComunicacionDtos;
using Microsoft.Data.SqlClient;

namespace mipBackend.Data.TipoperComunicaciones
{
    public class TipoperComunicacionRepository : ITipoperComunicacionRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public TipoperComunicacionRepository(
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



        public async Task CreateTipoperComunicacion(per06TipopersonaComunicacion TipoperComunicacion)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (TipoperComunicacion is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            TipoperComunicacion.fechaactualizacion = DateTime.Now;
            TipoperComunicacion.createby = usuario.Id;

            await _contexto.per06TipopersonaComunicaciones!.AddAsync(TipoperComunicacion);

        }

        public async Task DeleteTipoperComunicacion(TipoperComunicacionRequestDto request)
        {

            var tipoparametro = await _contexto.per06TipopersonaComunicaciones!
                .Where(x => x.per04llave == request.per04llave && x.per03llave == request.per03llave)
                .ToListAsync();

            _contexto.RemoveRange(tipoparametro!);

        }

        public async Task<IEnumerable<TipoperComunicacionResponseDto>> GetAllTipoperComunicaciones()
        {
                var query = await (from tpc in _contexto.per06TipopersonaComunicaciones
                                   join tp in _contexto.per03Tipopersonas! on tpc.per03llave equals tp.per03llave
                                   join tcp in _contexto.per04TipoComunicaciones! on tpc.per04llave equals tcp.per04llave
                                   //where (flu.wkf02activo == 1)
                                   select new TipoperComunicacionResponseDto
                                   {
                                       per03llave = tpc.per03llave,
                                       per03nombre = tp.per03nombre,
                                       per04llave = tpc.per04llave,
                                       per04nombre = tcp.per04nombre,
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<TipoperComunicacionResponseDto>>(query);

        }

        public async Task<IEnumerable<TipoperComunicacionResponseDto>> GetTipoperComunicacionById(int id)
        {
            
                var query = await (from tpc in _contexto.per06TipopersonaComunicaciones
                                   join tp in _contexto.per03Tipopersonas! on tpc.per03llave equals tp.per03llave
                                   join tcp in _contexto.per04TipoComunicaciones! on tpc.per04llave equals tcp.per04llave
                                   where (tpc.per04llave == id)
                                   select new TipoperComunicacionResponseDto
                                   {
                                       per03llave = tpc.per03llave,
                                       per03nombre = tp.per03nombre,
                                       per04llave = tpc.per04llave,
                                       per04nombre = tcp.per04nombre,
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<TipoperComunicacionResponseDto>>(query);

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

    }
}
