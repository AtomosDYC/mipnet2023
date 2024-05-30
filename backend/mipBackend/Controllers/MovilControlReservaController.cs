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
    public class MovilControlReservaController : ControllerBase
    {

        private readonly IMovilControlReservaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MovilControlReservaController
            (

                IMovilControlReservaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/movil/getmovilcontrolreserva")]
        [ActionName(nameof(getmovilcontrolreserva))]
        public async Task<ActionResult<IEnumerable<MovilControlReservaResponseDto>>> getmovilcontrolreserva
           (
               [FromBody] MovilControlReservaRequestDto requestModel
           )
        {

            var dataretorno = await _repository.listar_control_reserva(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/movil/existe_llave_control_reserva")]
        [ActionName(nameof(existe_llave_control_reserva))]
        public async Task<ActionResult<Int32?>> existe_llave_control_reserva
           (
               [FromBody] MovilControlReservaExisteRequestDto requestmodel 
           )      
        {

            var dataretorno = await _repository.existe_llave_control_reserva(requestmodel);
            return Ok(dataretorno);

        }


        [HttpPost("~/api/movil/insertar_control_reserva")]
        [ActionName(nameof(insertar_control_reserva))]
        public async Task<ActionResult<bool>> insertar_control_reserva
           (
               [FromBody] MovilControlReservaInsertarRequestDto requestmodel
           )
        {

            var dataretorno = await _repository.insertar_control_reserva(requestmodel);
            return Ok(dataretorno);

        }

    }
}
