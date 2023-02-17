using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.EstadosDanios;
using mipBackend.Dtos.EstadosDanioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosDanioController : ControllerBase
    {
        private readonly IEstadosDanioRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public EstadosDanioController
            (
                AppDbContext context,
                IEstadosDanioRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadosDanioResponseDto>>> GetEstadosDanio()
        {

            var EstadosDanios = await _repository.GetAllEstadosDanios();
            return Ok(EstadosDanios);

        }

        [HttpGet("~/api/EstadosDanio/GetEstadosDanioById/{id}")]
        [ActionName(nameof(GetEstadosDanioById))]
        public async Task<ActionResult<EstadosDanioResponseDto>> GetEstadosDanioById(int id)
        {


            var EstadosDanio = await _repository.GetEstadosDanioById(id);

            if (EstadosDanio == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la EstadosDanio por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<EstadosDanioResponseDto>(EstadosDanio));

        }

        [HttpPost]
        public async Task<ActionResult<EstadosDanioResponseDto>> CreateEstadosDanio
            (
               [FromBody] EstadosDanioRequestDto EstadosDanio
            )
        {

            var EstadosDanioModel = _mapper.Map<Esp04EstadoDanio>(EstadosDanio);

            await _repository.CreateEstadosDanio(EstadosDanioModel);
            await _repository.SaveChanges();

            var EstadosDanioResponse = _mapper.Map<EstadosDanioResponseDto>(EstadosDanioModel);

            var EstadosDaniodto = await _repository.GetEstadosDanioById(EstadosDanioResponse.esp04llave);

            if (EstadosDaniodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la EstadosDanio por este id {EstadosDanioResponse.esp04llave}" }
                    );
            }

            return Ok(_mapper.Map<EstadosDanioResponseDto>(EstadosDaniodto));



        }

        [HttpPut]
        public async Task<ActionResult<EstadosDanioResponseDto>> UpdateEstadosDanio
            (
                [FromBody] EstadosDanioResponseDto EstadosDanio
            )
        {

            var EstadosDanioModel = _mapper.Map<Esp04EstadoDanio>(EstadosDanio);

            await _repository.UpdateEstadosDanio(EstadosDanioModel);
            await _repository.SaveChanges();

            var EstadosDanioResponse = _mapper.Map<EstadosDanioResponseDto>(EstadosDanioModel);

            var EstadosDaniodto = await _repository.GetEstadosDanioById(EstadosDanioResponse.esp04llave);

            if (EstadosDaniodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la EstadosDanio por este id {EstadosDanioResponse.esp04llave}" }
                    );
            }

            return Ok(_mapper.Map<EstadosDanioResponseDto>(EstadosDaniodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstadosDanio(int id)
        {

            var EstadosDaniodto = await _repository.GetEstadosDanioById(id);

            if (EstadosDaniodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la EstadosDanio por este id {id}" }
                );
            }
            else
            {
                if (EstadosDaniodto.esp04activo == 0)
                {
                    await _repository.DeleteEstadosDanio(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableEstadosDanio(id);
                    await _repository.SaveChanges();
                }
            }


            var listEstadosDanios = await _repository.GetAllEstadosDanios();
            return Ok(_mapper.Map<EstadosDanioResponseDto[]>(listEstadosDanios));

        }

        [HttpPost("~/api/EstadosDanio/disableEstadosDanio")]
        public async Task<ActionResult<EstadosDanioResponseDto[]>> DisableEstadosDanio
            (
                 [FromBody] EstadosDanioResponseDto[] EstadosDanios
            )
        {

            foreach (EstadosDanioResponseDto item in EstadosDanios)
            {
                var a = _mapper.Map<EstadosDanioResponseDto>(item);

                await _repository.DisableEstadosDanio(a.esp04llave);
                await _repository.SaveChanges();
            }


            var listEstadosDanios = await _repository.GetAllEstadosDanios();
            return Ok(_mapper.Map<EstadosDanioResponseDto[]>(listEstadosDanios));

        }


        [HttpPost("~/api/EstadosDanio/ActivateEstadosDanio")]
        public async Task<ActionResult<EstadosDanioResponseDto[]>> ActivateEstadosDanio
            (
                 [FromBody] EstadosDanioResponseDto[] EstadosDanios
            )
        {

            foreach (EstadosDanioResponseDto item in EstadosDanios)
            {
                var a = _mapper.Map<EstadosDanioResponseDto>(item);

                await _repository.ActivateEstadosDanio(a.esp04llave);
                await _repository.SaveChanges();
            }


            var listEstadosDanios = await _repository.GetAllEstadosDanios();
            return Ok(_mapper.Map<EstadosDanioResponseDto[]>(listEstadosDanios));

        }
    }
}
