using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Models;

namespace mipBackend.Data.UserAuths
{
    public interface IUserAuthsRepository
    {

        Task<UsuarioLoginResponseDto> GetUsuario();

        Task<UsuarioLoginResponseDto> Login(UsuarioLoginRequestDto request);

        Task<UserAuthReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request);

        Task<UsuarioLoginResponseDto> GetAllUsuariosById(Usuario usuario);

        Task ForgotPassword(ForgotPasswordResponseDto request);

        Task ResetPassword(ResetPasswordResponseDto request);

        Task EmailConfirmation(string email, string token);

    }
}
