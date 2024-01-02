using mipBackend.Models;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public interface IMonitorSincronizacionRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllMonitorSincronizacionDatasource(DataSourceRequest requestModel);

        Task<int> sincronizartodo(int id);

    }
}
