using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.WorkflowParametros;
using mipBackend.Dtos.WorkflowParametrosDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowParametroController : ControllerBase
    {
        private readonly IWorkflowParametroRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public WorkflowParametroController
            (

                IWorkflowParametroRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("~/api/workflowparametro/GetWorkflowParametros/{id}")]
        [ActionName(nameof(GetWorkflowParametros))]
        public async Task<ActionResult<IEnumerable<WorkflowParametroResponseDto>>> GetWorkflowParametros(int id)
        {

            var WorkflowParametros = await _repository.GetAllWorkflowParametros(id);
            return Ok(_mapper.Map<IEnumerable<WorkflowParametroResponseDto>>(WorkflowParametros));

        }

       

        [HttpPost]
        public async Task<ActionResult<WorkflowParametroResponseDto>> CreateWorkflowParametro
            (
               [FromBody] WorkflowParametroRequestDto workflowparametro
            )
        {

            var workflowparametroModel = _mapper.Map<Wkf09Parametro>(workflowparametro);

            await _repository.CreateWorkflowParametro(workflowparametroModel);
            await _repository.SaveChanges();

            var WorkflowParametroResponse = _mapper.Map<WorkflowParametroResponseDto>(workflowparametroModel);

            var llave = workflowparametroModel.wkf01llave!;

            var workflowparametrodto = await _repository.GetAllWorkflowParametros(llave.Value);

            if (workflowparametrodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la WorkflowParametro por este id {WorkflowParametroResponse.wkf10llave}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<WorkflowParametroResponseDto>>(workflowparametrodto));



        }

       
        [HttpDelete("~/api/workflowparametro/DeleteWorkflowParametro/{id}")]
        [ActionName(nameof(DeleteWorkflowParametro))]
        public async Task<ActionResult> DeleteWorkflowParametro(int id)
        {

            var WorkflowParametrodto = await _repository.GetWorkflowParametroById(id);

            if (WorkflowParametrodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la WorkflowParametro por este id {id}" }
                );
            }
            else
            {
                    await _repository.DeleteWorkflowParametro(id);
                    await _repository.SaveChanges();
            }


            var listWorkflowParametros = await _repository.GetAllWorkflowParametros(WorkflowParametrodto.wkf01llave.Value!);
            return Ok(_mapper.Map<IEnumerable<WorkflowParametroResponseDto>>(listWorkflowParametros));

        }

        
    }
}
