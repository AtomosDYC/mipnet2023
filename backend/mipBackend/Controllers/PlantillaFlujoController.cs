using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Plantillas;
using mipBackend.Dtos.PlantillaFlujoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillaFlujoController : Controller
    {
        private readonly IPlantillaFlujoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public PlantillaFlujoController
            (

                IPlantillaFlujoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantillaFlujoResponseDto>>> GetPlantilla()
        {

            var plantillas = await _repository.GetAllPlantillaFlujos();
            return Ok(_mapper.Map<IEnumerable<PlantillaFlujoResponseDto>>(plantillas));

        }



        [HttpPost]
        public async Task<ActionResult<PlantillaFlujoResponseDto>> CreatePlantilla
            (
               [FromBody] PlantillaFlujoRequestDto plantilla
            )
        {

            var plantillaModel = _mapper.Map<Prf04PlantillaFlujo>(plantilla);

            await _repository.CreatePlantilla(plantillaModel);
            await _repository.SaveChanges();

            var plantillaResponse = _mapper.Map<PlantillaFlujoResponseDto>(plantillaModel);

            /*var plantilladto = await _repository.GetPlantillaById(plantillaResponse.prf03llave);

            if (plantilladto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la plantilla por este id {plantillaResponse.prf03llave}" }
                    );
            }

            return Ok(_mapper.Map<PlantillaResponseDto>(plantilladto));
            */
            return Ok();

        }

        
    }
}
