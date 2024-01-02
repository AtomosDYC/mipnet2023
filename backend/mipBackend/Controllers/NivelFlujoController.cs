using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.NivelFlujos;
using mipBackend.Dtos.NivelFlujoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelFlujoController : ControllerBase
    {
        private readonly INivelFlujoRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public NivelFlujoController
            (
                AppDbContext context,
                INivelFlujoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelFlujoResponseDto>>> GetNivelFlujo()
        {

            var nivelflujos = await _repository.GetAllNivelFlujos();
            return Ok(nivelflujos);

        }

        [HttpGet("~/api/NivelFlujo/GetNivelFlujoById/{id}")]
        [ActionName(nameof(GetNivelFlujoById))]
        public async Task<ActionResult<NivelFlujoResponseDto>> GetNivelFlujoById(int id)
        {


            var nivelflujo = await _repository.GetNivelFlujoById(id);

            if (nivelflujo == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelFlujo por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<NivelFlujoResponseDto>(nivelflujo));

        }

        [HttpPost]
        public async Task<ActionResult<NivelFlujoResponseDto>> CreateNivelFlujo
            (
               [FromBody] NivelFlujoRequestDto nivelflujo
            )
        {

            var NivelFlujoModel = _mapper.Map<wkf03Nivel>(nivelflujo);

            await _repository.CreateNivelFlujo(NivelFlujoModel);
            await _repository.SaveChanges();

            var NivelFlujoResponse = _mapper.Map<NivelFlujoResponseDto>(NivelFlujoModel);

            var NivelFlujodto = await _repository.GetNivelFlujoById(NivelFlujoResponse.wkf03llave);

            if (NivelFlujodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelFlujo por este id {NivelFlujoResponse.wkf03llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelFlujoResponseDto>(NivelFlujodto));



        }

        [HttpPut]
        public async Task<ActionResult<NivelFlujoResponseDto>> UpdateNivelFlujo
            (
                [FromBody] NivelFlujoResponseDto nivelflujo
            )
        {

            var NivelFlujoModel = _mapper.Map<wkf03Nivel>(nivelflujo);

            await _repository.UpdateNivelFlujo(NivelFlujoModel);
            await _repository.SaveChanges();

            var NivelFlujoResponse = _mapper.Map<NivelFlujoResponseDto>(NivelFlujoModel);

            var NivelFlujodto = await _repository.GetNivelFlujoById(NivelFlujoResponse.wkf03llave);

            if (NivelFlujodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {NivelFlujoResponse.wkf03llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelFlujoResponseDto>(NivelFlujodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNivelFlujo(int id)
        {

            var NivelFlujodto = await _repository.GetNivelFlujoById(id);

            if (NivelFlujodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la NivelFlujo por este id {id}" }
                );
            }
            else
            {
                if (NivelFlujodto.wkf03activo == 0)
                {
                    await _repository.DeleteNivelFlujo(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableNivelFlujo(id);
                    await _repository.SaveChanges();
                }
            }


            var listNivelflujos = await _repository.GetAllNivelFlujos();
            return Ok(_mapper.Map<NivelFlujoResponseDto[]>(listNivelflujos));

        }

        [HttpPost("~/api/NivelFlujo/disableNivelFlujo")]
        public async Task<ActionResult<NivelFlujoResponseDto[]>> DisableNivelFlujo
            (
                 [FromBody] NivelFlujoResponseDto[] nivelflujos
            )
        {

            foreach (NivelFlujoResponseDto item in nivelflujos)
            {
                var a = _mapper.Map<NivelFlujoResponseDto>(item);

                await _repository.DisableNivelFlujo(a.wkf03llave);
                await _repository.SaveChanges();
            }


            var listNivelflujos = await _repository.GetAllNivelFlujos();
            return Ok(_mapper.Map<NivelFlujoResponseDto[]>(listNivelflujos));

        }


        [HttpPost("~/api/NivelFlujo/ActivateNivelFlujo")]
        public async Task<ActionResult<NivelFlujoResponseDto[]>> ActivateNivelFlujo
            (
                 [FromBody] NivelFlujoResponseDto[] Nivelflujos
            )
        {

            foreach (NivelFlujoResponseDto item in Nivelflujos)
            {
                var a = _mapper.Map<NivelFlujoResponseDto>(item);

                await _repository.ActivateNivelFlujo(a.wkf03llave);
                await _repository.SaveChanges();
            }


            var listNivelflujos = await _repository.GetAllNivelFlujos();
            return Ok(_mapper.Map<NivelFlujoResponseDto[]>(listNivelflujos));

        }

    }
}
