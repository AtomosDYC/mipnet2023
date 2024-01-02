using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Especies;
using mipBackend.Dtos.EspecieDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieUmbralController : ControllerBase
    {
        private readonly IUmbralEspecieRepository _repository;
        private readonly AppDbContext _contexto;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public EspecieUmbralController
            (
                AppDbContext context,
                IUmbralEspecieRepository repository,
                IMapper mapper

            )
        {
            _contexto = context;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("~/api/especieumbral/GetUmbralEspecieByid/{id}")]
        [ActionName(nameof(GetUmbralEspecieByid))]
        public async Task<ActionResult<IEnumerable<UmbralEspecieResponseDto>>> GetUmbralEspecieByid(int id)
        {


            var especie = await _repository.GetUmbralEspecie(id);

            if (especie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipo de Daño en especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<UmbralEspecieResponseDto>>(especie));

        }



        [HttpPost("~/api/especieumbral/CreateUmbralEspecie")]
        [ActionName(nameof(CreateUmbralEspecie))]
        public async Task<ActionResult<IEnumerable<UmbralEspecieResponseDto>>> CreateUmbralEspecie
            (
               [FromBody] UmbralEspecieRequestDto request
            )
        {

            var especieModel = _mapper.Map<esp05Umbral>(request);

            await _repository.CreateUmbralEspecie(especieModel);
            await _repository.SaveChanges();



            var especiedto = await _repository.GetUmbralEspecieById(especieModel.esp01llave);


            if (especiedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la workflow por este id {especieModel.esp05llave}" }
                    );
            }

            return Ok(_mapper.Map<IEnumerable<UmbralEspecieResponseDto>>(especiedto));

        }


        [HttpDelete("~/api/especieumbral/DeleteUmbralEspecie/{id}")]
        [ActionName(nameof(DeleteUmbralEspecie))]
        public async Task<ActionResult<IEnumerable<UmbralEspecieResponseDto>>> DeleteUmbralEspecie(int id)
        {

            var query = await _repository.GetUmbralEspecieByIdUMbral(id);

            if (query == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el umbral por este id {id}" }
                    );
            }

            var umbral = _mapper.Map<esp05Umbral>(query);

            var resultado = _repository.DeleteUmbralEspecie(id);
            await _repository.SaveChanges();

            var list = await _repository.GetUmbralEspecieById(umbral.esp01llave);
            return Ok(_mapper.Map<IEnumerable<UmbralEspecieResponseDto>>(list));
            

        }

    }
}
