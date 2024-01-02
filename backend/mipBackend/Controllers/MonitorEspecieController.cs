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
    public class MonitorEspecieController : ControllerBase
    {
        private readonly IMonitorEspecieRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorEspecieController
            (

                IMonitorEspecieRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/monitor/getmonitorespecie")]
        [ActionName(nameof(getmonitorespecie))]
        public async Task<ActionResult<IEnumerable<MonitorComunicacionResponseDto>>> getmonitorespecie
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllMonitorEspecieDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/monitor/createmonitorespecie")]
        [ActionName(nameof(createmonitorespecie))]
        public async Task<ActionResult> createmonitorespecie
           (
              [FromBody] MonitorEspecieRequestDto request
           )
        {

            await _repository.CreateMonitorEspecie(request);
            await _repository.SaveChanges();

            return Ok();

        }

        [HttpPost("~/api/monitor/deletemonitorespecie")]
        [ActionName(nameof(deletemonitorespecie))]
        public async Task<ActionResult<IEnumerable<MonitorResponseDto>>> deletemonitorespecie
            (
                [FromBody] MonitorEspecieRequestDto request
            )
        {

            await _repository.DeleteMonitorEspecie(request);
            await _repository.SaveChanges();

            return Ok();

        }
    }
}
