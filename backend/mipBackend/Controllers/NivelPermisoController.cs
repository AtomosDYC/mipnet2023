using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.NivelPermisos;
using mipBackend.Dtos.NivelPermisoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelPermisoController : ControllerBase
    {
        private readonly INivelPermisoRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public NivelPermisoController
            (
                AppDbContext context,
                INivelPermisoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelPermisoResponseDto>>> GetNivelPermiso()
        {

            var NivelPermisos = await _repository.GetAllNivelPermisos();
            return Ok(NivelPermisos);

        }

        [HttpGet("~/api/NivelPermiso/GetNivelPermisoById/{id}")]
        [ActionName(nameof(GetNivelPermisoById))]
        public async Task<ActionResult<NivelPermisoResponseDto>> GetNivelPermisoById(int id)
        {


            var NivelPermiso = await _repository.GetNivelPermisoById(id);

            if (NivelPermiso == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelPermiso por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<NivelPermisoResponseDto>(NivelPermiso));

        }

        [HttpPost]
        public async Task<ActionResult<NivelPermisoResponseDto>> CreateNivelPermiso
            (
               [FromBody] NivelPermisoRequestDto NivelPermiso
            )
        {

            var NivelPermisoModel = _mapper.Map<Wkf04NivelPermiso>(NivelPermiso);

            await _repository.CreateNivelPermiso(NivelPermisoModel);
            await _repository.SaveChanges();

            var NivelPermisoResponse = _mapper.Map<NivelPermisoResponseDto>(NivelPermisoModel);

            var NivelPermisodto = await _repository.GetNivelPermisoById(NivelPermisoResponse.wkf04llave);

            if (NivelPermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelPermiso por este id {NivelPermisoResponse.wkf04llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelPermisoResponseDto>(NivelPermisodto));



        }

        [HttpPut]
        public async Task<ActionResult<NivelPermisoResponseDto>> UpdateNivelPermiso
            (
                [FromBody] NivelPermisoResponseDto NivelPermiso
            )
        {

            var NivelPermisoModel = _mapper.Map<Wkf04NivelPermiso>(NivelPermiso);

            await _repository.UpdateNivelPermiso(NivelPermisoModel);
            await _repository.SaveChanges();

            var NivelPermisoResponse = _mapper.Map<NivelPermisoResponseDto>(NivelPermisoModel);

            var NivelPermisodto = await _repository.GetNivelPermisoById(NivelPermisoResponse.wkf04llave);

            if (NivelPermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la NivelPermiso por este id {NivelPermisoResponse.wkf04llave}" }
                    );
            }

            return Ok(_mapper.Map<NivelPermisoResponseDto>(NivelPermisodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNivelPermiso(int id)
        {

            var NivelPermisodto = await _repository.GetNivelPermisoById(id);

            if (NivelPermisodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la NivelPermiso por este id {id}" }
                );
            }
            else
            {
                if (NivelPermisodto.wkf04activo == 0)
                {
                    await _repository.DeleteNivelPermiso(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableNivelPermiso(id);
                    await _repository.SaveChanges();
                }
            }


            var listNivelPermisos = await _repository.GetAllNivelPermisos();
            return Ok(_mapper.Map<NivelPermisoResponseDto[]>(listNivelPermisos));

        }

        [HttpPost("~/api/NivelPermiso/disableNivelPermiso")]
        public async Task<ActionResult<NivelPermisoResponseDto[]>> DisableNivelPermiso
            (
                 [FromBody] NivelPermisoResponseDto[] NivelPermisos
            )
        {

            foreach (NivelPermisoResponseDto item in NivelPermisos)
            {
                var a = _mapper.Map<NivelPermisoResponseDto>(item);

                await _repository.DisableNivelPermiso(a.wkf04llave);
                await _repository.SaveChanges();
            }


            var listNivelPermisos = await _repository.GetAllNivelPermisos();
            return Ok(_mapper.Map<NivelPermisoResponseDto[]>(listNivelPermisos));

        }


        [HttpPost("~/api/NivelPermiso/ActivateNivelPermiso")]
        public async Task<ActionResult<NivelPermisoResponseDto[]>> ActivateNivelPermiso
            (
                 [FromBody] NivelPermisoResponseDto[] NivelPermisos
            )
        {

            foreach (NivelPermisoResponseDto item in NivelPermisos)
            {
                var a = _mapper.Map<NivelPermisoResponseDto>(item);

                await _repository.ActivateNivelPermiso(a.wkf04llave);
                await _repository.SaveChanges();
            }


            var listNivelPermisos = await _repository.GetAllNivelPermisos();
            return Ok(_mapper.Map<NivelPermisoResponseDto[]>(listNivelPermisos));

        }

    }
}
