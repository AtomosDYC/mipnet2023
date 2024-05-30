using mipBackend.Models;
using mipBackend.Dtos.ClienteEstacionDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;


namespace mipBackend.Data.ClienteEstaciones
{
    public interface IClienteEstacionContactoRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllClienteEstacionContactoDatasource(DataSourceRequest requestModel);

        Task<ClienteEstacionContactoResponseDto> GetAllClienteEstacionContactoById(ClienteEstacionContactoRequestDto request);

        Task<ClienteEstacionContactoResponseDto> CreateClienteEstacionContacto(ClienteEstacionContactoRequestDto request);

        Task DeleteClienteEstacionContacto(ClienteEstacionContactoRequestDto request);


    }
}
