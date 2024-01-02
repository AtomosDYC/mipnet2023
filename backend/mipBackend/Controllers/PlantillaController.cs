using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Plantillas;
using mipBackend.Dtos.PlantillaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillaController : ControllerBase
    {

        private readonly IPlantillaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public PlantillaController
            (

                IPlantillaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantillaResponseDto>>> GetPlantilla()
        {

            var plantillas = await _repository.GetAllPlantillas();
            return Ok(_mapper.Map<IEnumerable<PlantillaResponseDto>>(plantillas));

        }

        [HttpGet("~/api/Plantilla/GetPlantillaById/{id}")]
        [ActionName(nameof(GetPlantillaById))]
        public async Task<ActionResult<PlantillaResponseDto>> GetPlantillaById(int id)
        {

            
            var plantilla = await _repository.GetPlantillaById(id);

            if (plantilla == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la plantilla por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<PlantillaResponseDto>(plantilla));

        }

        [HttpPost]
        public async Task<ActionResult<PlantillaResponseDto>> CreatePlantilla
            (
               [FromBody] PlantillaRequestDto plantilla
            )
        {

            var plantillaModel = _mapper.Map<prf03Plantilla>(plantilla);

            await _repository.CreatePlantilla(plantillaModel);
            await _repository.SaveChanges();

            var plantillaResponse = _mapper.Map<PlantillaResponseDto>(plantillaModel);

            var plantilladto = await _repository.GetPlantillaById(plantillaResponse.prf03llave);

            if (plantilladto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la plantilla por este id {plantillaResponse.prf03llave}" }
                    );
            }

            return Ok(_mapper.Map<PlantillaResponseDto>(plantilladto));



        }

        [HttpPut]
        public async Task<ActionResult<PlantillaResponseDto>> UpdatePlantilla
            (
                [FromBody] PlantillaResponseDto plantilla
            )
        {

            var plantillaModel = _mapper.Map<prf03Plantilla>(plantilla);

            await _repository.UpdatePlantilla(plantillaModel);
            await _repository.SaveChanges();

            var plantillaResponse = _mapper.Map<PlantillaResponseDto>(plantillaModel);

            var plantilladto = await _repository.GetPlantillaById(plantillaResponse.prf03llave);

            if (plantilladto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la plantilla por este id {plantillaResponse.prf03llave}" }
                    );
            }

            return Ok(_mapper.Map<PlantillaResponseDto>(plantilladto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlantilla(int id)
        {

            var plantilladto = await _repository.GetPlantillaById(id);

            if (plantilladto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la plantilla por este id {id}" }
                );
            } 
            else 
            { 
                if (plantilladto.prf03activo == 0)
                {
                    await _repository.DeletePlantilla(id);
                    await _repository.SaveChanges();
                } 
                else
                {
                    await _repository.DisablePlantilla(id);
                    await _repository.SaveChanges();
                }
            }


            var listplantillas = await _repository.GetAllPlantillas();
            return Ok(_mapper.Map<PlantillaResponseDto[]>(listplantillas));

        }

        [HttpPost("~/api/plantilla/disableplantilla")]
        public async Task<ActionResult<PlantillaResponseDto[]>> DisablePlantilla
            (
                 [FromBody] PlantillaResponseDto[] plantillas
            )
        {

            foreach (PlantillaResponseDto item in plantillas)
            {
                var a = _mapper.Map<PlantillaResponseDto>(item);

                await _repository.DisablePlantilla(a.prf03llave);
                await _repository.SaveChanges();
            }


            var listplantillas = await _repository.GetAllPlantillas();
            return Ok(_mapper.Map<PlantillaResponseDto[]>(listplantillas));
            
        }


        [HttpPost("~/api/Plantilla/ActivatePlantilla")]
        public async Task<ActionResult<PlantillaResponseDto[]>> ActivatePlantilla
            (
                 [FromBody] PlantillaResponseDto[] plantillas
            )
        {

            foreach (PlantillaResponseDto item in plantillas)
            {
                var a = _mapper.Map<PlantillaResponseDto>(item);

                await _repository.ActivatePlantilla(a.prf03llave);
                await _repository.SaveChanges();
            }


            var listplantillas = await _repository.GetAllPlantillas();
            return Ok(_mapper.Map<PlantillaResponseDto[]>(listplantillas));

        }
        
    }
}