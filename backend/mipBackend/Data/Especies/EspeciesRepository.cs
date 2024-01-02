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
    public class EspeciesRepository : IEspeciesRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public EspeciesRepository(
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


       
        public async Task<IEnumerable<EspecieResponseDto>> GetAllEspecies()
        {
            using (var db = _contexto)
            {
                var query = await (from esp in db.esp03especieBases
                                   join tip in db.esp08TipoBases! on esp.esp08llave equals tip.esp08llave
                                   select new EspecieResponseDto
                                   {
                                       
                                       esp03llave = esp.esp03llave,
                                       esp03nombre = esp.esp03nombre,
                                       esp03descripcion = esp.esp03descripcion,
                                       esp03activo = esp.esp03activo,
                                       esp08llave = esp.esp08llave,
                                       esp08nombre = tip.esp08nombre

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<EspecieResponseDto>>(query);

            }
        }

        public async Task<EspecieResponseDto> GetEspecieById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from esp in db.esp03especieBases
                                       join tip in db.esp08TipoBases! on esp.esp08llave equals tip.esp08llave
                                       where esp.esp03llave == id
                                       select new EspecieResponseDto
                                       {

                                           esp03llave = esp.esp03llave,
                                           esp03nombre = esp.esp03nombre,
                                           esp03descripcion = esp.esp03descripcion,
                                           esp03activo = esp.esp03activo,
                                           esp08llave = esp.esp08llave,
                                           esp08nombre = tip.esp08nombre

                                       }).FirstAsync();

                return _mapper.Map<EspecieResponseDto>(query);

            }
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task CreateDatosgenerales(esp03especieBase especie)
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

            especie.fechaactivacion = DateTime.Now;
            especie.createby = usuario.Id;
            especie.esp03EstadoRegistro = "AuBuCuDuEu";
            especie.esp03activo = 1;

            await _contexto.esp03especieBases!.AddAsync(especie);

        }

        public async Task UpdateDatosgenerales(EspecieResponseDto especie)
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

            var especieUpdate = await _contexto.esp03especieBases!
                .FirstOrDefaultAsync(x => x.esp03llave== especie.esp03llave);

            especieUpdate.esp08llave = especie.esp08llave;
            especieUpdate.esp03nombre = especie.esp03nombre;
            especieUpdate.esp03descripcion = especie.esp03descripcion;
            especieUpdate.esp03Union = especie.esp03Union;
            
            especieUpdate.fechaactivacion = DateTime.Now;
            especieUpdate.createby = usuario.Id;
            especieUpdate.esp03EstadoRegistro = "AuBuCuDuEu";
            especieUpdate.esp03activo = 1;

            _contexto.esp03especieBases!.Update(especieUpdate);

        }

        public async Task<IEnumerable<UnirEspecieResponseDto>> GetUnirEspecies(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from esp in db.esp03especieBases
                                   join uni in db.esp07Uniones! on esp.esp03llave equals uni.esp03llave
                                   join euni in db.esp03especieBases! on uni.esp03llaveUnion equals euni.esp03llave
                                   where esp.esp03llave == id
                                   select new UnirEspecieResponseDto
                                   {

                                       esp03llave = esp.esp03llave,
                                       esp03nombre = esp.esp03nombre,
                                       esp03llaveUnion = euni.esp03llave,
                                       esp0nombreunion = euni.esp03nombre

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<UnirEspecieResponseDto>>(query);

            }
        }

        public async Task CreateUnirespecie(esp07Union especie)
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

            await _contexto.esp07Uniones!.AddAsync(especie);

        }

        public async Task DeleteUnirespecie(UnirEspecieRequestDto request)
        {

            var unirespecie = await _contexto.esp07Uniones!
                .FirstOrDefaultAsync(x => x.esp03llave == request.esp03llave && x.esp03llaveUnion == request.esp03llaveUnion );

             _contexto.esp07Uniones!.Remove(unirespecie!);
        }

    }
}
