using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using System.Net;
using mipBackend.Dtos.WorkflowParametrosDtos;
using AutoMapper;

namespace mipBackend.Data.WorkflowParametros
{
    public class WorkflowParametroRepository : IWorkflowParametroRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public WorkflowParametroRepository(
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



        public async Task CreateWorkflowParametro(Wkf09Parametro workflowparametro)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (workflowparametro is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            workflowparametro.fechaactivacion = DateTime.Now;
            workflowparametro.createby = Guid.Parse(usuario.Id);
            workflowparametro.wkf09activo = 1;

            await _contexto.Wkf09Parametros!.AddAsync(workflowparametro);

        }

        public async Task<Wkf09Parametro> GetWorkflowParametroById(int id)
        {
            return await _contexto.Wkf09Parametros!.FirstOrDefaultAsync(x => x.wkf09llave == id!)!;
        }


        public async Task DeleteWorkflowParametro(int id)
        {

            var workflowparametro = await _contexto.Wkf09Parametros!
                .FirstOrDefaultAsync(x => x.wkf09llave == id);

            _contexto.Wkf09Parametros!.Remove(workflowparametro!);
        }

        public async Task<IEnumerable<WorkflowParametroResponseDto>> GetAllWorkflowParametros(int id)
        {

            using (var db = _contexto)
            {
                var query = await (from wkp in db.Wkf09Parametros
                                   join wk in db.Wkf01Flujos! on wkp.wkf01llave equals wk.wkf01llave
                                   join tp in db.Wkf10TipoParametros! on wkp.wkf10llave equals tp.wkf10llave
                                   where wk.wkf01llave == id
                                   select new WorkflowParametroResponseDto
                                   {
                                       wkf09llave = wkp.wkf09llave,
                                       wkf01llave = wkp.wkf01llave,
                                       wkf10llave = wkp.wkf10llave,
                                       wkf10nombre = tp.wkf10nombre,
                                       wkf09variable = wkp.wkf09variable,
                                       wkf09valor = wkp.wkf09valor,
                                       wkf09activo = wkp.wkf09activo,
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<WorkflowParametroResponseDto>>(query);

            }
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

    }
}
