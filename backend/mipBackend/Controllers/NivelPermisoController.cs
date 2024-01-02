using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Nivelpermisos;
using mipBackend.Dtos.NivelpermisoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelpermisoController : ControllerBase
    {
        private readonly INivelpermisoRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public NivelpermisoController
            (
                AppDbContext context,
                INivelpermisoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelpermisoResponseDto>>> GetNivelpermiso()
        {

            var Nivelpermisos = await _repository.GetAllNivelpermisos();
            return Ok(Nivelpermisos);

        }

        [HttpGet("~/api/Nivelpermiso/GetNivelpermisoById/{id}")]
        [ActionName(nameof(GetNivelpermisoById))]
        public async Task<ActionResult<NivelpermisoResponseDto>> GetNivelpermisoById(int id)
        {


            var Nivelpermiso = await _repository.GetNivelpermisoById(id);

            if (Nivelpermiso == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Nivelpermiso por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<NivelpermisoResponseDto>(Nivelpermiso));

        }

        [HttpPost]
        public async Task<ActionResult<NivelpermisoResponseDto>> CreateNivelpermiso
            (
               [FromBody] NivelpermisoRequestDto Nivelpermiso
            )
        {

            var NivelpermisoModel = _mapper.Map<wkf04Nivelpermiso>(Nivelpermiso);

            await _repository.CreateNivelpermiso(NivelpermisoModel);
            await _repository.SaveChanges();

            var NivelpermisoResponse = _mapper.Map<NivelpermisoResponseDto>(NivelpermisoModel);

            var Nivelpermisodto = await _repository.GetNivelpermisoById(NivelpermisoResponse.wkf04llave);

            if (Nivelpermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Nivelpermiso por este id {NivelpermisoResponse.wkf04llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelpermisoResponseDto>(Nivelpermisodto));



        }

        [HttpPut]
        public async Task<ActionResult<NivelpermisoResponseDto>> UpdateNivelpermiso
            (
                [FromBody] NivelpermisoResponseDto Nivelpermiso
            )
        {

            var NivelpermisoModel = _mapper.Map<wkf04Nivelpermiso>(Nivelpermiso);

            await _repository.UpdateNivelpermiso(NivelpermisoModel);
            await _repository.SaveChanges();

            var NivelpermisoResponse = _mapper.Map<NivelpermisoResponseDto>(NivelpermisoModel);

            var Nivelpermisodto = await _repository.GetNivelpermisoById(NivelpermisoResponse.wkf04llave);

            if (Nivelpermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Nivelpermiso por este id {NivelpermisoResponse.wkf04llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelpermisoResponseDto>(Nivelpermisodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNivelpermiso(int id)
        {

            var Nivelpermisodto = await _repository.GetNivelpermisoById(id);

            if (Nivelpermisodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Nivelpermiso por este id {id}" }
                );
            }
            else
            {
                await _repository.DeleteNivelpermiso(id);
                await _repository.SaveChanges();
            }


            var listNivelpermisos = await _repository.GetAllNivelpermisos();
            return Ok(_mapper.Map<NivelpermisoResponseDto[]>(listNivelpermisos));

        }

        [HttpPost("~/api/Nivelpermiso/disableNivelpermiso")]
        public async Task<ActionResult<NivelpermisoResponseDto[]>> DisableNivelpermiso
            (
                 [FromBody] NivelpermisoResponseDto[] Nivelpermisos
            )
        {

            foreach (NivelpermisoResponseDto item in Nivelpermisos)
            {
                var a = _mapper.Map<NivelpermisoResponseDto>(item);

                await _repository.DisableNivelpermiso(a.wkf04llave);
                await _repository.SaveChanges();
            }


            var listNivelpermisos = await _repository.GetAllNivelpermisos();
            return Ok(_mapper.Map<NivelpermisoResponseDto[]>(listNivelpermisos));

        }


        [HttpPost("~/api/Nivelpermiso/ActivateNivelpermiso")]
        public async Task<ActionResult<NivelpermisoResponseDto[]>> ActivateNivelpermiso
            (
                 [FromBody] NivelpermisoResponseDto[] Nivelpermisos
            )
        {

            foreach (NivelpermisoResponseDto item in Nivelpermisos)
            {
                var a = _mapper.Map<NivelpermisoResponseDto>(item);

                await _repository.ActivateNivelpermiso(a.wkf04llave);
                await _repository.SaveChanges();
            }


            var listNivelpermisos = await _repository.GetAllNivelpermisos();
            return Ok(_mapper.Map<NivelpermisoResponseDto[]>(listNivelpermisos));

        }

    }
}
