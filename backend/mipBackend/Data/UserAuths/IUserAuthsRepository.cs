using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Data.UserAuths
{
    public interface IUserAuthsRepository
    {
        Task<UserAuthReponseDto> GetUsuario();

        Task<UserAuthReponseDto> Login(UsuarioLoginRequestDto request);

        Task<UserAuthReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request);

    }
}
