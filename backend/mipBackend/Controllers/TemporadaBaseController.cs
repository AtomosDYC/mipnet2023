using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Temporada;
using mipBackend.Dtos.TemporadaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaBaseController : ControllerBase
    {
        private readonly ITemporadaBaseRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TemporadaBaseController
            (

                ITemporadaBaseRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemporadaBaseResponseDto>>> GetTemporadaBases()
        {

            var TemporadaBases = await _repository.GetAllTemporadaBase();
            return Ok(_mapper.Map<IEnumerable<TemporadaBaseResponseDto>>(TemporadaBases));

        }

        [HttpGet("~/api/TemporadaBase/GetTemporadaBaseById/{id}")]
        [ActionName(nameof(GetTemporadaBaseById))]
        public async Task<ActionResult<TemporadaBaseResponseDto>> GetTemporadaBaseById(int id)
        {


            var TemporadaBase = await _repository.GetTemporadaBaseById(id);

            if (TemporadaBase == null)
            { 
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TemporadaBase por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaBaseResponseDto>(TemporadaBase));

        }

        [HttpPost]
        public async Task<ActionResult<TemporadaBaseResponseDto>> CreateTemporadaBase
            (
               [FromBody] TemporadaBaseRequestDto TemporadaBase
            )
        {

            var TemporadaBaseModel = _mapper.Map<Temp02TemporadaBase>(TemporadaBase);

            await _repository.CreateTemporadaBase(TemporadaBaseModel);
            await _repository.SaveChanges();

            var TemporadaBaseResponse = _mapper.Map<TemporadaBaseResponseDto>(TemporadaBaseModel);

            var TemporadaBasedto = await _repository.GetTemporadaBaseById(TemporadaBaseResponse.temp02llave);

            if (TemporadaBasedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TemporadaBase por este id {TemporadaBaseResponse.temp02llave}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaBaseResponseDto>(TemporadaBasedto));



        }

        [HttpPut]
        public async Task<ActionResult<TemporadaBaseResponseDto>> UpdateTemporadaBase
            (
                [FromBody] TemporadaBaseResponseDto TemporadaBase
            )
        {

            var TemporadaBaseModel = _mapper.Map<Temp02TemporadaBase>(TemporadaBase);

            await _repository.UpdateTemporadaBase(TemporadaBaseModel);
            await _repository.SaveChanges();

            var TemporadaBaseResponse = _mapper.Map<TemporadaBaseResponseDto>(TemporadaBaseModel);

            var TemporadaBasedto = await _repository.GetTemporadaBaseById(TemporadaBaseResponse.temp02llave);

            if (TemporadaBasedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el  Segmento de la Temporada por este id {TemporadaBaseResponse.temp02llave}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaBaseResponseDto>(TemporadaBasedto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemporadaBase(int id)
        {

            var TemporadaBasedto = await _repository.GetTemporadaBaseById(id);

            if (TemporadaBasedto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la TemporadaBase por este id {id}" }
                );
            }
            else
            {
                if (TemporadaBasedto.temp02activo == 0)
                {
                    await _repository.DeleteTemporadaBase(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTemporadaBase(id);
                    await _repository.SaveChanges();
                }
            }


            var listTemporadaBases = await _repository.GetAllTemporadaBase();
            return Ok(_mapper.Map<TemporadaBaseResponseDto[]>(listTemporadaBases));

        }

        [HttpPost("~/api/TemporadaBase/disableTemporadaBase")]
        public async Task<ActionResult<TemporadaBaseResponseDto[]>> DisableTemporadaBase
            (
                 [FromBody] TemporadaBaseResponseDto[] TemporadaBases
            )
        {

            foreach (TemporadaBaseResponseDto item in TemporadaBases)
            {
                var a = _mapper.Map<TemporadaBaseResponseDto>(item);

                await _repository.DisableTemporadaBase(a.temp02llave);
                await _repository.SaveChanges();
            }


            var listTemporadaBases = await _repository.GetAllTemporadaBase();
            return Ok(_mapper.Map<TemporadaBaseResponseDto[]>(listTemporadaBases));

        }


        [HttpPost("~/api/TemporadaBase/ActivateTemporadaBase")]
        public async Task<ActionResult<TemporadaBaseResponseDto[]>> ActivateTemporadaBase
            (
                 [FromBody] TemporadaBaseResponseDto[] TemporadaBases
            )
        {

            foreach (TemporadaBaseResponseDto item in TemporadaBases)
            {
                var a = _mapper.Map<TemporadaBaseResponseDto>(item);

                await _repository.ActivateTemporadaBase(a.temp02llave);
                await _repository.SaveChanges();
            }


            var listTemporadaBases = await _repository.GetAllTemporadaBase();
            return Ok(_mapper.Map<TemporadaBaseResponseDto[]>(listTemporadaBases));

        }
    }
}