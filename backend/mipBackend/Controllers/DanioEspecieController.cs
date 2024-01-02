using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Especies;
using mipBackend.Dtos.EspecieDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanioEspecieController : ControllerBase
    {
        private readonly IDanioEspecieRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public DanioEspecieController
            (

                IDanioEspecieRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("~/api/danioespecie/GetEstadosDanioById/{id}")]
        [ActionName(nameof(GetEstadosDanioById))]
        public async Task<ActionResult<IEnumerable<DanioEspecieResponseDto>>> GetEstadosDanioById(int id)
        {


            var especie = await _repository.GetDanioEspecie(id);

            if (especie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipo de Daño en especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<DanioEspecieResponseDto>>(especie));

        }



        [HttpPost("~/api/danioespecie/CreateDanioespecie")]
        [ActionName(nameof(CreateDanioespecie))]
        public async Task<ActionResult<IEnumerable<DanioEspecieRequestDto>>> CreateDanioespecie
            (
               [FromBody] DanioEspecieRequestDto request
            )
        {

            var especieModel = _mapper.Map<esp01especie>(request);

            await _repository.CreateDanioEspecie(especieModel);
            await _repository.SaveChanges();

            var DanioEspecie = _mapper.Map<esp01especie>(especieModel);


            var especiedto = await _repository.GetDanioEspecie(DanioEspecie.esp03llave);


            if (especiedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {especieModel.esp03llave}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<DanioEspecieResponseDto>>(especiedto));

        }


        [HttpDelete("~/api/especiedanio/deleteDanioespecie/{id}")]
        [ActionName(nameof(deleteespeciedanio))]
        public async Task<ActionResult<IEnumerable<DanioEspecieResponseDto>>> deleteespeciedanio(DanioEspecieResponseDto request)
        {


            await _repository.DeleteDanioEspecie(request);
            await _repository.SaveChanges();



            var list = await _repository.GetDanioEspecie(request.esp03llave);
            return Ok(_mapper.Map<IEnumerable<DanioEspecieResponseDto>>(list));

        }

    }
}
