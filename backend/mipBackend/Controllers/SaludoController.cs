using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Saludos;
using mipBackend.Dtos.SaludoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludoController : ControllerBase
    {

        private readonly ISaludoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public SaludoController
            (

                ISaludoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaludoResponseDto>>> GetSaludo()
        {

            var saludos = await _repository.GetAllSaludos();
            return Ok(_mapper.Map<IEnumerable<SaludoResponseDto>>(saludos));

        }

        [HttpGet("~/api/Saludo/GetSaludoById/{id}")]
        [ActionName(nameof(GetSaludoById))]
        public async Task<ActionResult<SaludoResponseDto>> GetSaludoById(int id)
        {


            var saludo = await _repository.GetSaludoById(id);

            if (saludo == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la saludo por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<SaludoResponseDto>(saludo));

        }

        [HttpPost]
        public async Task<ActionResult<SaludoResponseDto>> CreateSaludo
            (
               [FromBody] SaludoRequestDto saludo
            )
        {

            var saludoModel = _mapper.Map<Per02Genero>(saludo);

            await _repository.CreateSaludo(saludoModel);
            await _repository.SaveChanges();

            var saludoResponse = _mapper.Map<SaludoResponseDto>(saludoModel);

            var saludodto = await _repository.GetSaludoById(saludoResponse.per02llave);

            if (saludodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la saludo por este id {saludoResponse.per02llave}" }
                    );
            }

            return Ok(_mapper.Map<SaludoResponseDto>(saludodto));



        }

        [HttpPut]
        public async Task<ActionResult<SaludoResponseDto>> UpdateSaludo
            (
                [FromBody] SaludoResponseDto saludo
            )
        {

            var saludoModel = _mapper.Map<Per02Genero>(saludo);

            await _repository.UpdateSaludo(saludoModel);
            await _repository.SaveChanges();

            var saludoResponse = _mapper.Map<SaludoResponseDto>(saludoModel);

            var saludodto = await _repository.GetSaludoById(saludoResponse.per02llave);

            if (saludodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la saludo por este id {saludoResponse.per02llave}" }
                    );
            }

            return Ok(_mapper.Map<SaludoResponseDto>(saludodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaludo(int id)
        {

            var saludodto = await _repository.GetSaludoById(id);

            if (saludodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la saludo por este id {id}" }
                );
            }
            else
            {
                if (saludodto.per02activo == 0)
                {
                    await _repository.DeleteSaludo(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableSaludo(id);
                    await _repository.SaveChanges();
                }
            }


            var listsaludos = await _repository.GetAllSaludos();
            return Ok(_mapper.Map<SaludoResponseDto[]>(listsaludos));

        }

        [HttpPost("~/api/saludo/disablesaludo")]
        public async Task<ActionResult<SaludoResponseDto[]>> DisableSaludo
            (
                 [FromBody] SaludoResponseDto[] saludos
            )
        {

            foreach (SaludoResponseDto item in saludos)
            {
                var a = _mapper.Map<SaludoResponseDto>(item);

                await _repository.DisableSaludo(a.per02llave);
                await _repository.SaveChanges();
            }


            var listsaludos = await _repository.GetAllSaludos();
            return Ok(_mapper.Map<SaludoResponseDto[]>(listsaludos));

        }


        [HttpPost("~/api/Saludo/ActivateSaludo")]
        public async Task<ActionResult<SaludoResponseDto[]>> ActivateSaludo
            (
                 [FromBody] SaludoResponseDto[] saludos
            )
        {

            foreach (SaludoResponseDto item in saludos)
            {
                var a = _mapper.Map<SaludoResponseDto>(item);

                await _repository.ActivateSaludo(a.per02llave);
                await _repository.SaveChanges();
            }


            var listsaludos = await _repository.GetAllSaludos();
            return Ok(_mapper.Map<SaludoResponseDto[]>(listsaludos));

        }

    }
}
