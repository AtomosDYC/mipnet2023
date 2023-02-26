using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.TipoPermisos;
using mipBackend.Dtos.TipoPermisoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : ControllerBase
    {
        private readonly ITipoPermisosRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipoPermisoController
            (

                ITipoPermisosRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermisoResponseDto>>> GetTipoPermiso()
        {

            var TipoPermisos = await _repository.GetAllTipoPermisos();
            return Ok(_mapper.Map<IEnumerable<TipoPermisoResponseDto>>(TipoPermisos));

        }

        [HttpGet("~/api/TipoPermiso/GetTipoPermisoById/{id}")]
        [ActionName(nameof(GetTipoPermisoById))]
        public async Task<ActionResult<TipoPermisoResponseDto>> GetTipoPermisoById(int id)
        {


            var tipopermiso = await _repository.GetTipoPermisoById(id);

            if (tipopermiso == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipoPermisoResponseDto>(tipopermiso));

        }

        [HttpPost]
        public async Task<ActionResult<TipoPermisoResponseDto>> CreateTipoPermiso
            (
               [FromBody] TipoPermisoRequestDto tipopermiso
            )
        {

            var tipopermisoModel = _mapper.Map<Wkf05TipoPermiso>(tipopermiso);

            await _repository.CreateTipoPermiso(tipopermisoModel);
            await _repository.SaveChanges();

            var tipopermisoResponse = _mapper.Map<TipoPermisoResponseDto>(tipopermisoModel);

            var tipopermisodto = await _repository.GetTipoPermisoById(tipopermisoResponse.wkf05llave);

            if (tipopermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {tipopermisoResponse.wkf05llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoPermisoResponseDto>(tipopermisodto));



        }

        [HttpPut]
        public async Task<ActionResult<TipoPermisoResponseDto>> UpdateTipoPermiso
            (
                [FromBody] TipoPermisoResponseDto tipopermiso
            )
        {

            var tipopermisoModel = _mapper.Map<Wkf05TipoPermiso>(tipopermiso);

            await _repository.UpdateTipoPermiso(tipopermisoModel);
            await _repository.SaveChanges();

            var tipopermisoResponse = _mapper.Map<TipoPermisoResponseDto>(tipopermisoModel);

            var tipopermisodto = await _repository.GetTipoPermisoById(tipopermisoResponse.wkf05llave);

            if (tipopermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {tipopermisoResponse.wkf05llave}" }
                    );
            }

            return Ok(_mapper.Map<TipoPermisoResponseDto>(tipopermisodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoPermiso(int id)
        {

            var tipopermisodto = await _repository.GetTipoPermisoById(id);

            if (tipopermisodto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la tipopermiso por este id {id}" }
                );
            }
            else
            {
                if (tipopermisodto.wkf05activo == 0)
                {
                    await _repository.DeleteTipoPermiso(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipoPermiso(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipopermisos = await _repository.GetAllTipoPermisos();
            return Ok(_mapper.Map<TipoPermisoResponseDto[]>(listtipopermisos));

        }

        [HttpPost("~/api/tipopermiso/disabletipopermiso")]
        public async Task<ActionResult<TipoPermisoResponseDto[]>> DisableTipoPermiso
            (
                 [FromBody] TipoPermisoResponseDto[] tipopermisos
            )
        {

            foreach (TipoPermisoResponseDto item in tipopermisos)
            {
                var a = _mapper.Map<TipoPermisoResponseDto>(item);

                await _repository.DisableTipoPermiso(a.wkf05llave);
                await _repository.SaveChanges();
            }


            var listtipopermisos = await _repository.GetAllTipoPermisos();
            return Ok(_mapper.Map<TipoPermisoResponseDto[]>(listtipopermisos));

        }


        [HttpPost("~/api/TipoPermiso/ActivateTipoPermiso")]
        public async Task<ActionResult<TipoPermisoResponseDto[]>> ActivateTipoPermiso
            (
                 [FromBody] TipoPermisoResponseDto[] tipopermisos
            )
        {

            foreach (TipoPermisoResponseDto item in tipopermisos)
            {
                var a = _mapper.Map<TipoPermisoResponseDto>(item);

                await _repository.ActivateTipoPermiso(a.wkf05llave);
                await _repository.SaveChanges();
            }


            var listtipopermisos = await _repository.GetAllTipoPermisos();
            return Ok(_mapper.Map<TipoPermisoResponseDto[]>(listtipopermisos));

        }

    }
}