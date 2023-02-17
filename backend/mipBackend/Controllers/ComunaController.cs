using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Comunas;
using mipBackend.Dtos.ComunaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : ControllerBase
    {

        private readonly IComunaRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ComunaController
            (
                AppDbContext context,
                IComunaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunaResponseDto>>> GetComuna()
        {

           var Comunas = await _repository.GetAllComunas();
            return Ok(Comunas);

        }

        [HttpGet("~/api/Comuna/GetComunaById/{id}")]
        [ActionName(nameof(GetComunaById))]
        public async Task<ActionResult<ComunaResponseDto>> GetComunaById(int id)
        {


            var Comuna = await _repository.GetComunaById(id);

            if (Comuna == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<ComunaResponseDto>(Comuna));

        }

        [HttpPost]
        public async Task<ActionResult<ComunaResponseDto>> CreateComuna
            (
               [FromBody] ComunaRequestDto Comuna
            )
        {

            var ComunaModel = _mapper.Map<Sist03Comuna>(Comuna);

            await _repository.CreateComuna(ComunaModel);
            await _repository.SaveChanges();

            var ComunaResponse = _mapper.Map<ComunaResponseDto>(ComunaModel);

            var Comunadto = await _repository.GetComunaById(ComunaResponse.sist03llave);

            if (Comunadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {ComunaResponse.sist03llave}" }
                    );
            }

            return Ok(_mapper.Map<ComunaResponseDto>(Comunadto));



        }

        [HttpPut]
        public async Task<ActionResult<ComunaResponseDto>> UpdateComuna
            (
                [FromBody] ComunaResponseDto Comuna
            )
        {

            var ComunaModel = _mapper.Map<Sist03Comuna>(Comuna);

            await _repository.UpdateComuna(ComunaModel);
            await _repository.SaveChanges();

            var ComunaResponse = _mapper.Map<ComunaResponseDto>(ComunaModel);

            var Comunadto = await _repository.GetComunaById(ComunaResponse.sist03llave);

            if (Comunadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {ComunaResponse.sist03llave}" }
                    );
            }

            return Ok(_mapper.Map<ComunaResponseDto>(Comunadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComuna(int id)
        {

            var Comunadto = await _repository.GetComunaById(id);

            if (Comunadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Comuna por este id {id}" }
                );
            }
            else
            {
                if (Comunadto.sist03activo == 0)
                {
                    await _repository.DeleteComuna(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableComuna(id);
                    await _repository.SaveChanges();
                }
            }


            var listComunas = await _repository.GetAllComunas();
            return Ok(_mapper.Map<ComunaResponseDto[]>(listComunas));

        }

        [HttpPost("~/api/Comuna/disableComuna")]
        public async Task<ActionResult<ComunaResponseDto[]>> DisableComuna
            (
                 [FromBody] ComunaResponseDto[] Comunas
            )
        {

            foreach (ComunaResponseDto item in Comunas)
            {
                var a = _mapper.Map<ComunaResponseDto>(item);

                await _repository.DisableComuna(a.sist03llave);
                await _repository.SaveChanges();
            }


            var listComunas = await _repository.GetAllComunas();
            return Ok(_mapper.Map<ComunaResponseDto[]>(listComunas));

        }


        [HttpPost("~/api/Comuna/ActivateComuna")]
        public async Task<ActionResult<ComunaResponseDto[]>> ActivateComuna
            (
                 [FromBody] ComunaResponseDto[] Comunas
            )
        {

            foreach (ComunaResponseDto item in Comunas)
            {
                var a = _mapper.Map<ComunaResponseDto>(item);

                await _repository.ActivateComuna(a.sist03llave);
                await _repository.SaveChanges();
            }


            var listComunas = await _repository.GetAllComunas();
            return Ok(_mapper.Map<ComunaResponseDto[]>(listComunas));

        }

    }
}
