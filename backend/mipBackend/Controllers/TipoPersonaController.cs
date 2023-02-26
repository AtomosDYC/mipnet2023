using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoPersonas;
using mipBackend.Dtos.TipoPersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonaController : ControllerBase
    {

        private readonly ITipoPersonaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoPersonaController
            (

                ITipoPersonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersonaResponseDto>>> GetTipoPersona()
        {

            var TipoPersonas = await _repository.GetAllTipoPersonas();
            return Ok(_mapper.Map<IEnumerable<TipoPersonaResponseDto>>(TipoPersonas));

        }

        [HttpGet("~/api/TipoPersona/GetTipoPersonaById/{id}")]
        [ActionName(nameof(GetTipoPersonaById))]
        public async Task<ActionResult<TipoPersonaResponseDto>> GetTipoPersonaById(int id)
        {


            var TipoPersona = await _repository.GetTipoPersonaById(id);

            if (TipoPersona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoPersonaResponseDto>(TipoPersona));

        }

        [HttpPost]
        public async Task<ActionResult<TipoPersonaResponseDto>> CreateTipoPersona
            (
               [FromBody] TipoPersonaRequestDto TipoPersona
            )
        {

            var TipoPersonaModel = _mapper.Map<Per03TipoPersona>(TipoPersona);

            await _repository.CreateTipoPersona(TipoPersonaModel);
            await _repository.SaveChanges();

            var TipoPersonaResponse = _mapper.Map<TipoPersonaResponseDto>(TipoPersonaModel);

            var TipoPersonadto = await _repository.GetTipoPersonaById(TipoPersonaResponse.per03llave);

            if (TipoPersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {TipoPersonaResponse.per03llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoPersonaResponseDto>(TipoPersonadto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoPersonaResponseDto>> UpdateTipoPersona
            (
                [FromBody] TipoPersonaResponseDto TipoPersona
            )
        {

            var TipoPersonaModel = _mapper.Map<Per03TipoPersona>(TipoPersona);

            await _repository.UpdateTipoPersona(TipoPersonaModel);
            await _repository.SaveChanges();

            var TipoPersonaResponse = _mapper.Map<TipoPersonaResponseDto>(TipoPersonaModel);

            var TipoPersonadto = await _repository.GetTipoPersonaById(TipoPersonaResponse.per03llave);

            if (TipoPersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoPersona por este id {TipoPersonaResponse.per03llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoPersonaResponseDto>(TipoPersonadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoPersona(int id)
        {

            var TipoPersonadto = await _repository.GetTipoPersonaById(id);

            if (TipoPersonadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la TipoPersona por este id {id}" }
                );
            }
            else
            {
                if (TipoPersonadto.per03activo == 0)
                {
                    await _repository.DeleteTipoPersona(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoPersona(id);
                    await _repository.SaveChanges();
                }
            }


            var listTipoPersonas = await _repository.GetAllTipoPersonas();
            return Ok(_mapper.Map<TipoPersonaResponseDto[]>(listTipoPersonas));

        }

        [HttpPost("~/api/TipoPersona/disableTipoPersona")]
        public async Task<ActionResult<TipoPersonaResponseDto[]>> DisableTipoPersona
            (
                 [FromBody] TipoPersonaResponseDto[] TipoPersonas
            )
        {

            foreach (TipoPersonaResponseDto item in TipoPersonas)
            {
                var a = _mapper.Map<TipoPersonaResponseDto>(item);

                await _repository.DisableTipoPersona(a.per03llave);
                await _repository.SaveChanges();
            }


            var listTipoPersonas = await _repository.GetAllTipoPersonas();
            return Ok(_mapper.Map<TipoPersonaResponseDto[]>(listTipoPersonas));

        }


        [HttpPost("~/api/TipoPersona/ActivateTipoPersona")]
        public async Task<ActionResult<TipoPersonaResponseDto[]>> ActivateTipoPersona
            (
                 [FromBody] TipoPersonaResponseDto[] TipoPersonas
            )
        {

            foreach (TipoPersonaResponseDto item in TipoPersonas)
            {
                var a = _mapper.Map<TipoPersonaResponseDto>(item);

                await _repository.ActivateTipoPersona(a.per03llave);
                await _repository.SaveChanges();
            }


            var listTipoPersonas = await _repository.GetAllTipoPersonas();
            return Ok(_mapper.Map<TipoPersonaResponseDto[]>(listTipoPersonas));

        }

    }
}