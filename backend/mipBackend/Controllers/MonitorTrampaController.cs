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
    public class MonitorTrampaController : ControllerBase
    {
        private readonly IMonitorTrampaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorTrampaController
            (

                IMonitorTrampaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/monitor/getmonitortrampa")]
        [ActionName(nameof(getmonitortrampa))]
        public async Task<ActionResult<IEnumerable<DataSourceResult>>> getmonitortrampa
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllMonitorTrampaDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/monitor/getbuscartrampa")]
        [ActionName(nameof(getbuscartrampa))]
        public async Task<ActionResult<IEnumerable<MonitorTrampaBuscarResponseDto>>> getbuscartrampa
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            var dataretorno = await _repository.GetAllMonitorTrampaBuscadorDatasourceRaw(requestModel);
            return Ok(dataretorno);

        }


        [HttpPost("~/api/monitor/asignartrampa")]
        [ActionName(nameof(asignartrampa))]
        public async Task<ActionResult> asignartrampa
           (
               [FromBody] MonitorAsignarTrampaRequestDto[] requestModel
           )
        {

            foreach (MonitorAsignarTrampaRequestDto item in requestModel)
            {
                await _repository.asignarTrampas(item);
                await _repository.SaveChanges();
            }

            
            return Ok();

        }


        [HttpGet("~/api/monitor/replicartemporada/{id}")]
        [ActionName(nameof(replicartemporada))]
        public async Task<ActionResult> replicartemporada
           (
               int id
           )
        {

            await _repository.replicarTrampas(id);
            
            return Ok();

        }



    }
}
