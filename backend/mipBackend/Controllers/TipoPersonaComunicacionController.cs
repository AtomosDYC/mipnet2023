using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoperComunicaciones;
using mipBackend.Dtos.TipoperComunicacionDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipopersonaComunicacionController : ControllerBase
    {
        private readonly ITipoperComunicacionRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipopersonaComunicacionController
            (
                AppDbContext context,
                ITipoperComunicacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoperComunicacionResponseDto>>> GetTipopersonaComunicacion()
        {

            var Nivelpermisos = await _repository.GetAllTipoperComunicaciones();
            return Ok(Nivelpermisos);

        }

        [HttpGet("~/api/tipopersonacomunicacion/GetTipoperComunicacionById/{id}")]
        [ActionName(nameof(GetTipoperComunicacionById))]
        public async Task<ActionResult<TipoperComunicacionResponseDto>> GetTipoperComunicacionById(int id)
        {


            var tipopercomunicacion = await _repository.GetTipoperComunicacionById(id);

            if (tipopercomunicacion == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Nivelpermiso por este id {id}" }
                    );
            }

            return Ok(tipopercomunicacion);

        }

        [HttpPost]
        public async Task<ActionResult<TipoperComunicacionResponseDto>> CreateTipopersonaComunicacion
            (
               [FromBody] TipoperComunicacionRequestDto request
            )
        {

            var requestModel = _mapper.Map<per06TipopersonaComunicacion>(request);

            await _repository.CreateTipoperComunicacion(requestModel);
            await _repository.SaveChanges();

        
            var listTipoperComunicaciones = await _repository.GetTipoperComunicacionById(request.per04llave);
            return Ok(_mapper.Map<TipoperComunicacionResponseDto[]>(listTipoperComunicaciones));

        }


        [HttpPost("~/api/TipopersonaComunicacion/borrarTipoperComunicacion")]
        public async Task<ActionResult<TipoperComunicacionResponseDto>> borrarTipoperComunicacion(TipoperComunicacionRequestDto request)
        {

            var tipoperComunicacionResponses = await _repository.GetTipoperComunicacionById(request.per04llave);

            if (tipoperComunicacionResponses == null)
            {
                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Nivelpermiso por este id {request.per04llave}" }
                );
            }
            else
            {
                await _repository.DeleteTipoperComunicacion(request);
                await _repository.SaveChanges();
            }
            
            var listTipoperComunicaciones = await _repository.GetTipoperComunicacionById(request.per04llave);
            return Ok(_mapper.Map<TipoperComunicacionResponseDto[]>(listTipoperComunicaciones));

        }

        
    }
}