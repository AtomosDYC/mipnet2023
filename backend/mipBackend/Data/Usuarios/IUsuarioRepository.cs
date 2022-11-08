using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Data.Usuarios
{
    public interface IUsuarioRepository
    {

        Task<UsuarioReponseDto> GetUsuario();

        Task<UsuarioReponseDto> Login(UsuarioLoginRequestDto request);
        
        Task<UsuarioReponseDto> RegistroUsuario(UsuarioRegistroRequestDto request);
        

    }
}
