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
    public class TemporadaController : ControllerBase
    {
        private readonly ITemporadaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TemporadaController
            (

                ITemporadaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemporadaResponseDto>>> GetTemporadas()
        {

            var Temporadas = await _repository.GetAllTemporada();
            return Ok(_mapper.Map<IEnumerable<TemporadaResponseDto>>(Temporadas));

        }

        [HttpGet("~/api/Temporada/GetTemporadaById/{id}")]
        [ActionName(nameof(GetTemporadaById))]
        public async Task<ActionResult<TemporadaResponseDto>> GetTemporadaById(int id)
        {


            var Temporada = await _repository.GetTemporadaById(id);

            if (Temporada == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Temporada por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaResponseDto>(Temporada));

        }

        [HttpPost]
        public async Task<ActionResult<TemporadaResponseDto>> CreateTemporada
            (
               [FromBody] TemporadaRequestDto Temporada
            )
        {

            var TemporadaModel = _mapper.Map<Temp01Temporada>(Temporada);

            await _repository.CreateTemporada(TemporadaModel);
            await _repository.SaveChanges();

            var TemporadaResponse = _mapper.Map<TemporadaResponseDto>(TemporadaModel);

            var Temporadadto = await _repository.GetTemporadaById(TemporadaModel.temp01llave);

            if (Temporadadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Temporada por este id {TemporadaResponse.temp01llave}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaResponseDto>(Temporadadto));



        }

        [HttpPut]
        public async Task<ActionResult<TemporadaResponseDto>> UpdateTemporada
            (
                [FromBody] TemporadaResponseDto Temporada
            )
        {

            var TemporadaModel = _mapper.Map<Temp01Temporada>(Temporada);

            await _repository.UpdateTemporada(TemporadaModel);
            await _repository.SaveChanges();

            var TemporadaResponse = _mapper.Map<TemporadaResponseDto>(TemporadaModel);

            var Temporadadto = await _repository.GetTemporadaById(TemporadaResponse.temp01llave);

            if (Temporadadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el  Segmento de la Temporada por este id {TemporadaResponse.temp01llave}" }
                    );
            }

            return Ok(_mapper.Map<TemporadaResponseDto>(Temporadadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemporada(int id)
        {

            var Temporadadto = await _repository.GetTemporadaById(id);

            if (Temporadadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Temporada por este id {id}" }
                );
            }
            else
            {
                if (Temporadadto.temp01activo == 0)
                {
                    await _repository.DeleteTemporada(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTemporada(id);
                    await _repository.SaveChanges();
                }
            }


            var listTemporadas = await _repository.GetAllTemporada();
            return Ok(_mapper.Map<TemporadaResponseDto[]>(listTemporadas));

        }

        [HttpPost("~/api/Temporada/disableTemporada")]
        public async Task<ActionResult<TemporadaResponseDto[]>> DisableTemporada
            (
                 [FromBody] TemporadaResponseDto[] Temporadas
            )
        {

            foreach (TemporadaResponseDto item in Temporadas)
            {
                var a = _mapper.Map<TemporadaResponseDto>(item);

                await _repository.DisableTemporada(a.temp01llave);
                await _repository.SaveChanges();
            }


            var listTemporadas = await _repository.GetAllTemporada();
            return Ok(_mapper.Map<TemporadaResponseDto[]>(listTemporadas));

        }


        [HttpPost("~/api/Temporada/ActivateTemporada")]
        public async Task<ActionResult<TemporadaResponseDto[]>> ActivateTemporada
            (
                 [FromBody] TemporadaResponseDto[] Temporadas
            )
        {

            foreach (TemporadaResponseDto item in Temporadas)
            {
                var a = _mapper.Map<TemporadaResponseDto>(item);

                await _repository.ActivateTemporada(a.temp01llave);
                await _repository.SaveChanges();
            }


            var listTemporadas = await _repository.GetAllTemporada();
            return Ok(_mapper.Map<TemporadaResponseDto[]>(listTemporadas));

        }
    }
}