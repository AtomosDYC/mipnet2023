using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Usuarios;
using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {

            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetUsuario()
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
    }
}
