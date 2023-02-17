using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Dtos.RolDtos;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;

namespace mipBackend.Data.Roles
{
    public class RolesRepository : IRolesRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;


        public RolesRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager
            )
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }

        
        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            return await _contexto.Roles!.ToListAsync();
        }

    }
}
