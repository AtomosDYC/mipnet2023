using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoParametros;
using mipBackend.Dtos.TipoParametroDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoParametroController : ControllerBase
    {

        private readonly ITipoParametroRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoParametroController
            (

                ITipoParametroRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoParametroResponseDto>>> GetTipoParametros()
        {

            var tipoparametros = await _repository.GetAllTipoParametros();
            return Ok(_mapper.Map<IEnumerable<TipoParametroResponseDto>>(tipoparametros));

        }

        [HttpGet("~/api/TipoParametro/GetTipoParametroById/{id}")]
        [ActionName(nameof(GetTipoParametroById))]
        public async Task<ActionResult<TipoParametroResponseDto>> GetTipoParametroById(int id)
        {


            var tipoparametro = await _repository.GetTipoParametroById(id);

            if (tipoparametro == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoparametro por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoParametroResponseDto>(tipoparametro));

        }

        [HttpPost]
        public async Task<ActionResult<TipoParametroResponseDto>> CreateTipoParametro
            (
               [FromBody] TipoParametroRequestDto tipoparametro
            )
        {

            var tipoparametroModel = _mapper.Map<Wkf10TipoParametro>(tipoparametro);

            await _repository.CreateTipoParametro(tipoparametroModel);
            await _repository.SaveChanges();

            var tipoparametroResponse = _mapper.Map<TipoParametroResponseDto>(tipoparametroModel);

            var tipoparametrodto = await _repository.GetTipoParametroById(tipoparametroResponse.wkf10llave);

            if (tipoparametrodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoparametro por este id {tipoparametroResponse.wkf10llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoParametroResponseDto>(tipoparametrodto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoParametroResponseDto>> UpdateTipoParametro
            (
                [FromBody] TipoParametroResponseDto tipoparametro
            )
        {

            var tipoparametroModel = _mapper.Map<Wkf10TipoParametro>(tipoparametro);

            await _repository.UpdateTipoParametro(tipoparametroModel);
            await _repository.SaveChanges();

            var tipoparametroResponse = _mapper.Map<TipoParametroResponseDto>(tipoparametroModel);

            var tipoparametrodto = await _repository.GetTipoParametroById(tipoparametroResponse.wkf10llave);

            if (tipoparametrodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoparametro por este id {tipoparametroResponse.wkf10llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoParametroResponseDto>(tipoparametrodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoParametro(int id)
        {

            var tipoparametrodto = await _repository.GetTipoParametroById(id);

            if (tipoparametrodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la tipoparametro por este id {id}" }
                );
            }
            else
            {
                if (tipoparametrodto.wkf10activo == 0)
                {
                    await _repository.DeleteTipoParametro(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoParametro(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipoparametros = await _repository.GetAllTipoParametros();
            return Ok(_mapper.Map<TipoParametroResponseDto[]>(listtipoparametros));

        }

        [HttpPost("~/api/tipoparametro/disabletipoparametro")]
        public async Task<ActionResult<TipoParametroResponseDto[]>> DisableTipoParametro
            (
                 [FromBody] TipoParametroResponseDto[] tipoparametros
            )
        {

            foreach (TipoParametroResponseDto item in tipoparametros)
            {
                var a = _mapper.Map<TipoParametroResponseDto>(item);

                await _repository.DisableTipoParametro(a.wkf10llave);
                await _repository.SaveChanges();
            }


            var listtipoparametros = await _repository.GetAllTipoParametros();
            return Ok(_mapper.Map<TipoParametroResponseDto[]>(listtipoparametros));

        }


        [HttpPost("~/api/TipoParametro/ActivateTipoParametro")]
        public async Task<ActionResult<TipoParametroResponseDto[]>> ActivateTipoParametro
            (
                 [FromBody] TipoParametroResponseDto[] tipoparametros
            )
        {

            foreach (TipoParametroResponseDto item in tipoparametros)
            {
                var a = _mapper.Map<TipoParametroResponseDto>(item);

                await _repository.ActivateTipoParametro(a.wkf10llave);
                await _repository.SaveChanges();
            }


            var listtipoparametros = await _repository.GetAllTipoParametros();
            return Ok(_mapper.Map<TipoParametroResponseDto[]>(listtipoparametros));

        }

    }
}
