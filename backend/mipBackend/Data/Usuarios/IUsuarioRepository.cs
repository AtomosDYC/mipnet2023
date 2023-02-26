using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Data.Usuarios
{
    public interface IUsuarioRepository
    {

        Task<UserAuthReponseDto> GetUsuario();

        Task<UserAuthReponseDto> Login(UsuarioLoginRequestDto request);
        
        Task<UserAuthReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request);

        Task<IEnumerable<UsuarioResponseDto>> GetAllUsuarios();

    }
}
