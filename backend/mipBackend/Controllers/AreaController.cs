using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Areas;
using mipBackend.Dtos.AreaDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public AreaController
            (
                IAreaRepository repository,
                IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaResponseDto>>> GetArea()
        {

            var Areas = await _repository.GetAllAreas();
            return Ok(_mapper.Map<IEnumerable<AreaResponseDto>>(Areas));

        }

        [HttpGet("~/api/Area/GetAreaById/{id}")]
        [ActionName(nameof(GetAreaById))]
        public async Task<ActionResult<AreaResponseDto>> GetAreaById(int id)
        {

            var area = await _repository.GetAreaById(id);

            if (area == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la area por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<AreaResponseDto>(area));

        }

        [HttpPost]
        public async Task<ActionResult<AreaResponseDto>> CreateArea
            (
               [FromBody] AreaRequestDto area
            )
        {

            var areaModel = _mapper.Map<Wkf08Area>(area);

            await _repository.CreateArea(areaModel);
            await _repository.SaveChanges();

            var areaResponse = _mapper.Map<AreaResponseDto>(areaModel);

            var areadto = await _repository.GetAreaById(areaResponse.wfk08llave);

            if (areadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la area por este id {areaResponse.wfk08llave}" }
                    );
            }

            return Ok(_mapper.Map<AreaResponseDto>(areadto));



        }

        [HttpPut]
        public async Task<ActionResult<AreaResponseDto>> UpdateArea
            (
                [FromBody] AreaResponseDto area
            )
        {

            var areaModel = _mapper.Map<Wkf08Area>(area);

            await _repository.UpdateArea(areaModel);
            await _repository.SaveChanges();

            var areaResponse = _mapper.Map<AreaResponseDto>(areaModel);

            var areadto = await _repository.GetAreaById(areaResponse.wfk08llave);

            if (areadto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la area por este id {areaResponse.wfk08llave}" }
                    );
            }

            return Ok(_mapper.Map<AreaResponseDto>(areadto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArea(int id)
        {

            var areadto = await _repository.GetAreaById(id);

            if (areadto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la area por este id {id}" }
                );
            }
            else
            {
                if (areadto.wfk08activo == false)
                {
                    await _repository.DeleteArea(id);
                    await _repository.SaveChanges();
                }
                else
                {
                    await _repository.DisableArea(id);
                    await _repository.SaveChanges();
                }
            }


            var listAreas = await _repository.GetAllAreas();
            return Ok(_mapper.Map<AreaResponseDto[]>(listAreas));

        }

        [HttpPost("~/api/area/disablearea")]
        public async Task<ActionResult<AreaResponseDto[]>> DisableArea
            (
                 [FromBody] AreaResponseDto[] areas
            )
        {

            foreach (AreaResponseDto item in areas)
            {
                var a = _mapper.Map<AreaResponseDto>(item);

                await _repository.DisableArea(a.wfk08llave);
                await _repository.SaveChanges();
            }


            var listareas = await _repository.GetAllAreas();
            return Ok(_mapper.Map<AreaResponseDto[]>(listareas));

        }


        [HttpPost("~/api/Area/ActivateArea")]
        public async Task<ActionResult<AreaResponseDto[]>> ActivateArea
            (
                 [FromBody] AreaResponseDto[] areas
            )
        {

            foreach (AreaResponseDto item in areas)
            {
                var a = _mapper.Map<AreaResponseDto>(item);

                await _repository.ActivateArea(a.wfk08llave);
                await _repository.SaveChanges();
            }


            var listareas = await _repository.GetAllAreas();
            return Ok(_mapper.Map<AreaResponseDto[]>(listareas));

        }
    }
}
