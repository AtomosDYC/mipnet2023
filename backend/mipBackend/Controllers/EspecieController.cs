using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Especies;
using mipBackend.Dtos.EspecieDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspeciesRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public EspecieController
            (

                IEspeciesRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecieResponseDto>>> GetEspecies()
        {

            var tipoespcies = await _repository.GetAllEspecies();
            return Ok(_mapper.Map<IEnumerable<EspecieResponseDto>>(tipoespcies));

        }

        [HttpGet("~/api/especie/GetEspecieById/{id}")]
        [ActionName(nameof(GetEspecieById))]
        public async Task<ActionResult<EspecieResponseDto>> GetEspecieById(int id)
        {


            var especie = await _repository.GetEspecieById(id);

            if (especie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipode especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<EspecieResponseDto>(especie));

        }

 
        [HttpPost("~/api/especie/createdatosgenerales")]
        [ActionName(nameof(createdatosgenerales))]
        public async Task<ActionResult<EspecieResponseDto>> createdatosgenerales
            (
               [FromBody] DatosgeneralesRequestDto request
            )
        {

            var especieModel = _mapper.Map<esp03especieBase>(request);

            await _repository.CreateDatosgenerales(especieModel);
            await _repository.SaveChanges();


            var especiedto = await _repository.GetEspecieById(especieModel.esp03llave);

            if (especiedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {especieModel.esp03llave}" }
                    );
            }

            return Ok(_mapper.Map<EspecieResponseDto>(especiedto));

        }
         

        [HttpPut("~/api/especie/updatedatosgenerales")]
        [ActionName(nameof(updatedatosgenerales))]
        public async Task<ActionResult<EspecieResponseDto>> updatedatosgenerales
            (
                [FromBody] EspecieResponseDto request
            )
        {

            var especieModel = _mapper.Map<esp03especieBase>(request);

            await _repository.UpdateDatosgenerales(request);
            await _repository.SaveChanges();

            
            var especieResponse = await _repository.GetEspecieById(request.esp03llave);

            if (especieResponse == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Tipopersona por este id {especieResponse.esp03llave}" }
                    );
            }

            return Ok(_mapper.Map<EspecieResponseDto>(especieResponse));

        }

        [HttpGet("~/api/especie/GetUnirEspeciesById/{id}")]
        [ActionName(nameof(GetUnirEspeciesById))]
        public async Task<ActionResult<IEnumerable<UnirEspecieResponseDto>>> GetUnirEspeciesById(int id)
        {


            var especie = await _repository.GetUnirEspecies(id);

            if (especie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipode especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map< IEnumerable<UnirEspecieResponseDto>>(especie));

        }



        [HttpPost("~/api/especie/createunirespecie")]
        [ActionName(nameof(createunirespecie))]
        public async Task<ActionResult<IEnumerable<UnirEspecieResponseDto>>> createunirespecie
            (
               [FromBody] UnirEspecieRequestDto request
            )
        {

            var especieModel = _mapper.Map<esp07Union>(request);

            await _repository.CreateUnirespecie(especieModel);
            await _repository.SaveChanges();

            var UnirEspecie = _mapper.Map<esp07Union>(especieModel);


            var especiedto = await _repository.GetUnirEspecies(UnirEspecie.esp03llave);
            

            if (especiedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {especieModel.esp03llave}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<UnirEspecieResponseDto>>(especiedto));

        }


        [HttpDelete("~/api/especie/DeleteUnirespecie/{id}")]
        [ActionName(nameof(DeleteUnirespecie))]
        public async Task<ActionResult<IEnumerable<UnirEspecieResponseDto>>> DeleteUnirespecie(UnirEspecieRequestDto request)
        {

            
            await _repository.DeleteUnirespecie(request);
            await _repository.SaveChanges();
            


            var list = await _repository.GetUnirEspecies(request.esp03llave);
            return Ok(_mapper.Map<IEnumerable<UnirEspecieResponseDto>>(list));

        }


    }
}
