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
    public class SegmentarTemporadaController : ControllerBase
    {
        private readonly ISegmentarTemporadaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public SegmentarTemporadaController
            (

                ISegmentarTemporadaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SegmentarTemporadaResponseDto>>> GetSegmentarTemporadas()
        {

            var SegmentarTemporadas = await _repository.GetAllSegmentarTemporada();
            return Ok(_mapper.Map<IEnumerable<SegmentarTemporadaResponseDto>>(SegmentarTemporadas));

        }

        [HttpGet("~/api/SegmentarTemporada/GetSegmentarTemporadaById/{id}")]
        [ActionName(nameof(GetSegmentarTemporadaById))]
        public async Task<ActionResult<SegmentarTemporadaResponseDto>> GetSegmentarTemporadaById(int id)
        {


            var SegmentarTemporada = await _repository.GetSegmentarTemporadaById(id);

            if (SegmentarTemporada == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la SegmentarTemporada por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<SegmentarTemporadaResponseDto>(SegmentarTemporada));

        }

        [HttpPost]
        public async Task<ActionResult<SegmentarTemporadaResponseDto>> CreateSegmentarTemporada
            (
               [FromBody] SegmentarTemporadaRequestDto SegmentarTemporada
            )
        {

            var SegmentarTemporadaModel = _mapper.Map<Temp03Segmentacion>(SegmentarTemporada);

            await _repository.CreateSegmentarTemporada(SegmentarTemporadaModel);
            await _repository.SaveChanges();

            var SegmentarTemporadaResponse = _mapper.Map<SegmentarTemporadaResponseDto>(SegmentarTemporadaModel);

            var SegmentarTemporadadto = await _repository.GetSegmentarTemporadaById(SegmentarTemporadaResponse.temp03llave);

            if (SegmentarTemporadadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la SegmentarTemporada por este id {SegmentarTemporadaResponse.temp03llave}" }
                    );
            }

            return Ok(_mapper.Map<SegmentarTemporadaResponseDto>(SegmentarTemporadadto));



        }

        [HttpPut]
        public async Task<ActionResult<SegmentarTemporadaResponseDto>> UpdateSegmentarTemporada
            (
                [FromBody] SegmentarTemporadaResponseDto SegmentarTemporada
            )
        {

            var SegmentarTemporadaModel = _mapper.Map<Temp03Segmentacion>(SegmentarTemporada);

            await _repository.UpdateSegmentarTemporada(SegmentarTemporadaModel);
            await _repository.SaveChanges();

            var SegmentarTemporadaResponse = _mapper.Map<SegmentarTemporadaResponseDto>(SegmentarTemporadaModel);

            var SegmentarTemporadadto = await _repository.GetSegmentarTemporadaById(SegmentarTemporadaResponse.temp03llave);

            if (SegmentarTemporadadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el  Segmento de la Temporada por este id {SegmentarTemporadaResponse.temp03llave}" }
                    );
            }

            return Ok(_mapper.Map<SegmentarTemporadaResponseDto>(SegmentarTemporadadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSegmentarTemporada(int id)
        {

            var SegmentarTemporadadto = await _repository.GetSegmentarTemporadaById(id);

            if (SegmentarTemporadadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la SegmentarTemporada por este id {id}" }
                );
            }
            else
            {
                if (SegmentarTemporadadto.temp03activo == 0)
                {
                    await _repository.DeleteSegmentarTemporada(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableSegmentarTemporada(id);
                    await _repository.SaveChanges();
                }
            }


            var listSegmentarTemporadas = await _repository.GetAllSegmentarTemporada();
            return Ok(_mapper.Map<SegmentarTemporadaResponseDto[]>(listSegmentarTemporadas));

        }

        [HttpPost("~/api/SegmentarTemporada/disableSegmentarTemporada")]
        public async Task<ActionResult<SegmentarTemporadaResponseDto[]>> DisableSegmentarTemporada
            (
                 [FromBody] SegmentarTemporadaResponseDto[] SegmentarTemporadas
            )
        {

            foreach (SegmentarTemporadaResponseDto item in SegmentarTemporadas)
            {
                var a = _mapper.Map<SegmentarTemporadaResponseDto>(item);

                await _repository.DisableSegmentarTemporada(a.temp03llave);
                await _repository.SaveChanges();
            }


            var listSegmentarTemporadas = await _repository.GetAllSegmentarTemporada();
            return Ok(_mapper.Map<SegmentarTemporadaResponseDto[]>(listSegmentarTemporadas));

        }


        [HttpPost("~/api/SegmentarTemporada/ActivateSegmentarTemporada")]
        public async Task<ActionResult<SegmentarTemporadaResponseDto[]>> ActivateSegmentarTemporada
            (
                 [FromBody] SegmentarTemporadaResponseDto[] SegmentarTemporadas
            )
        {

            foreach (SegmentarTemporadaResponseDto item in SegmentarTemporadas)
            {
                var a = _mapper.Map<SegmentarTemporadaResponseDto>(item);

                await _repository.ActivateSegmentarTemporada(a.temp03llave);
                await _repository.SaveChanges();
            }


            var listSegmentarTemporadas = await _repository.GetAllSegmentarTemporada();
            return Ok(_mapper.Map<SegmentarTemporadaResponseDto[]>(listSegmentarTemporadas));

        }
    }
}
