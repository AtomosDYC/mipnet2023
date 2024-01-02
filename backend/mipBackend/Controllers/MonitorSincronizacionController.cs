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
    public class MonitorSincronizacionController : ControllerBase
    {
        private readonly IMonitorSincronizacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorSincronizacionController
            (

                IMonitorSincronizacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/monitor/getmonitorsincronizacion")]
        [ActionName(nameof(getmonitorsincronizacion))]
        public async Task<ActionResult<IEnumerable<DataSourceResult>>> getmonitorsincronizacion
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllMonitorSincronizacionDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpGet("~/api/monitor/sincronizartodo/{id}")]
        [ActionName(nameof(sincronizartodo))]
        public async Task<ActionResult<IEnumerable<DataSourceResult>>> sincronizartodo
          (
              int monitorID
          )
        {

            int? dataretorno = await _repository.sincronizartodo(monitorID);
            return Ok(dataretorno);

        }
    }
}
