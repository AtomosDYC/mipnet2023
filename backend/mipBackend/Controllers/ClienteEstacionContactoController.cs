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
    public class ClienteEstacionContactoController : ControllerBase
    {


        private readonly IClienteEstacionContactoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ClienteEstacionContactoController
            (

                IClienteEstacionContactoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/clienteestacioncontacto/getclienteestacioncontacto")]
        [ActionName(nameof(getclienteestacioncontacto))]
        public async Task<ActionResult<DataSourceResult>> getclienteestacioncontacto
                    (
                        [FromBody] DataSourceRequest requestModel
                    )
        {

            DataSourceResult? dataretorno = await _repository.GetAllClienteEstacionContactoDatasource(requestModel);
            return Ok(dataretorno);

        }


        [HttpPost("~/api/clienteestacioncontacto/getclienteestacioncontactobyid")]
        [ActionName(nameof(getclienteestacioncontactobyid))]
        public async Task<ActionResult<ClienteEstacionComunicacionResponseDto?>> getclienteestacioncontactobyid(
            [FromBody] ClienteEstacionContactoRequestDto requestModel)
        {

            var clienteestacion = await _repository.GetAllClienteEstacionContactoById(requestModel);

            if (clienteestacion == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro el los datos de contacto del cliente estacion" }
                    );
            }

            return Ok(clienteestacion);

        }

        [HttpPost("~/api/clienteestacioncontacto/createclienteestacioncontacto")]
        [ActionName(nameof(createclienteestacioncontacto ))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> createclienteestacioncontacto
            (
                [FromBody] ClienteEstacionContactoRequestDto request
           )
        {

            var dataretorno = await _repository.CreateClienteEstacionContacto(request);

            return Ok(dataretorno);

        }

        [HttpPost("~/api/clienteestacioncontacto/deleteclienteestacioncontacto")]
        [ActionName(nameof(deleteclienteestacioncontacto))]
        public async Task<ActionResult<bool>> deleteclienteestacioncontacto
            (
            [FromBody] ClienteEstacionContactoRequestDto request
            )
        {

            await _repository.DeleteClienteEstacionContacto(request);
            bool dataretorno = await _repository.SaveChanges();

            return Ok();

        }

    }
}
