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

    }
}
