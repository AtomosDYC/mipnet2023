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
    public class PersonaComunicacionController  : ControllerBase
    {
        private readonly IPersonaComunicacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public PersonaComunicacionController
            (

                IPersonaComunicacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/persona/getpersonacomunicacion")]
        [ActionName(nameof(getpersonacomunicacion))]
        public async Task<ActionResult<IEnumerable<PersonaComunicacionResponseDto>>> getpersonacomunicacion
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllPersonaComunicacionDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/persona/createpersonacomunicacion")]
        [ActionName(nameof(createpersonacomunicacion))]
        public async Task<ActionResult<PersonaComunicacionResponseDto>> createpersonacomunicacion
            (
               [FromBody] PersonaComunicacionRequestDto request
            )
        {

            var personamodel = _mapper.Map<per05Comunicacion>(request);

            await _repository.CreatePersonaComunicacion(personamodel);
            await _repository.SaveChanges();

            var requestsearch = new PersonaComunicacionbyidRequestDto();
            requestsearch.per01llave = request.per01llave;
            requestsearch.per04llave = request.per04llave;

            var personadto = await _repository.GetPersonaComunicacionById(requestsearch);

            if (personadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el persona por este id {personadto.per01llave}" }
                    );
            }

            return Ok(_mapper.Map<PersonaComunicacionResponseDto>(personadto));

        }

        [HttpPost("~/api/persona/deletepersonacomunicacion")]
        [ActionName(nameof(deletepersonacomunicacion))]
        public async Task<ActionResult> deletepersonacomunicacion(PersonaComunicacionbyidRequestDto request)
        {

            await _repository.DeletePersonaComunicacion(request);
            await _repository.SaveChanges();

            return Ok();

        }

    }
}
