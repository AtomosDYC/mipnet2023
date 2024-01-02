using mipBackend.Models;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public interface IMonitorEspecieRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllMonitorEspecieDatasource(DataSourceRequest requestModel);

        Task CreateMonitorEspecie(MonitorEspecieRequestDto especieasignada);

        Task DeleteMonitorEspecie(MonitorEspecieRequestDto request);

    }
}
