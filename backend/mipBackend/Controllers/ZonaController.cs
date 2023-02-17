using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Zonas;
using mipBackend.Dtos.ZonaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ZonaController
            (
                AppDbContext context,
                IZonaRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZonaResponseDto>>> GetZona()
        {

            var Zonas = await _repository.GetAllZonas();
            return Ok(Zonas);

        }

        [HttpGet("~/api/zona/GetZonaById/{id}")]
        [ActionName(nameof(GetZonaById))]
        public async Task<ActionResult<ZonaResponseDto>> GetZonaById(int id)
        {


            var Zona = await _repository.GetZonaById(id);

            if (Zona == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Zona por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<ZonaResponseDto>(Zona));

        }

        [HttpPost]
        public async Task<ActionResult<ZonaResponseDto>> CreateZona
            (
               [FromBody] ZonaRequestDto Zona
            )
        {

            var ZonaModel = _mapper.Map<Sist02Zona>(Zona);

            await _repository.CreateZona(ZonaModel);
            await _repository.SaveChanges();

            var ZonaResponse = _mapper.Map<ZonaResponseDto>(ZonaModel);

            var Zonadto = await _repository.GetZonaById(ZonaResponse.sist02llave);

            if (Zonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {ZonaResponse.sist02llave}" }
                    );
            }

            return Ok(_mapper.Map<ZonaResponseDto>(Zonadto));



        }

        [HttpPut]
        public async Task<ActionResult<ZonaResponseDto>> UpdateZona
            (
                [FromBody] ZonaResponseDto Zona
            )
        {

            var ZonaModel = _mapper.Map<Sist02Zona>(Zona);

            await _repository.UpdateZona(ZonaModel);
            await _repository.SaveChanges();

            var ZonaResponse = _mapper.Map<ZonaResponseDto>(ZonaModel);

            var Zonadto = await _repository.GetZonaById(ZonaResponse.sist02llave);

            if (Zonadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la Comuna por este id {ZonaResponse.sist02llave}" }
                    );
            }

            return Ok(_mapper.Map<ZonaResponseDto>(Zonadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteZona(int id)
        {

            var Zonadto = await _repository.GetZonaById(id);

            if (Zonadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la Zona por este id {id}" }
                );
            }
            else
            {
                if (Zonadto.sist02activo == 0)
                {
                    await _repository.DeleteZona(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableZona(id);
                    await _repository.SaveChanges();
                }
            }


            var listZonas = await _repository.GetAllZonas();
            return Ok(_mapper.Map<ZonaResponseDto[]>(listZonas));

        }

        [HttpPost("~/api/Comuna/disableZona")]
        public async Task<ActionResult<ZonaResponseDto[]>> DisableZona
            (
                 [FromBody] ZonaResponseDto[] Zonas
            )
        {

            foreach (ZonaResponseDto item in Zonas)
            {
                var a = _mapper.Map<ZonaResponseDto>(item);

                await _repository.DisableZona(a.sist02llave);
                await _repository.SaveChanges();
            }


            var listZonas = await _repository.GetAllZonas();
            return Ok(_mapper.Map<ZonaResponseDto[]>(listZonas));

        }


        [HttpPost("~/api/Comuna/ActivateZona")]
        public async Task<ActionResult<ZonaResponseDto[]>> ActivateZona
            (
                 [FromBody] ZonaResponseDto[] Zonas
            )
        {

            foreach (ZonaResponseDto item in Zonas)
            {
                var a = _mapper.Map<ZonaResponseDto>(item);

                await _repository.ActivateZona(a.sist02llave);
                await _repository.SaveChanges();
            }


            var listZonas = await _repository.GetAllZonas();
            return Ok(_mapper.Map<ZonaResponseDto[]>(listZonas));

        }

    }
}
