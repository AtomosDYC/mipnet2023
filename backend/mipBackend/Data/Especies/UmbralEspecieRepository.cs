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
    public class UmbralEspecieRepository : IUmbralEspecieRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public UmbralEspecieRepository(
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

        public async Task<IEnumerable<UmbralEspecieResponseDto>> GetUmbralEspecie(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from eum in db.esp05Umbrales
                                   join esp1 in db.esp01especies! on eum.esp01llave equals esp1.esp01llave
                                   join esp in db.esp03especieBases! on esp1.esp03llave equals esp.esp03llave
                                   join tip in db.esp04EstadoDanios! on esp1.esp04llave equals tip.esp04llave
                                   join umb in db.esp09TipoBaseUmbrales! on eum.esp09llave equals umb.esp09llave
                                   where esp.esp03llave == id
                                   select new UmbralEspecieResponseDto
                                   {
                                       esp05llave = eum.esp05llave,
                                       esp01llave = esp1.esp01llave,
                                       esp03llave = esp.esp03llave,
                                       esp03nombre = esp.esp03nombre,
                                       esp04llave = tip.esp04llave,
                                       esp04nombre = tip.esp04nombre,
                                       esp05color = eum.esp05Color,
                                       esp05minumbral = eum.esp05MinUmbral, 
                                       esp05maxumbral = eum.esp05MaxUmbral,
                                       esp09llave = umb.esp09llave,
                                       esp09nombre = umb.esp09nombre,
                                       esp05activo = eum.esp05activo

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<UmbralEspecieResponseDto>>(query);

            }
        }

        public async Task<IEnumerable<UmbralEspecieResponseDto>> GetUmbralEspecieById(int id)
        {
            using (var db = _contexto)
            {
                var findId = await db.esp01especies!
               .FirstOrDefaultAsync(x => x.esp01llave == id);

                var query = GetUmbralEspecie(id);

                return _mapper.Map<IEnumerable<UmbralEspecieResponseDto>>(query);

            }
        }

        public async Task<esp05Umbral> GetUmbralEspecieByIdUMbral(int id)
        {
            var umbralespecie = await _contexto.esp05Umbrales!
               .FirstOrDefaultAsync(x => x.esp05llave == id);

            return umbralespecie;
        }

        public async Task CreateUmbralEspecie(esp05Umbral umbralespecie)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (umbralespecie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            umbralespecie.fechaactivacion = DateTime.Now;
            umbralespecie.createby = usuario.Id;
            umbralespecie.esp05activo = 1;

            await _contexto.esp05Umbrales!.AddAsync(umbralespecie);

        }

        public async Task DeleteUmbralEspecie(int id)
        {

            var umbralespecie = await _contexto.esp05Umbrales!
                .FirstOrDefaultAsync(x => x.esp05llave == id);
    
            _contexto.esp05Umbrales!.Remove(umbralespecie!);

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }
    }
}
