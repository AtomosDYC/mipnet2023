using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Tipoespecie;
using mipBackend.Dtos.TipoespecieDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoespecieController : ControllerBase
    {
        private readonly ITipoespecieRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoespecieController
            (

                ITipoespecieRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoespecieResponseDto>>> GetTipoespecie()
        {

            var tipoespcies = await _repository.GetAllTipoespecies();
            return Ok(_mapper.Map<IEnumerable<TipoespecieResponseDto>>(tipoespcies));

        }

        [HttpGet("~/api/tipoespecie/GetTipoespecieById/{id}")]
        [ActionName(nameof(GetTipoespecieById))]
        public async Task<ActionResult<TipoespecieResponseDto>> GetTipoespecieById(int id)
        {


            var tipoespecie = await _repository.GetTipoespecieById(id);

            if (tipoespecie == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro El tipode especie por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoespecieResponseDto>(tipoespecie));

        }

        [HttpPost]
        public async Task<ActionResult<TipoespecieResponseDto>> CreateTipoespecie
            (
                [FromBody] TipoespecieRequestDto tipoespecie
            )
        { 

            var tipoespecieModel = _mapper.Map<esp08TipoBase>(tipoespecie);

            await _repository.CreateTipoespecie(tipoespecieModel);
            await _repository.SaveChanges();

            var tipoespecieResponse = _mapper.Map<TipoespecieResponseDto>(tipoespecieModel);

            var tipoespeciedto = await _repository.GetTipoespecieById(tipoespecieResponse.esp08llave);

            if (tipoespeciedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo especie por este id {tipoespecieResponse.esp08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoespecieResponseDto>(tipoespeciedto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoespecieResponseDto>> UpdateTipoespecie
            (
                [FromBody] TipoespecieResponseDto tipoespecie
            )
        {

            var tipoespecieModel = _mapper.Map<esp08TipoBase>(tipoespecie);

            await _repository.UpdateTipoespecie(tipoespecieModel);
            await _repository.SaveChanges();

            var tipoespecieResponse = _mapper.Map<TipoespecieResponseDto>(tipoespecieModel);

            var tipoespeciedto = await _repository.GetTipoespecieById(tipoespecieResponse.esp08llave);

            if (tipoespeciedto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el tipo de especie por este id {tipoespecieResponse.esp08llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoespecieResponseDto>(tipoespeciedto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoespecie(int id)
        {

            var tipoespeciedto = await _repository.GetTipoespecieById(id);

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
                    await _repository.DeleteTipoespecie(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoespecie(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipoespecies = await _repository.GetAllTipoespecies();
            return Ok(_mapper.Map<TipoespecieResponseDto[]>(listtipoespecies));

        }

        [HttpPost("~/api/tipoespecie/disabletipoespecie")]
        public async Task<ActionResult<TipoespecieResponseDto[]>> DisableTipoespecie
            (
                 [FromBody] TipoespecieResponseDto[] tipoespecies
            )
        {

            foreach (TipoespecieResponseDto item in tipoespecies)
            {
                var a = _mapper.Map<TipoespecieResponseDto>(item);

                await _repository.DisableTipoespecie(a.esp08llave);
                await _repository.SaveChanges();
            }


            var listtipoespecies = await _repository.GetAllTipoespecies();
            return Ok(_mapper.Map<TipoespecieResponseDto[]>(listtipoespecies));

        }


        [HttpPost("~/api/tipoespecie/activatetipoespecie")]
        public async Task<ActionResult<TipoespecieResponseDto[]>> ActivateTipoespecie
            (
                 [FromBody] TipoespecieResponseDto[] tipoespecies
            )
        {

            foreach (TipoespecieResponseDto item in tipoespecies)
            {
                var a = _mapper.Map<TipoespecieResponseDto>(item);

                await _repository.ActivateTipoespecie(a.esp08llave);
                await _repository.SaveChanges();
            }


            var listtipoespecies = await _repository.GetAllTipoespecies();
            return Ok(_mapper.Map<TipoespecieResponseDto[]>(listtipoespecies));

        }
    }
}
