using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.EstadosDanioDtos;

namespace mipBackend.Data.EstadosDanios
{
    public class EstadosDanioRepository : IEstadosDanioRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public EstadosDanioRepository(
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


        public async Task CreateEstadosDanio(esp04EstadoDanio EstadosDanio)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (EstadosDanio is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            EstadosDanio.fechaactivacion = DateTime.Now;
            EstadosDanio.createby = usuario.Id;
            EstadosDanio.esp04activo = 1;

            await _contexto.esp04EstadoDanios!.AddAsync(EstadosDanio);

        }

        public async Task DeleteEstadosDanio(int id)
        {

            var EstadosDanio = await _contexto.esp04EstadoDanios!
                .FirstOrDefaultAsync(x => x.esp04llave == id);

            _contexto.esp04EstadoDanios!.Remove(EstadosDanio!);
        }

        public async Task<IEnumerable<EstadosDanioResponseDto>> GetAllEstadosDanios()
        {
            using (var db = _contexto)
            {
                var query = await (from est in db.esp04EstadoDanios
                                   join med in db.esp06MedidaUmbrales! on est.esp06llave equals med.esp06llave
                                   select new EstadosDanioResponseDto
                                   {
                                       esp04llave = est.esp04llave,
                                       esp04nombre = est.esp04nombre,
                                       esp04descripcion = est.esp04descripcion,
                                       esp04activo = est.esp04activo,
                                       esp06llave = med.esp06llave,
                                       esp06nombre = med.esp06nombre
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<EstadosDanioResponseDto>>(query);

            }
        }

        public async Task<EstadosDanioResponseDto> GetEstadosDanioById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from est in db.esp04EstadoDanios
                                   join med in db.esp06MedidaUmbrales! on est.esp06llave equals med.esp06llave
                                   where est.esp04llave == id
                                   select new EstadosDanioResponseDto
                                   {
                                       esp04llave = est.esp04llave,
                                       esp04nombre = est.esp04nombre,
                                       esp04descripcion = est.esp04descripcion,
                                       esp04activo = est.esp04activo,
                                       esp06llave = med.esp06llave,
                                       esp06nombre = med.esp06nombre
                                   }).FirstAsync();

                return _mapper.Map<EstadosDanioResponseDto>(query);

            }
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateEstadosDanio(esp04EstadoDanio request)
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

            var EstadosDanio = await _contexto.esp04EstadoDanios!
                .FirstOrDefaultAsync(x => x.esp04llave == request.esp04llave);

            EstadosDanio.fechaactualizacion = DateTime.Now;
            EstadosDanio.approveby = usuario.Id;
            EstadosDanio.esp04nombre = request.esp04nombre;
            EstadosDanio.esp04descripcion = request.esp04descripcion;
            EstadosDanio.esp06llave = request.esp06llave;
            
            _contexto.esp04EstadoDanios!.Update(EstadosDanio!);

        }

        public async Task DisableEstadosDanio(int id)
        {

            var EstadosDanio = await _contexto.esp04EstadoDanios!
                .FirstOrDefaultAsync(x => x.esp04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (EstadosDanio is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La EstadosDanio no existe en los listados" }
                   );
            }


            EstadosDanio.esp04activo = 0;

            _contexto.esp04EstadoDanios!.Update(EstadosDanio);


        }

        public async Task ActivateEstadosDanio(int id)
        {

            var EstadosDanio = await _contexto.esp04EstadoDanios!
                .FirstOrDefaultAsync(x => x.esp04llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (EstadosDanio is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La EstadosDanio no existe en los listados" }
                   );
            }


            EstadosDanio.esp04activo = 1;

            _contexto.esp04EstadoDanios!.Update(EstadosDanio);


        }


    }
}