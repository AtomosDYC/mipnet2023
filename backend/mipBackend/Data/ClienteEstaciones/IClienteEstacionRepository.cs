using mipBackend.Models;
using mipBackend.Dtos.ClienteEstacionDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.ClienteEstaciones
{
    public interface IClienteEstacionRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllClienteEstacionActivaDatasource(DataSourceRequest requestModel);

        Task<ClienteEstacionResponseDto> GetClienteEstacion(ClienteEstacionRequestDto requestModel);

        Task<ClienteEstacionResponseDto> GetClienteEstacionbyrut(int rut);

        Task<ClienteEstacionResponseDto> GetClienteEstacionbyid(int id);

        Task<ClienteEstacionResponseDto> CreateClienteEstacion(ClienteEstacionRequestDto request);

        Task<ClienteEstacionResponseDto> updateclienteestacion(ClienteEstacionRequestDto monitor);

        Task deleteclienteestacion(int id);

        Task disableclienteestacion(int? id);

        Task activateclienteestacion(int? id);


    }
}
