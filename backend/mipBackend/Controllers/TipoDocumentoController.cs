using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoDocumentos;
using mipBackend.Dtos.TipoDocumentoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoDocumentoController
            (

                ITipoDocumentoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoResponseDto>>> GetTipoDocumento()
        {

            var TipoDocumentos = await _repository.GetAllTipoDocumentos();
            return Ok(_mapper.Map<IEnumerable<TipoDocumentoResponseDto>>(TipoDocumentos));

        }

        [HttpGet("~/api/TipoDocumento/GetTipoDocumentoById/{id}")]
        [ActionName(nameof(GetTipoDocumentoById))]
        public async Task<ActionResult<TipoDocumentoResponseDto>> GetTipoDocumentoById(int id)
        {


            var TipoDocumento = await _repository.GetTipoDocumentoById(id);

            if (TipoDocumento == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoDocumento por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoDocumentoResponseDto>(TipoDocumento));

        }

        [HttpPost]
        public async Task<ActionResult<TipoDocumentoResponseDto>> CreateTipoDocumento
            (
               [FromBody] TipoDocumentoRequestDto TipoDocumento
            )
        {

            var TipoDocumentoModel = _mapper.Map<Per08TipoDocumento>(TipoDocumento);

            await _repository.CreateTipoDocumento(TipoDocumentoModel);
            await _repository.SaveChanges();

            var TipoDocumentoResponse = _mapper.Map<TipoDocumentoResponseDto>(TipoDocumentoModel);

            var TipoDocumentodto = await _repository.GetTipoDocumentoById(TipoDocumentoResponse.per08llave);

            if (TipoDocumentodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoDocumento por este id {TipoDocumentoResponse.per08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoDocumentoResponseDto>(TipoDocumentodto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoDocumentoResponseDto>> UpdateTipoDocumento
            (
                [FromBody] TipoDocumentoResponseDto TipoDocumento
            )
        {

            var TipoDocumentoModel = _mapper.Map<Per08TipoDocumento>(TipoDocumento);

            await _repository.UpdateTipoDocumento(TipoDocumentoModel);
            await _repository.SaveChanges();

            var TipoDocumentoResponse = _mapper.Map<TipoDocumentoResponseDto>(TipoDocumentoModel);

            var TipoDocumentodto = await _repository.GetTipoDocumentoById(TipoDocumentoResponse.per08llave);

            if (TipoDocumentodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la TipoDocumento por este id {TipoDocumentoResponse.per08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoDocumentoResponseDto>(TipoDocumentodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoDocumento(int id)
        {

            var TipoDocumentodto = await _repository.GetTipoDocumentoById(id);

            if (TipoDocumentodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la TipoDocumento por este id {id}" }
                );
            }
            else
            {
                if (TipoDocumentodto.per08activo == 0)
                {
                    await _repository.DeleteTipoDocumento(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoDocumento(id);
                    await _repository.SaveChanges();
                }
            }


            var listTipoDocumentos = await _repository.GetAllTipoDocumentos();
            return Ok(_mapper.Map<TipoDocumentoResponseDto[]>(listTipoDocumentos));

        }

        [HttpPost("~/api/TipoDocumento/disableTipoDocumento")]
        public async Task<ActionResult<TipoDocumentoResponseDto[]>> DisableTipoDocumento
            (
                 [FromBody] TipoDocumentoResponseDto[] TipoDocumentos
            )
        {

            foreach (TipoDocumentoResponseDto item in TipoDocumentos)
            {
                var a = _mapper.Map<TipoDocumentoResponseDto>(item);

                await _repository.DisableTipoDocumento(a.per08llave);
                await _repository.SaveChanges();
            }


            var listTipoDocumentos = await _repository.GetAllTipoDocumentos();
            return Ok(_mapper.Map<TipoDocumentoResponseDto[]>(listTipoDocumentos));

        }


        [HttpPost("~/api/TipoDocumento/ActivateTipoDocumento")]
        public async Task<ActionResult<TipoDocumentoResponseDto[]>> ActivateTipoDocumento
            (
                 [FromBody] TipoDocumentoResponseDto[] TipoDocumentos
            )
        {

            foreach (TipoDocumentoResponseDto item in TipoDocumentos)
            {
                var a = _mapper.Map<TipoDocumentoResponseDto>(item);

                await _repository.ActivateTipoDocumento(a.per08llave);
                await _repository.SaveChanges();
            }


            var listTipoDocumentos = await _repository.GetAllTipoDocumentos();
            return Ok(_mapper.Map<TipoDocumentoResponseDto[]>(listTipoDocumentos));

        }

    }
}
