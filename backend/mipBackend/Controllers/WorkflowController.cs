using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Workflows;
using mipBackend.Dtos.WorkflowDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public WorkflowController
            (

                IWorkflowRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkflowResponseDto>>> GetWorkflows()
        {

            var workflow = await _repository.GetAllWorkflow();
            return Ok(workflow);

        }


        [HttpGet("~/api/workflow/GetWorkflowById/{id}")]
        [ActionName(nameof(GetWorkflowById))]
        public async Task<ActionResult<WorkflowResponseDto>> GetWorkflowById(int id)
        {


            var workflow = await _repository.GetWorkflowById(id);

            if (workflow == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(workflow));

        }



        [HttpPost]
        public async Task<ActionResult<WorkflowResponseDto>> CreateWorkflow
            (
               [FromBody] WorkflowRequestDto workflow
            )
        {

            var workflowModel = _mapper.Map<Wkf01Flujo>(workflow);

            await _repository.CreateDatosgenerales(workflowModel);
            await _repository.SaveChanges();

            var workflowResponse = _mapper.Map<WorkflowResponseDto>(workflowModel);

            var workflowdto = await _repository.GetWorkflowById(workflowResponse.wkf01llave);

            if (workflowdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {workflowResponse.wkf01llave}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(workflowdto));

        }

        
        [HttpPut]
        public async Task<ActionResult<WorkflowResponseDto>> UpdateDatosgenerales
            (
                [FromBody] WorkflowResponseDto request
            )
        {

            var workflowModel = _mapper.Map<Wkf01Flujo>(request);

            await _repository.UpdateDatosgenerales(workflowModel);
            await _repository.SaveChanges();

            var WorkflowResponse = _mapper.Map<WorkflowResponseDto>(workflowModel);

            var Workflowdto = await _repository.GetWorkflowById(WorkflowResponse.wkf01llave);

            if (Workflowdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {WorkflowResponse.wkf01llave}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(Workflowdto));

        }


        [HttpPut("~/api/workflow/UpdateNodopadre")]
        [ActionName(nameof(UpdateNodopadre))]
        public async Task<ActionResult<WorkflowResponseDto>> UpdateNodopadre
            (
                [FromBody] WorkflowNodopadreRequestDto request
            )
        {

             var workflowModel = _mapper.Map<Wkf01Flujo>(request);

            await _repository.UpdateNodopadre(workflowModel);
            await _repository.SaveChanges();

            var WorkflowResponse = _mapper.Map<WorkflowResponseDto>(workflowModel);

            var Workflowdto = await _repository.GetWorkflowById(WorkflowResponse.wkf01llave);

            if (Workflowdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {WorkflowResponse.wkf01llave}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(Workflowdto));

        }


        [HttpGet("~/api/workflow/GetWorkflowNodopadreById/{id}")]
        [ActionName(nameof(GetWorkflowNodopadreById))]
        public async Task<ActionResult<WorkflowResponseDto>> GetWorkflowNodopadreById(int id)
        {

            var workflow = await _repository.GetWorkflowNodopadreById(id);

            if (workflow == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(workflow));

        }



        [HttpPut("~/api/workflow/UpdateConfiguracionWeb")]
        [ActionName(nameof(UpdateConfiguracionWeb))]
        public async Task<ActionResult<WorkflowResponseDto>> UpdateConfiguracionWeb
            (
                [FromBody] WorkflowConfiguracionwebDto request
            )
        {

            var workflowModel = _mapper.Map<Wkf01Flujo>(request);

            await _repository.UpdateConfiguracionWeb(workflowModel);
            await _repository.SaveChanges();

            var WorkflowResponse = _mapper.Map<WorkflowResponseDto>(workflowModel);

            var Workflowdto = await _repository.GetWorkflowById(WorkflowResponse.wkf01llave);

            if (Workflowdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {WorkflowResponse.wkf01llave}" }
                    );
            }

            return Ok(_mapper.Map<WorkflowResponseDto>(Workflowdto));

        }


    }
}
