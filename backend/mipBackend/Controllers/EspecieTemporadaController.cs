using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.EspecieTemporada;
using mipBackend.Dtos.EspecieTemporadaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieTemporadaController : ControllerBase
    {
        private readonly IEspecietemporadaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public EspecieTemporadaController
            (

                IEspecietemporadaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost("~/api/especietemporada/getespecietemporada")]
        [ActionName(nameof(getespecietemporada))]
        public async Task<ActionResult<DataSourceResult>> getespecietemporada
           (
               [FromBody] DataSourceRequest requestModel
           )
        {

            DataSourceResult? dataretorno = await _repository.GetAllEspecieTemporadaDatasource(requestModel);
            return Ok(dataretorno);

        }


        [HttpGet("~/api/especietemporada/GetEspecieTemporadaById/{id}")]
        [ActionName(nameof(GetEspecieTemporadaById))]
        public async Task<ActionResult<EspecieTemporadaResponseDto>> GetEspecieTemporadaById(int id)
        {


            var Temporada = await _repository.GetEspecieTemporadaById(id);

            if (Temporada == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Temporada por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<EspecieTemporadaResponseDto>(Temporada));

        }


        [HttpPost("~/api/especietemporada/createespecietemporada")]
        [ActionName(nameof(createespecietemporada))]
        public async Task<ActionResult<EspecieTemporadaResponseDto>> createespecietemporada
            (
               [FromBody] EspecieTemporadaRequestDto request
            )
        {

            var model = _mapper.Map<esp02Temporadaespecie>(request);

            await _repository.Create(model);
            await _repository.SaveChanges();



            var especietemporada = await _repository.GetEspecieTemporadaById(model.esp02llave);

            if (especietemporada == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el persona por este id {especietemporada.esp02llave}" }
                    );
            }

            return Ok(_mapper.Map<esp02Temporadaespecie>(especietemporada));

        }


        [HttpPut]
        public async Task<ActionResult<EspecieTemporadaResponseDto>> updateespecietemporada
            (
                [FromBody] EspecieTemporadaResponseDto Temporada
            )
        {

            await _repository.Update(Temporada);
            await _repository.SaveChanges();

            var Temporadadto = await _repository.GetEspecieTemporadaById(Temporada.esp02llave);

            if (Temporadadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el  Segmento de la Temporada por este id {Temporada.esp02llave}" }
                    );
            }

            return Ok(_mapper.Map<EspecieTemporadaResponseDto>(Temporadadto));

        }


        [HttpGet("~/api/especietemporada/DeleteEspecieTemporada/{id}")]
        [ActionName(nameof(DeleteEspecieTemporada))]
        public async Task<ActionResult> DeleteEspecieTemporada(int id)
        {

            await _repository.Delete(id);
            await _repository.SaveChanges();
            
            return Ok();

        }

        [HttpPost("~/api/especietemporada/disableespecietemporada")]
        public async Task<ActionResult> disableespecietemporada
            (
                 [FromBody] EspecieTemporadaResponseDto[] Temporadas
            )
        {

            foreach (EspecieTemporadaResponseDto item in Temporadas)
            {
                var a = _mapper.Map<EspecieTemporadaResponseDto>(item);

                await _repository.Disable(a.esp02llave);
                await _repository.SaveChanges();
            }


            return Ok();

        }


        [HttpPost("~/api/especietemporada/ActivateespecieTemporada")]
        public async Task<ActionResult> ActivateespecieTemporada
            (
                 [FromBody] EspecieTemporadaResponseDto[] Temporadas
            )
        {

            foreach (EspecieTemporadaResponseDto item in Temporadas)
            {
                var a = _mapper.Map<EspecieTemporadaResponseDto>(item);

                await _repository.Activate(a.esp02llave);
                await _repository.SaveChanges();
            }


            return Ok();

        }

    }
}
