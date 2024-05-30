using mipBackend.Models;
using mipBackend.Dtos.ClienteEstacionDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.ClienteEstaciones
{
    public interface IClienteEstacionComunicacionRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllClienteEstacionComunicacionDatasource(DataSourceRequest requestModel);

        Task<ClienteEstacionComunicacionResponseDto> GetAllClienteEstacionComunicacionById(ClienteEstacionComunicacionRequestDto request);

        Task<bool> CreateClienteEstacionComunicacion(ClienteEstacionComunicacionRequestDto request);

        Task DeleteClienteEstacionComunicacion(ClienteEstacionComunicacionRequestDto request);

    }
}
