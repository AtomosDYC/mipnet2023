using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Movils;
using mipBackend.Dtos.MovilDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovilPeriodoController : ControllerBase
    {

        private readonly IMovilPeriodoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MovilPeriodoController
            (


                IMovilPeriodoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("~/api/movilperiodo/getmovilperiodo")]
        [ActionName(nameof(getmovilperiodo))]
        public async Task<ActionResult<DataSourceResult>> getmovilperiodo(MovilPeriodoRequestDto request)
        {


            var periodos = await _repository.GetPeriodosMovil(request);

            return Ok(periodos);

        }

    }
}
