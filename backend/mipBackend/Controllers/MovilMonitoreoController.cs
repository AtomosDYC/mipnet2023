using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Movils;
using mipBackend.Dtos.MovilDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovilMonitoreoController : ControllerBase
    {

        private readonly IMovilMonitoreoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MovilMonitoreoController
            (

                IMovilMonitoreoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/movil/getmovilmonitoreomantenimiento")]
        [ActionName(nameof(getmovilmonitoreomantenimiento))]
        public async Task<ActionResult<IEnumerable<MovilControlReservaResponseDto>>> getmovilmonitoreomantenimiento
           (
               [FromBody] MovilMonitoreoRequestDto requestModel
           )
        {

            var dataretorno = await _repository.mantenimiento_monitoreo(requestModel);
            return Ok(dataretorno);

        }

        [HttpPut("~/api/movil/reservar_registro_monitoreo")]
        [ActionName(nameof(reservar_registro_monitoreo))]
        public async Task<ActionResult<Int32>> reservar_registro_monitoreo()
        {

            var dataretorno = await _repository.reservar_registro_monitoreo();
            return Ok(dataretorno);

        }

        [HttpPost("~/api/movil/actualizar_registro_monitoreo")]
        [ActionName(nameof(actualizar_registro_monitoreo))]
        public async Task<ActionResult<Int32>> actualizar_registro_monitoreo(MovilMonitoreoActualizarRequest request)
        {

            var dataretorno = await _repository.actualizar_registro_monitoreo(request);
            return Ok(dataretorno);

        }




    }
}
