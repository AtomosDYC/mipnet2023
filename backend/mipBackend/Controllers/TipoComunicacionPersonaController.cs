using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoComPersonas;
using mipBackend.Dtos.TipoComPersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComunicacionPersonaController : ControllerBase
    {
        private readonly ITipoComPersonaRepository  _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoComunicacionPersonaController
            (

                ITipoComPersonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoComPersonaResponseDto>>> GetTipoComPersona()
        {

            var tipocompersonas = await _repository.GetAllTipoComPersonas();
            return Ok(_mapper.Map<IEnumerable<TipoComPersonaResponseDto>>(tipocompersonas));

        }

        [HttpGet("~/api/TipoComunicacionPersona/GetTipoComPersonaById/{id}")]
        [ActionName(nameof(GetTipoComPersonaById))]
        public async Task<ActionResult<TipoComPersonaResponseDto>> GetTipoComPersonaById(int id)
        {


            var tipocompersona = await _repository.GetTipoComPersonaById(id);

            if (tipocompersona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la EL tipo de comunicación por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoComPersonaResponseDto>(tipocompersona));

        }

        [HttpPost]
        public async Task<ActionResult<TipoComPersonaResponseDto>> CreateTipoComPersona
            (
               [FromBody] TipoComPersonaRequestDto tipocompersona
            )
        {

            var tipocompersonaModel = _mapper.Map<Per04TipoComunicacion>(tipocompersona);

            await _repository.CreateTipoComPersona(tipocompersonaModel);
            await _repository.SaveChanges();

            var tipocompersonaResponse = _mapper.Map<TipoComPersonaResponseDto>(tipocompersonaModel);

            var tipocompersonadto = await _repository.GetTipoComPersonaById(tipocompersonaResponse.per04llave);

            if (tipocompersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipocompersona por este id {tipocompersonaResponse.per04llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoComPersonaResponseDto>(tipocompersonadto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoComPersonaResponseDto>> UpdateTipoComPersona
            (
                [FromBody] TipoComPersonaResponseDto tipocompersona
            )
        {

            var tipocompersonaModel = _mapper.Map<Per04TipoComunicacion>(tipocompersona);

            await _repository.UpdateTipoComPersona(tipocompersonaModel);
            await _repository.SaveChanges();

            var tipocompersonaResponse = _mapper.Map<TipoComPersonaResponseDto>(tipocompersonaModel);

            var tipocompersonadto = await _repository.GetTipoComPersonaById(tipocompersonaResponse.per04llave);

            if (tipocompersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo de comunicación por este id {tipocompersonaResponse.per04llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoComPersonaResponseDto>(tipocompersonadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoComPersona(int id)
        {

            var tipocompersonadto = await _repository.GetTipoComPersonaById(id);

            if (tipocompersonadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la tipocompersona por este id {id}" }
                );
            }
            else
            {
                if (tipocompersonadto.per04activo == 0)
                {
                    await _repository.DeleteTipoComPersona(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoComPersona(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipocompersonas = await _repository.GetAllTipoComPersonas();
            return Ok(_mapper.Map<TipoComPersonaResponseDto[]>(listtipocompersonas));

        }

        [HttpPost("~/api/tipocomunicacionpersona/disabletipocompersona")]
        public async Task<ActionResult<TipoComPersonaResponseDto[]>> DisableTipoComPersona
            (
                 [FromBody] TipoComPersonaResponseDto[] tipocompersonas
            )
        {

            foreach (TipoComPersonaResponseDto item in tipocompersonas)
            {
                var a = _mapper.Map<TipoComPersonaResponseDto>(item);

                await _repository.DisableTipoComPersona(a.per04llave);
                await _repository.SaveChanges();
            }


            var listtipocompersonas = await _repository.GetAllTipoComPersonas();
            return Ok(_mapper.Map<TipoComPersonaResponseDto[]>(listtipocompersonas));

        }


        [HttpPost("~/api/TipoComunicacionPersona/ActivateTipoComPersona")]
        public async Task<ActionResult<TipoComPersonaResponseDto[]>> ActivateTipoComPersona
            (
                 [FromBody] TipoComPersonaResponseDto[] tipocompersonas
            )
        {

            foreach (TipoComPersonaResponseDto item in tipocompersonas)
            {
                var a = _mapper.Map<TipoComPersonaResponseDto>(item);

                await _repository.ActivateTipoComPersona(a.per04llave);
                await _repository.SaveChanges();
            }

            var listtipocompersonas = await _repository.GetAllTipoComPersonas();
            return Ok(_mapper.Map<TipoComPersonaResponseDto[]>(listtipocompersonas));

        }
    }
}
