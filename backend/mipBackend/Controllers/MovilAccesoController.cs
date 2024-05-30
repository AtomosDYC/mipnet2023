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
    public class MovilAccesoController : ControllerBase
    {
        private readonly IMovilAccesoRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MovilAccesoController
            (


                IMovilAccesoRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("~/api/movil/GetMonitorMovilAcceso")]
        [ActionName(nameof(GetMonitorMovilAcceso))]
        public async Task<ActionResult<IEnumerable<MovilAccesoResponseDto>>> GetMonitorMovilAcceso
           (
               [FromBody] MovilAccesoRequestDto request
           )
        {

            var dataretorno = await _repository.listMovilAcceso(request);
            return Ok(dataretorno);

        }


        [HttpPost("~/api/movil/CreateMonitorMovilAcceso")]
        [ActionName(nameof(CreateMonitorMovilAcceso))]
        public async Task<ActionResult> CreateMonitorMovilAcceso
            (
               [FromBody] MovilAccesoCreateRequestDto request
            )
        {

            await _repository.CreateMonitorMovilAcceso(request);
            await _repository.SaveChanges();

            await _repository.RegistrarAccesoMovil(request);
            await _repository.SaveChanges();

            return Ok();

        }


        [HttpDelete("~/api/movil/DesactivarMonitorMovilAcceso")]
        [ActionName(nameof(DesactivarMonitorMovilAcceso))]
        public async Task<ActionResult> DesactivarMonitorMovilAcceso(
            [FromBody] MovilAccesoDesactivateRequestDto request
            )
        {

            await _repository.DesactivarMonitorMovilAcceso(request);
            await _repository.SaveChanges();

            return Ok();

        }

        [HttpPost("~/api/movil/existemovilacceso")]
        [ActionName(nameof(existemovilacceso))]
        public async Task<ActionResult<bool>> existemovilacceso(
            [FromBody] MovilAccesoExisteRequestDto request
            )
        {

            var obx_Dato = await _repository.Existe_movil_acceso(request);
            
            return Ok(obx_Dato);

        }

        [HttpPost("~/api/movil/registrarmovilacceso")]
        [ActionName(nameof(registrarmovilacceso))]
        public async Task<ActionResult<bool>> registrarmovilacceso(
            [FromBody] MovilAccesoRegistrarRequestDto request
            )
        {

            await _repository.Agregar_movil_acceso(request);
            bool obx_Data = await _repository.SaveChanges();

            return Ok(obx_Data);

        }

        [HttpPost("~/api/movil/registraractividadmovil")]
        [ActionName(nameof(registraractividadmovil))]
        public async Task<ActionResult<bool>> registraractividadmovil(
            [FromBody] MovilAccesoActividadRequestDto request
            )
        {

            await _repository.Registrar_actividad_movil(request);
            bool obx_Data = await _repository.SaveChanges();

            return Ok(obx_Data);

        }

        [HttpPost("~/api/movil/registrarsincromovil")]
        [ActionName(nameof(registrarsincromovil))]
        public async Task<ActionResult<bool>> registrarsincromovil(
            [FromBody] MovilAccesoSincroResponseDto request
            )
        {

            await _repository.registrar_sincro_movil(request);
            bool obx_Data = await _repository.SaveChanges();

            return Ok(obx_Data);

        }

        [HttpPost("~/api/movil/estadobloqueadomovil")]
        [ActionName(nameof(estadobloqueadomovil))]
        public async Task<ActionResult<bool>> estadobloqueadomovil(
            [FromBody] MovilAccesoExisteRequestDto request
            )
        {

            var obx_Dato = await _repository.estado_bloqueado_movil(request);

            return Ok(obx_Dato);

        }

        [HttpPost("~/api/movil/editafechamonitoreomovil")]
        [ActionName(nameof(editafechamonitoreomovil))]
        public async Task<ActionResult<MovilAccesoEditarFechaResponseDto>> editafechamonitoreomovil(
            [FromBody] MovilAccesoExisteRequestDto request
            )
        {

            MovilAccesoEditarFechaResponseDto obx_Data =  await _repository.edita_fecha_monitoreo_movil(request);

            return Ok(obx_Data);

        }


        [HttpPost("~/api/movil/versiondescargamovil")]
        [ActionName(nameof(versiondescargamovil))]
        public async Task<ActionResult<MovilAccesoVersionResponseDto>> versiondescargamovil(
            [FromBody] MovilAccesoExisteRequestDto request
            )
        {

            MovilAccesoVersionResponseDto obx_Data = await _repository.version_descarga_movil(request);

            return Ok(obx_Data);

        }



    }
}
