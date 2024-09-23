using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.ClienteUsuarios;
using mipBackend.Dtos.ClienteUsuarioDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteUsuarioController : ControllerBase
    {

        private readonly IClienteUsuarioRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ClienteUsuarioController
            (

                IClienteUsuarioRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost("~/api/clienteusuario/getclienteusuarioactiva")]
        [ActionName(nameof(getclienteusuarioactiva))]
        public async Task<ActionResult<DataSourceResult>> getclienteusuarioactiva
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            DataSourceResult? dataretorno = await _repository.GetAllClienteUsuarioActivaDatasource(requestModel);
            return Ok(dataretorno);

        }

        [HttpPost("~/api/clienteusuario/getclienteusuarioinactivo")]
        [ActionName(nameof(getclienteusuarioinactivo))]
        public async Task<ActionResult<DataSourceResult>> getclienteusuarioinactivo
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            DataSourceResult? dataretorno = await _repository.GetAllClienteUsuarioInactivoDatasource(requestModel);
            return Ok(dataretorno);

        }


        [HttpGet("~/api/clienteusuario/getmenuclienteusuario/{id}")]
        [ActionName(nameof(getmenuclienteusuario))]
        public async Task<ActionResult<IEnumerable<MenuClienteusuarioDto>>> getmenuclienteusuario
            (
                string id, string encoid
            )
        {

            IEnumerable<MenuClienteusuarioDto>? dataretorno = await _repository.getMenuCienteUsuario(id);
            return Ok(dataretorno);

        }

        [HttpGet("~/api/ClienteUsuario/getClienteUsuariobyid/{identificador}")]
        [ActionName(nameof(getClienteUsuariobyid))]
        public async Task<ActionResult<ClienteUsuarioResponseDto>> getClienteUsuariobyid
            (
               string identificador
           )
        {

            var dataretorno = await _repository.GetClienteUsuariobyid(Convert.ToInt32(identificador));
            return Ok(dataretorno);

        }


        [HttpGet("~/api/ClienteUsuario/getClienteUsuariobyrut/{rut}")]
        [ActionName(nameof(getClienteUsuariobyrut))]
        public async Task<ActionResult<ClienteUsuarioResponseDto>> getClienteUsuariobyrut
           (
               string rut
           )
        {

            var dataretorno = await _repository.GetClienteUsuariobyrut(Convert.ToInt32(rut));
            return Ok(dataretorno);

        }


        [HttpPost("~/api/ClienteUsuario/createClienteUsuario")]
        [ActionName(nameof(createClienteUsuario))]
        public async Task<ActionResult<ClienteUsuarioResponseDto>> createClienteUsuario
            (
                [FromBody] ClienteUsuarioRequestDto request
           )
        {

            var dataretorno = await _repository.CreateClienteUsuario(request);

            return Ok(dataretorno);

        }

        [HttpPut("~/api/ClienteUsuario/updateClienteUsuario")]
        [ActionName(nameof(updateClienteUsuario))]
        public async Task<ActionResult<ClienteUsuarioResponseDto>> updateClienteUsuario
           (
               [FromBody] ClienteUsuarioRequestDto request
           )
        {

            var dataretorno = await _repository.updateclienteUsuario(request);
            await _repository.SaveChanges();

            return Ok(dataretorno);

        }


        [HttpDelete("~/api/ClienteUsuario/deleteClienteUsuario/{id}")]
        [ActionName(nameof(deleteClienteUsuario))]
        public async Task<ActionResult> deleteClienteUsuario(int id)
        {

            await _repository.deleteclienteUsuario(id);
            await _repository.SaveChanges();

            return Ok();

        }

        [HttpPost("~/api/ClienteUsuario/disableClienteUsuario")]
        [ActionName(nameof(disableClienteUsuario))]
        public async Task<ActionResult> disableClienteUsuario
            (
                 [FromBody] ClienteUsuarioRequestDto[] Monitores
            )
        {


            foreach (ClienteUsuarioRequestDto item in Monitores)
            {


                await _repository.disableclienteUsuario(item.cnt01llave!);
                await _repository.SaveChanges();
            }

            return Ok();

        }


        [HttpPost("~/api/ClienteUsuario/activateClienteUsuario")]
        [ActionName(nameof(activateClienteUsuario))]
        public async Task<ActionResult> activateClienteUsuario
            (
                 [FromBody] ClienteUsuarioRequestDto[] Monitores
            )
        {


            foreach (ClienteUsuarioRequestDto item in Monitores)
            {

                await _repository.activateclienteUsuario(item.cnt01llave);
                await _repository.SaveChanges();
            }


            return Ok();

        }

    }
}
