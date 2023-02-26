using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Usuarios;
using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UserAuthController(IUsuarioRepository repository)
        {

            _repository = repository;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserAuthReponseDto>> Login
            (
            [FromBody] UsuarioLoginRequestDto request
            )
        {

            return await _repository.Login(request);

        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult<UserAuthReponseDto>> Registrar
            (
            [FromBody] UsuarioRegistroRequestDto request
            )
        {

            return await _repository.RegistroUsuario(request);

        }

        [HttpGet]
        public async Task<ActionResult<UserAuthReponseDto>> DevolverUsuario()
        {

            return await _repository.GetUsuario();

        }
    }
}
