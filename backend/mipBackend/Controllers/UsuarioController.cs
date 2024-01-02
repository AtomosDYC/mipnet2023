using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Dtos.UsuarioDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Usuarios;
using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Models;


namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioController(
            IUsuarioRepository repository,
             UserManager<Usuario> userManager)
        {

            _repository = repository;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRegistroResponseDto>>> GetUsuario()
        {



            var Usuarios = await _repository.GetAllUsuarios();
            return Ok(Usuarios);

        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<UsuarioRegistroResponseDto>>> Registrar
            (
                [FromBody] UsuarioRegistroRequestDto request
            )
        {

            var usuario = await _repository.RegistroUsuario(request);

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioRegistroResponseDto>> UpdateUsuario
            (
                [FromBody] UsuarioRegistroResponseDto request
            )
        {

            await _repository.UpdateUsuario(request);

            var Usuarios = await _repository.GetAllUsuarios();
            return Ok(Usuarios);

            

        }

        [HttpGet("~/api/usuario/SendMailConfirmation/{id}")]
        [ActionName(nameof(SendMailConfirmation))]

        public async Task<ActionResult<UsuarioRegistroResponseDto>> SendMailConfirmation
            (
               string id
            )
        {

            var usuario = await _userManager.FindByIdAsync(id);

            var sendmail = _repository.SendMailConfirmation(usuario);

            return Ok(usuario);
        }

        [HttpGet("~/api/usuario/GetAllUsuariosById/{id}")]
        [ActionName(nameof(GetAllUsuariosById))]
        public async Task<ActionResult<UsuarioRegistroResponseDto>> GetAllUsuariosById(string id)
        {

            var Usuarios = await _repository.GetAllUsuariosById(id);
            return Ok(Usuarios);

        }
        
    }
}