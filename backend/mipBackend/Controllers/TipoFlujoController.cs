using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoFlujos;
using mipBackend.Dtos.TipoFlujoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFlujoController : ControllerBase
    {

        private readonly ITipoFlujosRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoFlujoController
            (

                ITipoFlujosRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFlujoResponseDto>>> GetTipoFlujo()
        {

            var TipoFlujos = await _repository.GetAllTipoFlujos();
            return Ok(_mapper.Map<IEnumerable<TipoFlujoResponseDto>>(TipoFlujos));

        }

        [HttpGet("~/api/TipoFlujo/GetTipoFlujoById/{id}")]
        [ActionName(nameof(GetTipoFlujoById))]
        public async Task<ActionResult<TipoFlujoResponseDto>> GetTipoFlujoById(int id)
        {


            var tipoflujo = await _repository.GetTipoFlujoById(id);

            if (tipoflujo == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoflujo por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoFlujoResponseDto>(tipoflujo));

        }

        [HttpPost]
        public async Task<ActionResult<TipoFlujoResponseDto>> CreateTipoFlujo
            (
               [FromBody] TipoFlujoRequestDto tipoflujo
            )
        {

            var tipoflujoModel = _mapper.Map<wkf02TipoFlujo>(tipoflujo);

            await _repository.CreateTipoFlujo(tipoflujoModel);
            await _repository.SaveChanges();

            var tipoflujoResponse = _mapper.Map<TipoFlujoResponseDto>(tipoflujoModel);

            var tipoflujodto = await _repository.GetTipoFlujoById(tipoflujoResponse.wkf02llave);

            if (tipoflujodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoflujo por este id {tipoflujoResponse.wkf02llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoFlujoResponseDto>(tipoflujodto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoFlujoResponseDto>> UpdateTipoFlujo
            (
                [FromBody] TipoFlujoResponseDto tipoflujo
            )
        {

            var tipoflujoModel = _mapper.Map<wkf02TipoFlujo>(tipoflujo);

            await _repository.UpdateTipoFlujo(tipoflujoModel);
            await _repository.SaveChanges();

            var tipoflujoResponse = _mapper.Map<TipoFlujoResponseDto>(tipoflujoModel);

            var tipoflujodto = await _repository.GetTipoFlujoById(tipoflujoResponse.wkf02llave);

            if (tipoflujodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipoflujo por este id {tipoflujoResponse.wkf02llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoFlujoResponseDto>(tipoflujodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoFlujo(int id)
        {

            var tipoflujodto = await _repository.GetTipoFlujoById(id);

            if (tipoflujodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la tipoflujo por este id {id}" }
                );
            }
            else
            {
                if (tipoflujodto.wkf02activo == 0)
                {
                    await _repository.DeleteTipoFlujo(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoFlujo(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipoflujos = await _repository.GetAllTipoFlujos();
            return Ok(_mapper.Map<TipoFlujoResponseDto[]>(listtipoflujos));

        }

        [HttpPost("~/api/tipoflujo/disabletipoflujo")]
        public async Task<ActionResult<TipoFlujoResponseDto[]>> DisableTipoFlujo
            (
                 [FromBody] TipoFlujoResponseDto[] tipoflujos
            )
        {

            foreach (TipoFlujoResponseDto item in tipoflujos)
            {
                var a = _mapper.Map<TipoFlujoResponseDto>(item);

                await _repository.DisableTipoFlujo(a.wkf02llave);
                await _repository.SaveChanges();
            }


            var listtipoflujos = await _repository.GetAllTipoFlujos();
            return Ok(_mapper.Map<TipoFlujoResponseDto[]>(listtipoflujos));

        }


        [HttpPost("~/api/TipoFlujo/ActivateTipoFlujo")]
        public async Task<ActionResult<TipoFlujoResponseDto[]>> ActivateTipoFlujo
            (
                 [FromBody] TipoFlujoResponseDto[] tipoflujos
            )
        {

            foreach (TipoFlujoResponseDto item in tipoflujos)
            {
                var a = _mapper.Map<TipoFlujoResponseDto>(item);

                await _repository.ActivateTipoFlujo(a.wkf02llave);
                await _repository.SaveChanges();
            }


            var listtipoflujos = await _repository.GetAllTipoFlujos();
            return Ok(_mapper.Map<TipoFlujoResponseDto[]>(listtipoflujos));

        }
        
    }
}
