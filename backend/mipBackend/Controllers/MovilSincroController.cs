using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Movils;
using mipBackend.Dtos.MovilSincroDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using KendoNET.DynamicLinq;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovilSincroController : Controller
    {
        private readonly IMovilTablaSincroRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MovilSincroController
            (


                IMovilTablaSincroRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost("~/api/movilsincro/gettablabasesincro")]
        [ActionName(nameof(gettablabasesincro))]
        public async Task<ActionResult<DataSourceResult>> gettablabasesincro()
        {


            DataSourceResult retorno = await _repository.GetTablaBaseSincro();

            return Ok(retorno);

        }


        [HttpPost("~/api/movilsincro/gettablasincro")]
        [ActionName(nameof(gettablasincro))]
        public async Task<ActionResult<DataSourceResult>> gettablasincro(MovilSincroRequestDto request)
        {


            DataSourceResult retorno = await _repository.GetTablaSincro(request);

            return Ok(retorno);

        }


        [HttpPost("~/api/movilsincro/updatetablasincro")]
        [ActionName(nameof(updatetablasincro))]
        public async Task<ActionResult<int>> updatetablasincro(MovilUpdateTablaSincroRequestDto request)
        {

            int retorno = await _repository.UpdateTablaSincro(request);

            return Ok(retorno);

        }

        [HttpPost("~/api/movilsincro/get_server_date")]
        [ActionName(nameof(get_server_date))]
        public async Task<ActionResult<DateTime>> get_server_date()
        {

            DateTime retorno = await _repository.GetDatetimeServer();

            return Ok(retorno);

        }


    }
}
