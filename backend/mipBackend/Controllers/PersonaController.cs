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
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public PersonaController
            (

                IPersonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/persona/getpersonas")]
        [ActionName(nameof(getpersonas))]
        public async Task<ActionResult<IEnumerable<PersonaResponseDto>>> getpersonas
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            var dataretorno = await _repository.GetAllPersonasDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaResponseDto>>> GetPersona()
        {

            var dataretorno = await _repository.GetAllPersonas();
            return Ok(_mapper.Map<IEnumerable<PersonaResponseDto>>(dataretorno));

        }

        [HttpGet("~/api/persona/getpersonabyid/{id}")]
        [ActionName(nameof(getpersonabyid))]
        public async Task<ActionResult<PersonaResponseDto>> getpersonabyid(int id)
        {


            var persona = await _repository.GetPersonaById(id);

            if (persona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Persona por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<PersonaResponseDto>(persona));

        }

        [HttpPost("~/api/persona/getpersonabyrut/")]
        [ActionName(nameof(getpersonabyrut))]
        public async Task<ActionResult<PersonaResponseDto>> getpersonabyrut
            (
                [FromBody] PersonaBuscarRutRepositoryDto buscador
            )
        {


            var persona = await _repository.GetPersonaByRut(buscador);

            if (persona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Persona por este id {buscador.per01rut}" }
                    );
            }

            return Ok(_mapper.Map<PersonaResponseDto>(persona));

        }


        [HttpPost("~/api/persona/createpersona")]
        [ActionName(nameof(createpersona))]
        public async Task<ActionResult<PersonaResponseDto>> createpersona
            (
               [FromBody] PersonaRequestDto request
            )
        {

            var personamodel = _mapper.Map<per01persona>(request);

            await _repository.CreatePersonas(personamodel);
            await _repository.SaveChanges();


            var personadto = await _repository.GetPersonaById(personamodel.per01llave);

            if (personadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el persona por este id {personadto.per01llave}" }
                    );
            }

            return Ok(_mapper.Map<PersonaResponseDto>(personadto));

        }


        [HttpPut("~/api/persona/updatepersona")]
        [ActionName(nameof(updatepersona))]
        public async Task<ActionResult<PersonaResponseDto>> updatepersona
            (
                [FromBody] PersonaResponseDto request
            )
        {

            var personaModel = _mapper.Map<per01persona>(request);

            await _repository.UpdatePersonas(personaModel);
            await _repository.SaveChanges();


            var personaDto = await _repository.GetPersonaById(request.per01llave);

            if (personaDto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el Persona por este id {personaDto.per01llave}" }
                    );
            }

            return Ok(_mapper.Map<PersonaResponseDto>(personaDto));

        }


        [HttpDelete("~/api/persona/deletepersona/{id}")]
        [ActionName(nameof(deletepersona))]
        public async Task<ActionResult<IEnumerable<PersonaResponseDto>>> deletepersona(int id)
        {

            await _repository.DeletePersonas(id);
            await _repository.SaveChanges();

            var list = await _repository.GetPersonaById(id);
            return Ok(_mapper.Map<IEnumerable<PersonaResponseDto>>(list));

        }


    }
}
