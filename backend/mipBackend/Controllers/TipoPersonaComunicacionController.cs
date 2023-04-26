using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoPerComunicaciones;
using mipBackend.Dtos.TipoPerComunicacionDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonaComunicacionController : ControllerBase
    {
        private readonly ITipoPerComunicacionRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoPersonaComunicacionController
            (
                AppDbContext context,
                ITipoPerComunicacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPerComunicacionResponseDto>>> GetTipoPersonaComunicacion()
        {

            var NivelPermisos = await _repository.GetAllTipoPerComunicaciones();
            return Ok(NivelPermisos);

        }

        [HttpGet("~/api/tipopersonacomunicacion/GetTipoPerComunicacionById/{id}")]
        [ActionName(nameof(GetTipoPerComunicacionById))]
        public async Task<ActionResult<TipoPerComunicacionResponseDto>> GetTipoPerComunicacionById(int id)
        {


            var tipopercomunicacion = await _repository.GetTipoPerComunicacionById(id);

            if (tipopercomunicacion == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelPermiso por este id {id}" }
                    );
            }

            return Ok(tipopercomunicacion);

        }

        [HttpPost]
        public async Task<ActionResult<TipoPerComunicacionResponseDto>> CreateTipoPersonaComunicacion
            (
               [FromBody] TipoPerComunicacionRequestDto request
            )
        {

            var requestModel = _mapper.Map<Per06TipoPersonaComunicacion>(request);

            await _repository.CreateTipoPerComunicacion(requestModel);
            await _repository.SaveChanges();

        
            var listTipoPerComunicaciones = await _repository.GetTipoPerComunicacionById(request.per04llave);
            return Ok(_mapper.Map<TipoPerComunicacionResponseDto[]>(listTipoPerComunicaciones));

        }


        [HttpPost("~/api/TipoPersonaComunicacion/borrarTipoPerComunicacion")]
        public async Task<ActionResult<TipoPerComunicacionResponseDto>> borrarTipoPerComunicacion(TipoPerComunicacionRequestDto request)
        {

            var tipoPerComunicacionResponses = await _repository.GetTipoPerComunicacionById(request.per04llave);

            if (tipoPerComunicacionResponses == null)
            {
                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la NivelPermiso por este id {request.per04llave}" }
                );
            }
            else
            {
                await _repository.DeleteTipoPerComunicacion(request);
                await _repository.SaveChanges();
            }
            
            var listTipoPerComunicaciones = await _repository.GetTipoPerComunicacionById(request.per04llave);
            return Ok(_mapper.Map<TipoPerComunicacionResponseDto[]>(listTipoPerComunicaciones));

        }

        
    }
}