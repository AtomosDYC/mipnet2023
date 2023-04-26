using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;
using mipBackend.Dtos.PlantillaFlujoDtos;
using AutoMapper;


namespace mipBackend.Data.Plantillas
{
    public class PlantillaFlujoRepository : IPlantillaFlujoRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public PlantillaFlujoRepository(
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



        public async Task CreatePlantilla(Prf04PlantillaFlujo plantilla)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (plantilla is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            await _contexto.Prf04PlantillaFlujos!.AddAsync(plantilla);

        }

        public async Task<IEnumerable<PlantillaFlujoResponseDto>> GetAllPlantillaFlujos()
        {

            using (var db = _contexto)
            {
                var query = await (from ppf in db.Prf04PlantillaFlujos!
                                   join pp in db.Prf03Plantillas! on ppf.prf03llave equals pp.prf03llave
                                   join wf in db.Wkf01Flujos! on ppf.wkf01llave equals wf.wkf01llave
                                   where (pp.prf03llave == 1 && wf.wkf01activo == 1)
                                   orderby wf.wkf01llavepadre, wf.wkf01orden,
                                   wf.wkf01prioridad

                                   select new PlantillaFlujoResponseDto
                                   {
                                       prf04llave = ppf.prf04llave,
                                       wkf01llave = wf.wkf01llave,
                                       wkf01nombre = wf.wkf01nombre,
                                       prf03llave = pp.prf03llave,
                                       prf03nombre = pp.prf03nombre,
                                       wkf01llavepadre = wf.wkf01llavepadre,

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<PlantillaFlujoResponseDto>>(query!);
            }

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }



    }
}
