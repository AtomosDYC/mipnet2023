using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.ComunaDtos;

namespace mipBackend.Data.Comunas
{
    public class ComunaRepository : IComunaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public ComunaRepository(
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


        public async Task CreateComuna(sist03Comuna Comuna)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (Comuna is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            Comuna.fechaactivacion = DateTime.Now;
            Comuna.createby = usuario.Id;
            Comuna.sist03activo = 1;

            await _contexto.sist03Comunas!.AddAsync(Comuna);

        }

        public async Task DeleteComuna(int id)
        {




            var Comuna = await _contexto.sist03Comunas!
                .FirstOrDefaultAsync(x => x.sist03llave == id);

            _contexto.sist03Comunas!.Remove(Comuna!);
        }

        public async Task<IEnumerable<ComunaResponseDto>> GetAllComunas()
        {
            using (var db = _contexto)
            {
               var query = await (from com in db.sist03Comunas
                                   join reg in db.sist04Regiones! on com.sist04llave equals reg.sist04llave
                             select new ComunaResponseDto
                             {
                                 sist03llave = com.sist03llave,
                                 sist03nombre = com.sist03nombre,
                                 sist03descripcion = com.sist03descripcion,
                                 sist03capital = com.sist03capital,
                                 sist03activo = com.sist03activo,
                                 sist04llave = reg.sist04llave,
                                 sist04nombre = reg.sist04nombre
                                 }).ToListAsync();

                return _mapper.Map<IEnumerable<ComunaResponseDto>>(query);

            }        
        }

        public async Task<sist03Comuna> GetComunaById(int id)
        {
            return await _contexto.sist03Comunas!.FirstOrDefaultAsync(x => x.sist03llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateComuna(sist03Comuna request)
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

            var Comuna = await _contexto.sist03Comunas!
                .FirstOrDefaultAsync(x => x.sist03llave == request.sist03llave);

            Comuna.fechaactualizacion = DateTime.Now;
            Comuna.approveby = usuario.Id;
            Comuna.sist03nombre = request.sist03nombre;
            Comuna.sist03descripcion = request.sist03descripcion;
            Comuna.sist04llave = request.sist04llave;
            Comuna.sist03capital = request.sist03capital;
            
            _contexto.sist03Comunas!.Update(Comuna!);

        }

        public async Task DisableComuna(int id)
        {

            var Comuna = await _contexto.sist03Comunas!
                .FirstOrDefaultAsync(x => x.sist03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Comuna is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Comuna no existe en los listados" }
                   );
            }


            Comuna.sist03activo = 0;

            _contexto.sist03Comunas!.Update(Comuna);


        }

        public async Task ActivateComuna(int id)
        {

            var Comuna = await _contexto.sist03Comunas!
                .FirstOrDefaultAsync(x => x.sist03llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (Comuna is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "La Comuna no existe en los listados" }
                   );
            }


            Comuna.sist03activo = 1;

            _contexto.sist03Comunas!.Update(Comuna);


        }


    }
}
