using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.ClienteEstaciones;
using mipBackend.Dtos.ClienteEstacionDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteEstacionComunicacionController : ControllerBase
    {

        private readonly IClienteEstacionComunicacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ClienteEstacionComunicacionController
            (

                IClienteEstacionComunicacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/clienteestacioncomunicacion/getclienteestacioncomunicacion")]
        [ActionName(nameof(getclienteestacioncomunicacion))]
        public async Task<ActionResult<DataSourceResult>> getclienteestacioncomunicacion
                    (
                        [FromBody] DataSourceRequest requestModel
                    )
        {

            DataSourceResult? dataretorno = await _repository.GetAllClienteEstacionComunicacionDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/clienteestacioncomunicacion/getclienteestacioncomunicacionbyid")]
        [ActionName(nameof(getclienteestacioncomunicacionbyid))]
        public async Task<ActionResult<ClienteEstacionComunicacionResponseDto>> getclienteestacioncomunicacionbyid(
            [FromBody] ClienteEstacionComunicacionRequestDto request)
        {

            var clienteestacion = await _repository.GetAllClienteEstacionComunicacionById(request);

            if (clienteestacion == null) 
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el los datos de comunicacion del monitor" }
                    );
            }

            return Ok(clienteestacion);

        }


        [HttpPost("~/api/clienteestacioncomunicacion/createclienteestacioncomunicacion")]
        [ActionName(nameof(createclienteestacioncomunicacion))]
        public async Task<ActionResult<bool>> createclienteestacioncomunicacion
                    (
                        [FromBody] ClienteEstacionComunicacionRequestDto requestModel
                    )
        {

            await _repository.CreateClienteEstacionComunicacion(requestModel);
            bool dataretorno = await _repository.SaveChanges();
            return Ok(dataretorno);

        }

        [HttpPost("~/api/clienteestacioncomunicacion/deleteclienteestacioncomunicacion")]
        [ActionName(nameof(deleteclienteestacioncomunicacion))]
        public async Task<ActionResult<bool>> deleteclienteestacioncomunicacion
            (
            [FromBody] ClienteEstacionComunicacionRequestDto request
            )
        {

            await _repository.DeleteClienteEstacionComunicacion(request);
            bool dataretorno = await _repository.SaveChanges();

            return Ok();

        }

    }
}
