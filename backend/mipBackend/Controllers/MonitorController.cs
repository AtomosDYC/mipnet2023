using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Monitores;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    { 
        private readonly IMonitorRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorController
            (

          
                IMonitorRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/monitor/getmonitores")]
        [ActionName(nameof(getmonitores))]
        public async Task<ActionResult<DataSourceResult>> getmonitores
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            var dataretorno = await _repository.GetAllMonitorDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitorResponseDto>>> GetMonitor()
        {

            var dataretorno = await _repository.GetAllMonitores();
            return Ok(_mapper.Map<IEnumerable<MonitorResponseDto>>(dataretorno));

        }


        [HttpGet("~/api/monitor/getmonitorbyid/{id}")]
        [ActionName(nameof(getmonitorbyid))]
        public async Task<ActionResult<MonitorResponseDto>> getmonitorbyid(int id)
        {


            var monitor = await _repository.GetMonitorById(id);

            if (monitor == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el Monitor por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<MonitorResponseDto>(monitor));

        }


        [HttpPost("~/api/monitor/createmonitor")]
        [ActionName(nameof(createmonitor))]
        public async Task<ActionResult> createmonitor
            (
               [FromBody] MonitorRequestDto request
            )
        {

            string llave = await _repository.CreateMonitores(request);
            await _repository.SaveChanges();

            var response = await _repository.GetMonitorById(int.Parse(llave));

            return Ok(response);

        }


        [HttpPut("~/api/monitor/updatemonitor")]
        [ActionName(nameof(updatemonitor))]
        public async Task<ActionResult<MonitorResponseDto>> updatemonitor
            (
                [FromBody] MonitorResponseDto request
            )
        {

            string llave = await _repository.UpdateMonitores(request);
            await _repository.SaveChanges();

            var response = await _repository.GetMonitorById(int.Parse(llave));

            return Ok(response);

        }

       


        [HttpDelete("~/api/monitor/deletemonitor/{id}")]
        [ActionName(nameof(deletemonitor))]
        public async Task<ActionResult> deletemonitor(int id)
        {

            await _repository.DeleteMonitores(id);
            await _repository.SaveChanges();
                
            return Ok();

        }

        [HttpPost("~/api/monitor/disablemonitor")]
        [ActionName(nameof(disablemonitor))]
        public async Task<ActionResult> disablemonitor
            (
                 [FromBody] MonitorResponseDto[] Monitores
            )
        {

            foreach (MonitorResponseDto item in Monitores)
            {
                

                await _repository.DisableMonitores(item.mnt01llave);
                await _repository.SaveChanges();
            }


            return Ok();

        }


        [HttpPost("~/api/monitor/activatemonitores")]
        [ActionName(nameof(activatemonitores))]
        public async Task<ActionResult> activatemonitores
            (
                 [FromBody] MonitorResponseDto[] Monitores
            )
        {

            foreach (MonitorResponseDto item in Monitores)
            {
                
                await _repository.ActivateMonitores(item.mnt01llave);
                await _repository.SaveChanges();
            }


            return Ok();

        }


    }
}
