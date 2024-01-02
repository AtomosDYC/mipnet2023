using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Regiones;
using mipBackend.Dtos.RegionDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        private readonly IRegionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public RegionController
            (

                IRegionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionResponseDto>>> GetRegion()
        {

            var regiones = await _repository.GetAllRegiones();
            return Ok(_mapper.Map<IEnumerable<RegionResponseDto>>(regiones));

        }

        [HttpGet("~/api/Region/GetRegionById/{id}")]
        [ActionName(nameof(GetRegionById))]
        public async Task<ActionResult<RegionResponseDto>> GetRegionById(int id)
        {

            
            var region = await _repository.GetRegionById(id);

            if (region == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la region por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<RegionResponseDto>(region));

        }

        [HttpPost]
        public async Task<ActionResult<RegionResponseDto>> CreateRegion
            (
               [FromBody] RegionRequestDto region
            )
        {

            var regionModel = _mapper.Map<sist04Region>(region);

            await _repository.CreateRegion(regionModel);
            await _repository.SaveChanges();

            var regionResponse = _mapper.Map<RegionResponseDto>(regionModel);

            var regiondto = await _repository.GetRegionById(regionResponse.sist04llave);

            if (regiondto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la region por este id {regionResponse.sist04llave}" }
                    );
            }

            return Ok(_mapper.Map<RegionResponseDto>(regiondto));



        }

        [HttpPut]
        public async Task<ActionResult<RegionResponseDto>> UpdateRegion
            (
                [FromBody] RegionResponseDto region
            )
        {

            var regionModel = _mapper.Map<sist04Region>(region);

            await _repository.UpdateRegion(regionModel);
            await _repository.SaveChanges();

            var regionResponse = _mapper.Map<RegionResponseDto>(regionModel);

            var regiondto = await _repository.GetRegionById(regionResponse.sist04llave);

            if (regiondto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la region por este id {regionResponse.sist04llave}" }
                    );
            }

            return Ok(_mapper.Map<RegionResponseDto>(regiondto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegion(int id)
        {

            var regiondto = await _repository.GetRegionById(id);

            if (regiondto == null)
            {

                throw new MiddlewareException
                (
                    HttpStatusCode.NotFound,
                    new { mensaje = $"No se encontro la region por este id {id}" }
                );
            } 
            else 
            { 
                if (regiondto.sist04activo == 0)
                {
                    await _repository.DeleteRegion(id);
                    await _repository.SaveChanges();
                } 
                else
                {
                    await _repository.DisableRegion(id);
                    await _repository.SaveChanges();
                }
            }


            var listregiones = await _repository.GetAllRegiones();
            return Ok(_mapper.Map<RegionResponseDto[]>(listregiones));

        }

        [HttpPost("~/api/region/disableregion")]
        public async Task<ActionResult<RegionResponseDto[]>> DisableRegion
            (
                 [FromBody] RegionResponseDto[] regiones
            )
        {

            foreach (RegionResponseDto item in regiones)
            {
                var a = _mapper.Map<RegionResponseDto>(item);

                await _repository.DisableRegion(a.sist04llave);
                await _repository.SaveChanges();
            }


            var listregiones = await _repository.GetAllRegiones();
            return Ok(_mapper.Map<RegionResponseDto[]>(listregiones));
            
        }


        [HttpPost("~/api/Region/ActivateRegion")]
        public async Task<ActionResult<RegionResponseDto[]>> ActivateRegion
            (
                 [FromBody] RegionResponseDto[] regiones
            )
        {

            foreach (RegionResponseDto item in regiones)
            {
                var a = _mapper.Map<RegionResponseDto>(item);

                await _repository.ActivateRegion(a.sist04llave);
                await _repository.SaveChanges();
            }


            var listregiones = await _repository.GetAllRegiones();
            return Ok(_mapper.Map<RegionResponseDto[]>(listregiones));

        }
        
    }
}
