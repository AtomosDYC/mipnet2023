using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.UserAuths;
using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthsRepository _repository;

        public UserAuthController(IUserAuthsRepository repository)
        {

            _repository = repository;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResponseDto>> Login
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
        public async Task<ActionResult<UsuarioLoginResponseDto>> DevolverUsuario()
        {

            return await _repository.GetUsuario();

        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword
            (
            [FromBody] ResetPasswordResponseDto ResetPasswordDto
            )
        {

            await _repository.ResetPassword(ResetPasswordDto);

            return Ok();

        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword
            (
            [FromBody] ForgotPasswordResponseDto forgotPasswordDto
            )
        {
            
            await _repository.ForgotPassword(forgotPasswordDto);

            return Ok();

        }

        [AllowAnonymous]
        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation
            (
                [FromQuery] string email, 
                [FromQuery] string token
            )
        {

            await _repository.EmailConfirmation(email, token);

            return Ok();
        }

    }
}
