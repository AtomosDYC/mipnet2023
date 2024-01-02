using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.MedidaUmbrales;
using mipBackend.Dtos.MedidaUmbralDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidaUmbralController : ControllerBase
    {
        private readonly IMedidaUmbralRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MedidaUmbralController
            (

                IMedidaUmbralRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedidaUmbralResponseDto>>> GetMedidaUmbral()
        {

            var medidaumbrales = await _repository.GetAllMedidaUmbrales();
            return Ok(_mapper.Map<IEnumerable<MedidaUmbralResponseDto>>(medidaumbrales));

        }

        [HttpGet("~/api/MedidaUmbral/GetMedidaUmbralById/{id}")]
        [ActionName(nameof(GetMedidaUmbralById))]
        public async Task<ActionResult<MedidaUmbralResponseDto>> GetMedidaUmbralById(int id)
        {


            var medidaumbral = await _repository.GetMedidaUmbralById(id);

            if (medidaumbral == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la medida de umbral por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<MedidaUmbralResponseDto>(medidaumbral));

        }

        [HttpPost]
        public async Task<ActionResult<MedidaUmbralResponseDto>> CreateMedidaUmbral
            (
               [FromBody] MedidaUmbralRequestDto medidaumbral
            )
        {

            var medidaumbralModel = _mapper.Map<esp06MedidaUmbral>(medidaumbral);

            await _repository.CreateMedidaUmbral(medidaumbralModel);
            await _repository.SaveChanges();

            var medidaumbralResponse = _mapper.Map<MedidaUmbralResponseDto>(medidaumbralModel);

            var medidaumbraldto = await _repository.GetMedidaUmbralById(medidaumbralResponse.esp06llave);

            if (medidaumbraldto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la medidaumbral por este id {medidaumbralResponse.esp06llave}" }
                    );
            }

            return Ok(_mapper.Map<MedidaUmbralResponseDto>(medidaumbraldto));



        }

        [HttpPut]
        public async Task<ActionResult<MedidaUmbralResponseDto>> UpdateMedidaUmbral
            (
                [FromBody] MedidaUmbralResponseDto medidaumbral
            )
        {

            var medidaumbralModel = _mapper.Map<esp06MedidaUmbral>(medidaumbral);

            await _repository.UpdateMedidaUmbral(medidaumbralModel);
            await _repository.SaveChanges();

            var medidaumbralResponse = _mapper.Map<MedidaUmbralResponseDto>(medidaumbralModel);

            var medidaumbraldto = await _repository.GetMedidaUmbralById(medidaumbralResponse.esp06llave);

            if (medidaumbraldto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la medida del umbral por este id {medidaumbralResponse.esp06llave}" }
                    );
            }

            return Ok(_mapper.Map<MedidaUmbralResponseDto>(medidaumbraldto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedidaUmbral(int id)
        {

            var medidaumbraldto = await _repository.GetMedidaUmbralById(id);

            if (medidaumbraldto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la medida del umbral por este id {id}" }
                );
            }
            else
            {
                if (medidaumbraldto.esp06activo == 0)
                {
                    await _repository.DeleteMedidaUmbral(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableMedidaUmbral(id);
                    await _repository.SaveChanges();
                }
            }


            var listmedidaumbrales = await _repository.GetAllMedidaUmbrales();
            return Ok(_mapper.Map<MedidaUmbralResponseDto[]>(listmedidaumbrales));

        }

        [HttpPost("~/api/medidaumbral/disablemedidaumbral")]
        public async Task<ActionResult<MedidaUmbralResponseDto[]>> DisableMedidaUmbral
            (
                 [FromBody] MedidaUmbralResponseDto[] medidaumbrales
            )
        {

            foreach (MedidaUmbralResponseDto item in medidaumbrales)
            {
                var a = _mapper.Map<MedidaUmbralResponseDto>(item);

                await _repository.DisableMedidaUmbral(a.esp06llave);
                await _repository.SaveChanges();
            }


            var listmedidaumbrales = await _repository.GetAllMedidaUmbrales();
            return Ok(_mapper.Map<MedidaUmbralResponseDto[]>(listmedidaumbrales));

        }


        [HttpPost("~/api/medidaumbral/activatemedidaumbral")]
        public async Task<ActionResult<MedidaUmbralResponseDto[]>> ActivateMedidaUmbral
            (
                 [FromBody] MedidaUmbralResponseDto[] medidaumbrales
            )
        {

            foreach (MedidaUmbralResponseDto item in medidaumbrales)
            {
                var a = _mapper.Map<MedidaUmbralResponseDto>(item);

                await _repository.ActivateMedidaUmbral(a.esp06llave);
                await _repository.SaveChanges();
            }


            var listmedidaumbrales = await _repository.GetAllMedidaUmbrales();
            return Ok(_mapper.Map<MedidaUmbralResponseDto[]>(listmedidaumbrales));

        }
    }
}
