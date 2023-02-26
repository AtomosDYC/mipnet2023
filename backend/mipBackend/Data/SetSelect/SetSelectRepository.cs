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

            string? tablename = request.tablename;
            string? prm1 = request.prm1;
            string? prm2 = request.prm2;


            //var result = await _contexto.SetSelects!
            //            .FromSqlInterpolated($"EXEC pa_Fill_ComboBox @tablename={tablename} @prm1={prm1}, @prm2={prm2}, @prm3={request.prm3}, @prm4={request.prm4}, @prm5={request.prm5} ")
            //            .ToListAsync();


            var result = await _contexto.SetSelects!
                        .FromSqlInterpolated($"EXEC pa_Fill_ComboBox {tablename}, {prm1}, {prm2}, {request.prm3}, {request.prm4}, {request.prm5}, {request.prm6}, {request.prm7}, {request.prm8}, {request.prm9}, {request.prm10}, {request.prm9}, {request.prm10} ")
                        .ToListAsync();


            return result;

        }

    }
}
