using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using mipBackend.Dtos.SetSelectDtos;
using System.Net;


namespace mipBackend.Data.SetSelect
{
    public class SetSelectRepository : ISetSelectRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;

        public SetSelectRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
        }

        public async Task<IEnumerable<setSelect>> GetAllSelect(SetSelectRequestDto request)
        {
            var result = await _contexto.SetSelects!
                        .FromSqlInterpolated($"EXEC pa_Fill_ComboBox @tablename={request.tablename}")
                        .ToListAsync();

            return result;

        }

    }
}
