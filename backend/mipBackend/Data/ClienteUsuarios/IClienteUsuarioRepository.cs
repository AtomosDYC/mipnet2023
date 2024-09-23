using mipBackend.Models;
using mipBackend.Dtos.ClienteUsuarioDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.ClienteUsuarios
{
    public interface IClienteUsuarioRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllClienteUsuarioActivaDatasource(DataSourceRequest requestModel);

        Task<DataSourceResult> GetAllClienteUsuarioInactivoDatasource(DataSourceRequest requestModel);

        Task<IEnumerable<MenuClienteusuarioDto>> getMenuCienteUsuario(string id);

        Task<ClienteUsuarioResponseDto> GetClienteUsuario(ClienteUsuarioRequestDto requestModel);

        Task<ClienteUsuarioResponseDto> GetClienteUsuariobyrut(int rut);

        Task<ClienteUsuarioResponseDto> GetClienteUsuariobyid(int id);

        Task<ClienteUsuarioResponseDto> CreateClienteUsuario(ClienteUsuarioRequestDto request);

        Task<ClienteUsuarioResponseDto> updateclienteUsuario(ClienteUsuarioRequestDto monitor);

        Task deleteclienteUsuario(int id);

        Task disableclienteUsuario(int? id);

        Task activateclienteUsuario(int? id);

    }
}
