using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Estaciones;
using mipBackend.Dtos.EstacionDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq; 

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionController : ControllerBase
    {
        private readonly IEstacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public EstacionController
            (

                IEstacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
        [HttpGet("~/api/clienteestacion/estacion/{identificador}")]
        [ActionName(nameof(getclienteestacionbyid))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> getclienteestacionbyid
            (
               string identificador
           )
        {

            var dataretorno = await _repository.GetClienteEstacionbyid(Convert.ToInt32(identificador));
            return Ok(dataretorno);

        }
        */

        [HttpPost("~/api/clienteestacion/getestaciones")]
        [ActionName(nameof(getestaciones))]
        public async Task<ActionResult<DataSourceResult>> getestaciones
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            DataSourceResult? dataretorno = await _repository.GetAllEstacionesDatasource(requestModel);
            return Ok(dataretorno);

        }


        [HttpGet("~/api/clienteestacion/getmenuestaciones/{id}/{encoid}")]
        [ActionName(nameof(getmenuestaciones))]
        public async Task<ActionResult<IEnumerable<MenuEstacionResponseDto>>> getmenuestaciones
            (
                string id, string encoid 
            )
        {



            IEnumerable<MenuEstacionResponseDto>? dataretorno = await _repository.getMenuEstacion(id, encoid);
            return Ok(dataretorno);

        }

    }
}
