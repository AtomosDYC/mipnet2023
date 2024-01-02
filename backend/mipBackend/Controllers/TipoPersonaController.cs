using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Tipopersonas;
using mipBackend.Dtos.TipopersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipopersonaController : ControllerBase
    {

        private readonly ITipopersonaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipopersonaController
            (

                ITipopersonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipopersonaResponseDto>>> GetTipopersona()
        {

            var Tipopersonas = await _repository.GetAllTipopersonas();
            return Ok(_mapper.Map<IEnumerable<TipopersonaResponseDto>>(Tipopersonas));

        }

        [HttpGet("~/api/Tipopersona/GetTipopersonaById/{id}")]
        [ActionName(nameof(GetTipopersonaById))]
        public async Task<ActionResult<TipopersonaResponseDto>> GetTipopersonaById(int id)
        {


            var Tipopersona = await _repository.GetTipopersonaById(id);

            if (Tipopersona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Tipopersona por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipopersonaResponseDto>(Tipopersona));

        }

        [HttpPost]
        public async Task<ActionResult<TipopersonaResponseDto>> CreateTipopersona
            (
               [FromBody] TipopersonaRequestDto Tipopersona
            )
        {

            var TipopersonaModel = _mapper.Map<per03Tipopersona>(Tipopersona);

            await _repository.CreateTipopersona(TipopersonaModel);
            await _repository.SaveChanges();

            var TipopersonaResponse = _mapper.Map<TipopersonaResponseDto>(TipopersonaModel);

            var Tipopersonadto = await _repository.GetTipopersonaById(TipopersonaResponse.per03llave);

            if (Tipopersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Tipopersona por este id {TipopersonaResponse.per03llave}" }
                    );
            }

            return Ok(_mapper.Map<TipopersonaResponseDto>(Tipopersonadto));



        }

        [HttpPut]
        public async Task<ActionResult<TipopersonaResponseDto>> UpdateTipopersona
            (
                [FromBody] TipopersonaResponseDto Tipopersona
            )
        {

            var TipopersonaModel = _mapper.Map<per03Tipopersona>(Tipopersona);

            await _repository.UpdateTipopersona(TipopersonaModel);
            await _repository.SaveChanges();

            var TipopersonaResponse = _mapper.Map<TipopersonaResponseDto>(TipopersonaModel);

            var Tipopersonadto = await _repository.GetTipopersonaById(TipopersonaResponse.per03llave);

            if (Tipopersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Tipopersona por este id {TipopersonaResponse.per03llave}" }
                    );
            }

            return Ok(_mapper.Map<TipopersonaResponseDto>(Tipopersonadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipopersona(int id)
        {

            var Tipopersonadto = await _repository.GetTipopersonaById(id);

            if (Tipopersonadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Tipopersona por este id {id}" }
                );
            }
            else
            {
                if (Tipopersonadto.per03activo == 0)
                {
                    await _repository.DeleteTipopersona(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipopersona(id);
                    await _repository.SaveChanges();
                }
            }


            var listTipopersonas = await _repository.GetAllTipopersonas();
            return Ok(_mapper.Map<TipopersonaResponseDto[]>(listTipopersonas));

        }

        [HttpPost("~/api/Tipopersona/disableTipopersona")]
        public async Task<ActionResult<TipopersonaResponseDto[]>> DisableTipopersona
            (
                 [FromBody] TipopersonaResponseDto[] Tipopersonas
            )
        {

            foreach (TipopersonaResponseDto item in Tipopersonas)
            {
                var a = _mapper.Map<TipopersonaResponseDto>(item);

                await _repository.DisableTipopersona(a.per03llave);
                await _repository.SaveChanges();
            }


            var listTipopersonas = await _repository.GetAllTipopersonas();
            return Ok(_mapper.Map<TipopersonaResponseDto[]>(listTipopersonas));

        }


        [HttpPost("~/api/Tipopersona/ActivateTipopersona")]
        public async Task<ActionResult<TipopersonaResponseDto[]>> ActivateTipopersona
            (
                 [FromBody] TipopersonaResponseDto[] Tipopersonas
            )
        {

            foreach (TipopersonaResponseDto item in Tipopersonas)
            {
                var a = _mapper.Map<TipopersonaResponseDto>(item);

                await _repository.ActivateTipopersona(a.per03llave);
                await _repository.SaveChanges();
            }


            var listTipopersonas = await _repository.GetAllTipopersonas();
            return Ok(_mapper.Map<TipopersonaResponseDto[]>(listTipopersonas));

        }

    }
}