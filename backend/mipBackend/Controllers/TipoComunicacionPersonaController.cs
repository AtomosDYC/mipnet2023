using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoCompersonas;
using mipBackend.Dtos.TipoCompersonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComunicacionpersonaController : ControllerBase
    {
        private readonly ITipoCompersonaRepository  _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoComunicacionpersonaController
            (

                ITipoCompersonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCompersonaResponseDto>>> GetTipoCompersona()
        {

            var tipocompersonas = await _repository.GetAllTipoCompersonas();
            return Ok(_mapper.Map<IEnumerable<TipoCompersonaResponseDto>>(tipocompersonas));

        }

        [HttpGet("~/api/TipoComunicacionpersona/GetTipoCompersonaById/{id}")]
        [ActionName(nameof(GetTipoCompersonaById))]
        public async Task<ActionResult<TipoCompersonaResponseDto>> GetTipoCompersonaById(int id)
        {


            var tipocompersona = await _repository.GetTipoCompersonaById(id);

            if (tipocompersona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la EL tipo de comunicación por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoCompersonaResponseDto>(tipocompersona));

        }

        [HttpPost]
        public async Task<ActionResult<TipoCompersonaResponseDto>> CreateTipoCompersona
            (
               [FromBody] TipoCompersonaRequestDto tipocompersona
            )
        {

            var tipocompersonaModel = _mapper.Map<per04TipoComunicacion>(tipocompersona);

            await _repository.CreateTipoCompersona(tipocompersonaModel);
            await _repository.SaveChanges();

            var tipocompersonaResponse = _mapper.Map<TipoCompersonaResponseDto>(tipocompersonaModel);

            var tipocompersonadto = await _repository.GetTipoCompersonaById(tipocompersonaResponse.per04llave);

            if (tipocompersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipocompersona por este id {tipocompersonaResponse.per04llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoCompersonaResponseDto>(tipocompersonadto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoCompersonaResponseDto>> UpdateTipoCompersona
            (
                [FromBody] TipoCompersonaResponseDto tipocompersona
            )
        {

            var tipocompersonaModel = _mapper.Map<per04TipoComunicacion>(tipocompersona);

            await _repository.UpdateTipoCompersona(tipocompersonaModel);
            await _repository.SaveChanges();

            var tipocompersonaResponse = _mapper.Map<TipoCompersonaResponseDto>(tipocompersonaModel);

            var tipocompersonadto = await _repository.GetTipoCompersonaById(tipocompersonaResponse.per04llave);

            if (tipocompersonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo de comunicación por este id {tipocompersonaResponse.per04llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoCompersonaResponseDto>(tipocompersonadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoCompersona(int id)
        {

            var tipocompersonadto = await _repository.GetTipoCompersonaById(id);

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
                    await _repository.DeleteTipoCompersona(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoCompersona(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipocompersonas = await _repository.GetAllTipoCompersonas();
            return Ok(_mapper.Map<TipoCompersonaResponseDto[]>(listtipocompersonas));

        }

        [HttpPost("~/api/tipocomunicacionpersona/disabletipocompersona")]
        public async Task<ActionResult<TipoCompersonaResponseDto[]>> DisableTipoCompersona
            (
                 [FromBody] TipoCompersonaResponseDto[] tipocompersonas
            )
        {

            foreach (TipoCompersonaResponseDto item in tipocompersonas)
            {
                var a = _mapper.Map<TipoCompersonaResponseDto>(item);

                await _repository.DisableTipoCompersona(a.per04llave);
                await _repository.SaveChanges();
            }


            var listtipocompersonas = await _repository.GetAllTipoCompersonas();
            return Ok(_mapper.Map<TipoCompersonaResponseDto[]>(listtipocompersonas));

        }


        [HttpPost("~/api/TipoComunicacionpersona/ActivateTipoCompersona")]
        public async Task<ActionResult<TipoCompersonaResponseDto[]>> ActivateTipoCompersona
            (
                 [FromBody] TipoCompersonaResponseDto[] tipocompersonas
            )
        {

            foreach (TipoCompersonaResponseDto item in tipocompersonas)
            {
                var a = _mapper.Map<TipoCompersonaResponseDto>(item);

                await _repository.ActivateTipoCompersona(a.per04llave);
                await _repository.SaveChanges();
            }

            var listtipocompersonas = await _repository.GetAllTipoCompersonas();
            return Ok(_mapper.Map<TipoCompersonaResponseDto[]>(listtipocompersonas));

        }
    }
}
