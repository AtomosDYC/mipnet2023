using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Monitores;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorComunicacionController : ControllerBase
    {
        private readonly IMonitorComunicacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorComunicacionController
            (

                IMonitorComunicacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/monitor/getmonitorcomunicacion")]
        [ActionName(nameof(getmonitorcomunicacion))]
        public async Task<ActionResult<IEnumerable<MonitorComunicacionResponseDto>>> getmonitorcomunicacion
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllMonitorComunicacionDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/monitor/getmonitorcomunicacionbyid")]
        [ActionName(nameof(getmonitorcomunicacionbyid))]
        public async Task<ActionResult<MonitorResponseDto>> getmonitorcomunicacionbyid(
            [FromBody] MonitorComunicacionbyidRequestDto request)
        {

            var monitor = await _repository.GetMonitorComunicacionById(request);

            if (monitor == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el los datos de comunicacion del monitor" }
                    );
            }

            return Ok(_mapper.Map<MonitorComunicacionResponseDto>(monitor));

        }


        [HttpPost("~/api/monitor/createmonitorcomunicacion")]
        [ActionName(nameof(createmonitorcomunicacion))]
        public async Task<ActionResult<MonitorComunicacionResponseDto>> createmonitorcomunicacion
           (
              [FromBody] MonitorComunicacionRequestDto request
           )
        {

            await _repository.CreateMonitorComunicacion(request);
            await _repository.SaveChanges();

            var requestsearch = new MonitorComunicacionbyidRequestDto();
            requestsearch.per01llave = request.per01llave;
            requestsearch.per04llave = request.per04llave;

            var personadto = await _repository.GetMonitorComunicacionById(requestsearch);

            if (personadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el persona por este id {personadto.per01llave}" }
                    );
            }

            return Ok(_mapper.Map<MonitorComunicacionResponseDto>(personadto));

        }

        [HttpPost("~/api/monitor/deletemonitorcomunicacion")]
        [ActionName(nameof(deletemonitorcomunicacion))]
        public async Task<ActionResult> deletemonitorcomunicacion(MonitorComunicacionbyidRequestDto request)
        {

            await _repository.DeleteMonitorComunicacion(request);
            await _repository.SaveChanges();

            return Ok();

        }
    }
}
