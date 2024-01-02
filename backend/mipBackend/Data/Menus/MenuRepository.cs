using mipBackend.Dtos.MenuDtos;
using mipBackend.Models;
using mipBackend.Token;
using Microsoft.AspNetCore.Identity;
using System.Net;
using AutoMapper;


using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;

namespace mipBackend.Data.Menus
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _contexto;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IUsuarioSesion _usuarioSesion;
        private IMapper _mapper;


        public MenuRepository(
           UserManager<Usuario> userManager,
           SignInManager<Usuario> signInManager,
           IJwtGenerador jwtGenerador,
           AppDbContext contexto,
           IUsuarioSesion usuarioSesion,
           IMapper mapper
           )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _contexto = contexto;
            _usuarioSesion = usuarioSesion;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuResponseDto>> GetMenu()
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            using (var db = _contexto)
            {
                var query = await (from usr in db.Users!
                                   join prf in db.prf01perfiles! on usr.Id equals prf.userid
                                   join prf3 in db.prf03Plantillas! on prf.prf03llave equals prf3.prf03llave
                                   join prf4 in db.prf04PlantillaFlujos! on prf3.prf03llave equals prf4.prf03llave
                                   join wkf in db.wkf01Flujos! on prf4.wkf01llave equals wkf.wkf01llave


                                   where (prf.prf01activo == 1 && prf3.prf03activo == 1 && wkf.wkf01activo == 1)
                                   where (usr.Id == usuario.Id)
                                   orderby wkf.wkf01llavepadre, wkf.wkf01prioridad, wkf.wkf01orden

                                   select new MenuResponseDto
                                   {

                                       id = wkf.wkf01llave,
                                       parentId = wkf.wkf01llavepadre,
                                       text = wkf.wkf01nombre,
                                       path = wkf.wkf01url,
                                       icon = null,
                                       selected = false,

                                   }).ToListAsync();


                return _mapper.Map<IEnumerable<MenuResponseDto>>(query!);

            }

        }

    }
}
