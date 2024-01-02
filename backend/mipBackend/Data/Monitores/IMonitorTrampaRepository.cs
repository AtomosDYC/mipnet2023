using mipBackend.Models;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;


namespace mipBackend.Data.Monitores
{
    public interface IMonitorTrampaRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllMonitorTrampaDatasource(DataSourceRequest requestModel);

        Task<DataSourceResult> GetAllMonitorTrampaBuscadorDatasource(DataSourceRequest requestModel);

        Task<DataSourceResult> GetAllMonitorTrampaBuscadorDatasourceRaw(DataSourceRequest requestModel);

        Task<int> asignarTrampas(MonitorAsignarTrampaRequestDto especieasignadaespecieasignada);

        Task<int> replicarTrampas(int mnt01llave);

    }
}
