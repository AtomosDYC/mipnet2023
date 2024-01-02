using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Tipopermisos;
using mipBackend.Dtos.TipopermisoDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipopermisoController : ControllerBase
    {
        private readonly ITipopermisosRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public TipopermisoController
            (

                ITipopermisosRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipopermisoResponseDto>>> GetTipopermiso()
        {

            var Tipopermisos = await _repository.GetAllTipopermisos();
            return Ok(_mapper.Map<IEnumerable<TipopermisoResponseDto>>(Tipopermisos));

        }

        [HttpGet("~/api/Tipopermiso/GetTipopermisoById/{id}")]
        [ActionName(nameof(GetTipopermisoById))]
        public async Task<ActionResult<TipopermisoResponseDto>> GetTipopermisoById(int id)
        {


            var tipopermiso = await _repository.GetTipopermisoById(id);

            if (tipopermiso == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<TipopermisoResponseDto>(tipopermiso));

        }

        [HttpPost]
        public async Task<ActionResult<TipopermisoResponseDto>> CreateTipopermiso
            (
               [FromBody] TipopermisoRequestDto tipopermiso
            )
        {

            var tipopermisoModel = _mapper.Map<wkf05Tipopermiso>(tipopermiso);

            await _repository.CreateTipopermiso(tipopermisoModel);
            await _repository.SaveChanges();

            var tipopermisoResponse = _mapper.Map<TipopermisoResponseDto>(tipopermisoModel);

            var tipopermisodto = await _repository.GetTipopermisoById(tipopermisoResponse.wkf05llave);

            if (tipopermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {tipopermisoResponse.wkf05llave}" }
                    );
            }

            return Ok(_mapper.Map<TipopermisoResponseDto>(tipopermisodto));



        }

        [HttpPut]
        public async Task<ActionResult<TipopermisoResponseDto>> UpdateTipopermiso
            (
                [FromBody] TipopermisoResponseDto tipopermiso
            )
        {

            var tipopermisoModel = _mapper.Map<wkf05Tipopermiso>(tipopermiso);

            await _repository.UpdateTipopermiso(tipopermisoModel);
            await _repository.SaveChanges();

            var tipopermisoResponse = _mapper.Map<TipopermisoResponseDto>(tipopermisoModel);

            var tipopermisodto = await _repository.GetTipopermisoById(tipopermisoResponse.wkf05llave);

            if (tipopermisodto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la tipopermiso por este id {tipopermisoResponse.wkf05llave}" }
                    );
            }

            return Ok(_mapper.Map<TipopermisoResponseDto>(tipopermisodto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipopermiso(int id)
        {

            var tipopermisodto = await _repository.GetTipopermisoById(id);

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
                    await _repository.DeleteTipopermiso(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableTipopermiso(id);
                    await _repository.SaveChanges();
                }
            }


            var listtipopermisos = await _repository.GetAllTipopermisos();
            return Ok(_mapper.Map<TipopermisoResponseDto[]>(listtipopermisos));

        }

        [HttpPost("~/api/tipopermiso/disabletipopermiso")]
        public async Task<ActionResult<TipopermisoResponseDto[]>> DisableTipopermiso
            (
                 [FromBody] TipopermisoResponseDto[] tipopermisos
            )
        {

            foreach (TipopermisoResponseDto item in tipopermisos)
            {
                var a = _mapper.Map<TipopermisoResponseDto>(item);

                await _repository.DisableTipopermiso(a.wkf05llave);
                await _repository.SaveChanges();
            }


            var listtipopermisos = await _repository.GetAllTipopermisos();
            return Ok(_mapper.Map<TipopermisoResponseDto[]>(listtipopermisos));

        }


        [HttpPost("~/api/Tipopermiso/ActivateTipopermiso")]
        public async Task<ActionResult<TipopermisoResponseDto[]>> ActivateTipopermiso
            (
                 [FromBody] TipopermisoResponseDto[] tipopermisos
            )
        {

            foreach (TipopermisoResponseDto item in tipopermisos)
            {
                var a = _mapper.Map<TipopermisoResponseDto>(item);

                await _repository.ActivateTipopermiso(a.wkf05llave);
                await _repository.SaveChanges();
            }


            var listtipopermisos = await _repository.GetAllTipopermisos();
            return Ok(_mapper.Map<TipopermisoResponseDto[]>(listtipopermisos));

        }

    }
}