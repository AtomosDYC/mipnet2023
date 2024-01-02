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
    public class ReglaEspecieRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public ReglaEspecieRepository(
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

        public async Task<IEnumerable<ReglaEspecieResponseDto>> GetReglaEspecie(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from reg in db.esp11ReglaGraficos
                                   join esp3 in db.esp03especieBases! on reg.esp03llave equals esp3.esp03llave
                                   join treg in db.esp10TipoReglas! on reg.esp10llave equals treg.esp10llave
                                   where esp3.esp03llave == id
                                   select new ReglaEspecieResponseDto
                                   {
                                       esp03llave = esp3.esp03llave,
                                       esp03nombre = esp3.esp03nombre,
                                       esp10llave = treg.esp10llave,
                                       esp10nombre = treg.esp10nombre,
                                       esp11llave = reg.esp11llave,
                                       esp11nombre = reg.esp11nombre,
                                       esp11signo1 = reg.esp11signo1,
                                       esp11signo2 = reg.esp11signo2,
                                       esp11signoresultado = reg.esp11signoresultado,
                                       esp11valor1 = reg.esp11valor1,
                                       esp11valor2 = reg.esp11valor2,
                                       esp11estado = reg.esp11estado,
                                       esp11valorresultado = reg.esp11valorresultado

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<ReglaEspecieResponseDto>>(query);

            }
        }

        public async Task<IEnumerable<ReglaEspecieResponseDto>> GetReglaEspecieById(int id)
        {
            using (var db = _contexto)
            {
                var findId = await db.esp01especies!
               .FirstOrDefaultAsync(x => x.esp01llave == id);

                var query = GetReglaEspecie(id);

                return _mapper.Map<IEnumerable<ReglaEspecieResponseDto>>(query);

            }
        }

        public async Task<esp11ReglaGrafico> GetReglaEspecieByIdUMbral(int id)
        {
            var ReglaEspecie = await _contexto.esp11ReglaGraficos!
               .FirstOrDefaultAsync(x => x.esp11llave == id);

            return ReglaEspecie;
        }

        public async Task CreateReglaEspecie(esp11ReglaGrafico ReglaEspecie)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (ReglaEspecie is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            ReglaEspecie.fechaactivacion = DateTime.Now;
            ReglaEspecie.createby = usuario.Id;
            ReglaEspecie.esp11estado = 1;

            await _contexto.esp11ReglaGraficos!.AddAsync(ReglaEspecie);

        }

        public async Task DeleteReglaEspecie(int id)
        {

            var ReglaEspecie = await _contexto.esp11ReglaGraficos!
                .FirstOrDefaultAsync(x => x.esp11llave == id);

            _contexto.esp11ReglaGraficos!.Remove(ReglaEspecie!);

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }
    }
}
