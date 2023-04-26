using mipBackend.Dtos.UsuarioDtos;

namespace mipBackend.Data.Usuarios
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<UsuarioResponseDto>> GetAllUsuarios();

        Task<IEnumerable<UsuarioRegistroResponseDto>> RegistroUsuario(UsuarioRegistroRequestDto request);

    }
}