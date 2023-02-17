using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoEspecie;
using mipBackend.Dtos.TipoEspecieDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEspecieController : ControllerBase
    {
        private readonly ITipoEspecieRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoEspecieController
            (

                ITipoEspecieRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEspecieResponseDto>>> GetTipoEspecie()
        {

            var tipoespcies = await _repository.GetAllTipoEspecies();
            return Ok(_mapper.Map<IEnumerable<TipoEspecieResponseDto>>(tipoespcies));

        }

        [HttpGet("~/api/tipoespecie/GetTipoEspecieById/{id}")]
        [ActionName(nameof(GetTipoEspecieById))]
        public async Task<ActionResult<TipoEspecieResponseDto>> GetTipoEspecieById(int id)
        {


            var tipoespecie = await _repository.GetTipoEspecieById(id);

            if (tipoespecie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipode especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoEspecieResponseDto>(tipoespecie));

        }

        [HttpPost]
        public async Task<ActionResult<TipoEspecieResponseDto>> CreateTipoEspecie
            (
                [FromBody] TipoEspecieRequestDto tipoespecie
            )
        { 

            var tipoespecieModel = _mapper.Map<Esp08TipoBase>(tipoespecie);

            await _repository.CreateTipoEspecie(tipoespecieModel);
            await _repository.SaveChanges();

            var tipoespecieResponse = _mapper.Map<TipoEspecieResponseDto>(tipoespecieModel);

            var tipoespeciedto = await _repository.GetTipoEspecieById(tipoespecieResponse.esp08llave);

            if (tipoespeciedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo especie por este id {tipoespecieResponse.esp08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoEspecieResponseDto>(tipoespeciedto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoEspecieResponseDto>> UpdateTipoEspecie
            (
                [FromBody] TipoEspecieResponseDto tipoespecie
            )
        {

            var tipoespecieModel = _mapper.Map<Esp08TipoBase>(tipoespecie);

            await _repository.UpdateTipoEspecie(tipoespecieModel);
            await _repository.SaveChanges();

            var tipoespecieResponse = _mapper.Map<TipoEspecieResponseDto>(tipoespecieModel);

            var tipoespeciedto = await _repository.GetTipoEspecieById(tipoespecieResponse.esp08llave);

            if (tipoespeciedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo de especie por este id {tipoespecieResponse.esp08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoEspecieResponseDto>(tipoespeciedto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoEspecie(int id)
        {

            var tipoespeciedto = await _repository.GetTipoEspecieById(id);

            if (tipoespeciedto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro El tipo de especie por este id {id}" }
                );
            }
            else
            {
                if (tipoespeciedto.esp08activo == 0)
                {
                    await _repository.DeleteTipoEspecie(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoEspecie(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipoespecies = await _repository.GetAllTipoEspecies();
            return Ok(_mapper.Map<TipoEspecieResponseDto[]>(listtipoespecies));

        }

        [HttpPost("~/api/tipoespecie/disabletipoespecie")]
        public async Task<ActionResult<TipoEspecieResponseDto[]>> DisableTipoEspecie
            (
                 [FromBody] TipoEspecieResponseDto[] tipoespecies
            )
        {

            foreach (TipoEspecieResponseDto item in tipoespecies)
            {
                var a = _mapper.Map<TipoEspecieResponseDto>(item);

                await _repository.DisableTipoEspecie(a.esp08llave);
                await _repository.SaveChanges();
            }


            var listtipoespecies = await _repository.GetAllTipoEspecies();
            return Ok(_mapper.Map<TipoEspecieResponseDto[]>(listtipoespecies));

        }


        [HttpPost("~/api/tipoespecie/activatetipoespecie")]
        public async Task<ActionResult<TipoEspecieResponseDto[]>> ActivateTipoEspecie
            (
                 [FromBody] TipoEspecieResponseDto[] tipoespecies
            )
        {

            foreach (TipoEspecieResponseDto item in tipoespecies)
            {
                var a = _mapper.Map<TipoEspecieResponseDto>(item);

                await _repository.ActivateTipoEspecie(a.esp08llave);
                await _repository.SaveChanges();
            }


            var listtipoespecies = await _repository.GetAllTipoEspecies();
            return Ok(_mapper.Map<TipoEspecieResponseDto[]>(listtipoespecies));

        }
    }
}
