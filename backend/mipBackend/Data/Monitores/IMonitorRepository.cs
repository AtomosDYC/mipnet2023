using mipBackend.Models;
using mipBackend.Dtos.MonitorDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public interface IMonitorRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllMonitorDatasource(DataSourceRequest options); 

        Task<IEnumerable<MonitorResponseDto>> GetAllMonitores();

        Task<MonitorResponseDto> GetMonitorById(int id);

        Task<string> CreateMonitores(MonitorRequestDto monitor);

        Task<string> UpdateMonitores(MonitorResponseDto monitor);

        Task DeleteMonitores(int id);

        Task DisableMonitores(int id);

        Task ActivateMonitores(int id);



    }
}
