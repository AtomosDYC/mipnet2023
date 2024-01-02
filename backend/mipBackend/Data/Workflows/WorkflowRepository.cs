using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.WorkflowDtos;

namespace mipBackend.Data.Workflows
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public WorkflowRepository(
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

        public async Task<IEnumerable<WorkflowResponseDto>> GetAllWorkflow()
        {
            using (var db = _contexto)
            {
                var query = await (from wf in db.wkf01Flujos!
                                   join niv in db.wkf03Niveles! on wf.wkf03llave equals niv.wkf03llave
                                   join tip in db.wkf02TipoFlujos! on niv.wkf02llave equals tip.wkf02llave
                                   where (niv.wkf03activo== 1 && wf.wkf01activo == 1 && tip.wkf02activo == 1)
                                   orderby wf.wkf01llavepadre, wf.wkf01orden,
                                   wf.wkf01prioridad
                                   
                                   select new WorkflowResponseDto
                                   {
                                       wkf01llave = wf.wkf01llave,
                                       wkf01nombre = wf.wkf01nombre,
                                       wkf01descripcion = wf.wkf01descripcion,
                                       wkf01llavepadre = wf.wkf01llavepadre,
                                       wkf02llave = tip.wkf02llave,
                                       wkf02nombre = tip.wkf02nombre,
                                       wkf03llave = niv.wkf03llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf01esinicio = wf.wkf01esinicio,
                                       wkf01orden = wf.wkf01orden,
                                       wkf01prioridad = wf.wkf01prioridad,
                                       wkf01activo = wf.wkf01activo,
                                       wkf01directorio = wf.wkf01nombre,
                                       wkf01url = wf.wkf01nombre,
                                       wkf01iconourl = wf.wkf01nombre,
                                       wkf01visiblemenu = wf.wkf01llave,
                                       wkf01imagengrande = wf.wkf01nombre,
                                       wkf01imagenpequena = wf.wkf01nombre,
                                       wkf01estadoregistro = wf.wkf01nombre,
                                       
                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<WorkflowResponseDto>>(query!);

            }
        }

        public async Task<WorkflowResponseDto> GetWorkflowById(int id)
        {
            using (var db = _contexto)
            {

                var query = await (from wf in db.wkf01Flujos!
                                   join niv in db.wkf03Niveles! on wf.wkf03llave equals niv.wkf03llave
                                   join tip in db.wkf02TipoFlujos! on niv.wkf02llave equals tip.wkf02llave
                                   join wf2 in db.wkf01Flujos! on wf.wkf01llavepadre equals wf2.wkf01llave into nubpadres 
                                   from ct in nubpadres.DefaultIfEmpty()
                                   join niv2 in db.wkf03Niveles! on ct.wkf03llave equals niv2.wkf03llave into nubnivel
                                   from nt in nubnivel.DefaultIfEmpty()
                                   join tip2 in db.wkf02TipoFlujos! on nt.wkf02llave equals tip2.wkf02llave into nubtipo
                                   from tt in nubtipo.DefaultIfEmpty()
                                   where (niv.wkf03activo == 1 && wf.wkf01activo == 1 && tip.wkf02activo == 1)
                                   where (wf.wkf01llave == id)
                                   select new WorkflowResponseDto
                                   {
                                       wkf01llave = wf.wkf01llave,
                                       wkf01nombre = wf.wkf01nombre,
                                       wkf01descripcion = wf.wkf01descripcion,

                                       wkf01llavepadre = ct == null ? 0 : wf.wkf01llavepadre,
                                       wkf01llavepadrenombre = ct == null ? string.Empty : ct.wkf01nombre,

                                       wkf03llavepadre = nt == null ? 0 : nt.wkf03llave,
                                       wkf03llavepadrenombre = nt == null ? string.Empty : nt.wkf03nombre,

                                       wkf02llavepadre = tt == null ? 0 : tt.wkf02llave,
                                       wkf02llavepadrenombre = tt == null ? string.Empty : tt.wkf02nombre,


                                       wkf02llave = tip.wkf02llave,
                                       wkf02nombre = tip.wkf02nombre,
                                       wkf03llave = niv.wkf03llave,
                                       wkf03nombre = niv.wkf03nombre,
                                       wkf01esinicio = wf.wkf01esinicio,
                                       wkf01orden = wf.wkf01orden,
                                       wkf01prioridad = wf.wkf01prioridad,
                                       wkf01activo = wf.wkf01activo,
                                       wkf01directorio = wf.wkf01directorio,
                                       wkf01url = wf.wkf01url,
                                       wkf01iconourl = wf.wkf01iconourl,
                                       wkf01visiblemenu = wf.wkf01visiblemenu,
                                       wkf01imagengrande = wf.wkf01imagengrande,
                                       wkf01imagenpequena = wf.wkf01imagenpequena,
                                       wkf01estadoregistro = wf.wkf01estadoregistro,

                                   }).FirstAsync();

                return _mapper.Map<WorkflowResponseDto>(query!);

            }
        }


        public async Task CreateDatosgenerales(wkf01Flujo workflow)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (workflow is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            workflow.fechaactivacion = DateTime.Now;
            workflow.createby = usuario.Id;
            workflow.wkf01estadoregistro = "AuBuCuDuEu";
            workflow.wkf01activo = 1;

            await _contexto.wkf01Flujos!.AddAsync(workflow);

        }

        public async Task UpdateDatosgenerales(wkf01Flujo workflow)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (workflow is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var workflowUpdate = await _contexto.wkf01Flujos!
                .FirstOrDefaultAsync(x => x.wkf01llave == workflow.wkf01llave);

            workflowUpdate.wkf03llave = workflow.wkf03llave;
            workflowUpdate.wkf01nombre = workflow.wkf01nombre;
            workflowUpdate.wkf01descripcion = workflow.wkf01descripcion;
            workflowUpdate.wkf01esinicio = workflow.wkf01esinicio;
            workflowUpdate.wkf01orden = workflow.wkf01orden;
            workflowUpdate.wkf01prioridad   = workflow.wkf01prioridad;

            workflowUpdate.fechaactivacion = DateTime.Now;
            workflowUpdate.createby = usuario.Id;
            workflowUpdate.wkf01estadoregistro = "AuBuCuDuEu";
            workflowUpdate.wkf01activo = 1;

            _contexto.wkf01Flujos!.Update(workflowUpdate);
            
        }

        public async Task UpdateNodopadre(wkf01Flujo request)
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

            var workflow = await _contexto.wkf01Flujos!
                .FirstOrDefaultAsync(x => x.wkf01llave == request.wkf01llave);

            workflow.fechaactualizacion = DateTime.Now;
            workflow.approveby = usuario.Id;
            workflow.wkf01llavepadre = request.wkf01llavepadre;
            
            _contexto.wkf01Flujos!.Update(workflow!);

        }

        public async Task<WorkflowResponseDto> GetWorkflowNodopadreById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from wf in db.wkf01Flujos!
                                   join wf2 in db.wkf01Flujos on wf.wkf01llavepadre equals wf2.wkf01llave
                                   join niv2 in db.wkf03Niveles! on wf2.wkf03llave equals niv2.wkf03llave
                                   join tip2 in db.wkf02TipoFlujos! on niv2.wkf02llave equals tip2.wkf02llave
                                   where (niv2.wkf03activo == 1 && wf2.wkf01activo == 1 && tip2.wkf02activo == 1)
                                   where (wf.wkf01llave == id)
                                   select new WorkflowResponseDto
                                   {
                                       wkf01llavepadre = wf2.wkf01llave,
                                       wkf01llavepadrenombre = wf2.wkf01nombre,
                                       wkf02llave = tip2.wkf02llave,
                                       wkf02nombre = tip2.wkf02nombre,
                                       wkf03llave = niv2.wkf03llave,
                                       wkf03nombre = niv2.wkf03nombre

                                   }).FirstAsync();

                return _mapper.Map<WorkflowResponseDto>(query!);

            }
        }

        public async Task UpdateConfiguracionWeb(wkf01Flujo request)
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

            var workflow = await _contexto.wkf01Flujos!
                .FirstOrDefaultAsync(x => x.wkf01llave == request.wkf01llave);

            workflow.fechaactualizacion = DateTime.Now;
            workflow.approveby = usuario.Id;

            workflow.wkf01url = request.wkf01url;
            workflow.wkf01iconourl = request.wkf01iconourl;
            workflow.wkf01visiblemenu =  request.wkf01visiblemenu;
           
            _contexto.wkf01Flujos!.Update(workflow!);

        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

    }
}
