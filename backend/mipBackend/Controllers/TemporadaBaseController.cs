using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Temporada;
using mipBackend.Dtos.TemporadaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

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

        [HttpPost("~/api/temporadabase/gettemporadabases")]
        [ActionName(nameof(gettemporadabases))]
        public async Task<ActionResult<DataSourceResult>> gettemporadabases
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            DataSourceResult? TemporadaBases = await _repository.GetAllTemporadaBase(requestModel);
            return Ok(TemporadaBases);

        }

        [HttpGet("~/api/temporadabase/GetTemporadaBaseById/{id}")]
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

        [HttpPost("~/api/temporadabase/CreateTemporadaBase")]
        [ActionName(nameof(CreateTemporadaBase))]
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

        [HttpPost("~/api/temporadabase/DeleteTemporadaBase")]
        [ActionName(nameof(DeleteTemporadaBase))]
        public async Task<ActionResult> DeleteTemporadaBase
            (
                [FromBody] TemporadaEliminarRequestDto TemporadaBase
            )
        {

           +66666666666666            await _repository.DeleteTemporadaBase(TemporadaBase.id);
            bool dataretorno = await _repository.SaveChanges();
           

            return Ok();

        }

        [HttpPost("~/api/temporadabase/disableTemporadaBase")]
        [ActionName(nameof(DisableTemporadaBase))]
        public async Task<ActionResult<DataSourceResult>> DisableTemporadaBase
            (
                 [FromBody] TemporadaDesactivarRequestDto TemporadaBases
            )
        {

            foreach (TemporadaBaseResponseDto item in TemporadaBases.ids)
            {
                var a = _mapper.Map<TemporadaBaseResponseDto>(item);

                await _repository.DisableTemporadaBase(a.temp02llave);
                await _repository.SaveChanges();
            }



            DataSourceResult? Temporada = await _repository.GetAllTemporadaBase(TemporadaBases.filtro);
            return Ok(Temporada);

        }


        [HttpPost("~/api/temporadabase/ActivateTemporadaBase")]
        [ActionName(nameof(ActivateTemporadaBase))]
        public async Task<ActionResult<DataSourceResult>> ActivateTemporadaBase
            (
                 [FromBody] TemporadaDesactivarRequestDto TemporadaBases
            )
        {

            foreach (TemporadaBaseResponseDto item in TemporadaBases.ids)
            {
                var a = _mapper.Map<TemporadaBaseResponseDto>(item);

                await _repository.ActivateTemporadaBase(a.temp02llave);
                await _repository.SaveChanges();
            }


            DataSourceResult? Temporada = await _repository.GetAllTemporadaBase(TemporadaBases.filtro);
            return Ok(Temporada);

        }
    }
}