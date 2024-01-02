using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Monitores;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;


namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorAccesoController : ControllerBase
    {
        private readonly IMonitorAccesoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MonitorAccesoController
            (

                IMonitorAccesoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("~/api/monitor/getmonitoracceso/{id}")]
        [ActionName(nameof(getmonitoracceso))]
        public async Task<ActionResult<PersonaAccesoResponseDto>> getmonitoracceso
           (
               int id
           )
        {

            PersonaAccesoResponseDto? dataretorno = await _repository.GetMonitorAccesoById(id);
            return Ok(dataretorno);

        }




        [HttpPost("~/api/monitor/createmonitoracceso")]
        [ActionName(nameof(createmonitoracceso))]
        public async Task<ActionResult> createmonitoracceso
            (
               [FromBody] PersonaAccesoRequestDto request
            )
        {

            await _repository.RegistroMonitorAcceso(request);
            await _repository.SaveChanges();

            return Ok();

        }
    }
}
