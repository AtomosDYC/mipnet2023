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
    public class ClienteEstacionController : ControllerBase
    {
        private readonly IClienteEstacionRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public ClienteEstacionController
            (

                IClienteEstacionRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("~/api/clienteestacion/getclienteestacionbyid/{identificador}")]
        [ActionName(nameof(getclienteestacionbyid))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> getclienteestacionbyid
            (
               string identificador
           )
        {

            var dataretorno = await _repository.GetClienteEstacionbyid(Convert.ToInt32(identificador));
            return Ok(dataretorno);

        }

        [HttpPost("~/api/clienteestacion/getclienteestacionactiva")]
        [ActionName(nameof(getclienteestacionactiva))]
        public async Task<ActionResult<DataSourceResult>> getclienteestacionactiva
            (
                [FromBody] DataSourceRequest requestModel
            )
        {

            DataSourceResult? dataretorno = await _repository.GetAllClienteEstacionActivaDatasource(requestModel);
            return Ok(dataretorno);

        }


        [HttpGet("~/api/clienteestacion/getclienteestacionbyrut/{rut}")]
        [ActionName(nameof(getclienteestacionbyrut))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> getclienteestacionbyrut
           (
               string rut
           )
        {
            
            var dataretorno = await _repository.GetClienteEstacionbyrut(Convert.ToInt32(rut));
            return Ok(dataretorno);

        }

        

        


        [HttpPost("~/api/clienteestacion/createclienteestacion")]
        [ActionName(nameof(createclienteestacion))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> createclienteestacion
            (
                [FromBody] ClienteEstacionRequestDto request
           )
        {

            var dataretorno = await _repository.CreateClienteEstacion(request);

            return Ok(dataretorno);

        }

        [HttpPut("~/api/clienteestacion/updateclienteestacion")]
        [ActionName(nameof(updateclienteestacion))]
        public async Task<ActionResult<ClienteEstacionResponseDto>> updateclienteestacion
           (
               [FromBody] ClienteEstacionRequestDto request
           )
        {

            var dataretorno = await _repository.updateclienteestacion(request);
            await _repository.SaveChanges();

            return Ok(dataretorno);

        }


        [HttpDelete("~/api/clienteestacion/deleteclienteestacion/{id}")]
        [ActionName(nameof(deleteclienteestacion))]
        public async Task<ActionResult> deleteclienteestacion(int id)
        {
            
            await _repository.deleteclienteestacion(id);
            await _repository.SaveChanges();
            
            return Ok();

        }

        [HttpPost("~/api/clienteestacion/disableclienteestacion")]
        [ActionName(nameof(disableclienteestacion))]
        public async Task<ActionResult> disableclienteestacion
            (
                 [FromBody] ClienteEstacionRequestDto[] Monitores
            )
        {

            
            foreach (ClienteEstacionRequestDto item in Monitores)
            {


                await _repository.disableclienteestacion(item.cnt01llave!);
                await _repository.SaveChanges();
            }
            
            return Ok();

        }

         
        [HttpPost("~/api/clienteestacion/activateclienteestacion")]
        [ActionName(nameof(activateclienteestacion))]
        public async Task<ActionResult> activateclienteestacion
            (
                 [FromBody] ClienteEstacionRequestDto[] Monitores
            )
        {

            
            foreach (ClienteEstacionRequestDto item in Monitores)
            {

                await _repository.activateclienteestacion(item.cnt01llave);
                await _repository.SaveChanges();
            }
            

            return Ok();

        }

    }
}
