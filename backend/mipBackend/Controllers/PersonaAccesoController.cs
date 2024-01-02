using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Personas;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaAccesoController : ControllerBase
    {

        private readonly IPersonaAccesoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public PersonaAccesoController
            (

                IPersonaAccesoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("~/api/persona/getpersonaacceso/{id}")]
        [ActionName(nameof(getpersonaacceso))]
        public async Task<ActionResult<PersonaAccesoResponseDto>> getpersonaacceso
           (
               int id
           )
        {

            PersonaAccesoResponseDto? dataretorno = await _repository.GetPersonaAccesoById(id);
            return Ok(dataretorno);

        }


        

        [HttpPost("~/api/persona/createpersonaacceso")]
        [ActionName(nameof(createpersonaacceso))]
        public async Task<ActionResult> createpersonaacceso
            (
               [FromBody] PersonaAccesoRequestDto request
            )
        {

            await _repository.RegistroPersonaAcceso(request);
            await _repository.SaveChanges();

            return Ok();

        }

    }
}
