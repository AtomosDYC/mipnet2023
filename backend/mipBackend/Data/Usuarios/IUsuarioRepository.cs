using mipBackend.Dtos.UsuarioDtos;
using mipBackend.Models;

namespace mipBackend.Data.Usuarios
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<UsuarioRegistroResponseDto>> GetAllUsuarios();

        Task<UsuarioRegistroResponseDto> GetAllUsuariosById(string id);

        Task<IEnumerable<UsuarioRegistroResponseDto>> RegistroUsuario(UsuarioRegistroRequestDto request);

        Task UpdateUsuario(UsuarioRegistroResponseDto request);

        Task SendMailConfirmation(Usuario usuario);

    }
}