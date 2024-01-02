using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.EspecieDtos;

namespace mipBackend.Data.Especies
{
    public class DanioEspecieRepository : IDanioEspecieRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public DanioEspecieRepository(
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

        public async Task<IEnumerable<DanioEspecieResponseDto>> GetDanioEspecie(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from esp in db.esp03especieBases
                                   join dan in db.esp01especies! on esp.esp03llave equals dan.esp03llave
                                   join tip in db.esp04EstadoDanios! on dan.esp04llave equals tip.esp04llave
                                   where esp.esp03llave == id
                                   select new DanioEspecieResponseDto
                                   {
                                       esp01llave = dan.esp01llave,
                                       esp03llave = esp.esp03llave,
                                       esp03nombre = esp.esp03nombre,
                                       esp04llave = dan.esp04llave,
                                       esp04nombre = tip.esp04nombre

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<DanioEspecieResponseDto>>(query);

            }
        }

        public async Task CreateDanioEspecie(esp01especie especie)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (especie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            await _contexto.esp01especies!.AddAsync(especie);

        }

        public async Task DeleteDanioEspecie(DanioEspecieResponseDto request)
        {

            var danioespecie = await _contexto.esp01especies!
                .FirstOrDefaultAsync(x => x.esp01llave == request.esp01llave);

            _contexto.esp01especies!.Remove(danioespecie!);
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

    }
}
