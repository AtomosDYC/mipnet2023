using mipBackend.Models;
using mipBackend.Dtos.MonitorDtos;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public interface IMonitorComunicacionRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllMonitorComunicacionDatasource(DataSourceRequest requestModel);

        Task<MonitorComunicacionResponseDto> GetMonitorComunicacionById(MonitorComunicacionbyidRequestDto request);

        Task CreateMonitorComunicacion(MonitorComunicacionRequestDto monitorcomunicacion);

        Task UpdateMonitorComunicacion(per05Comunicacion monitorcomunicacion);

        Task DeleteMonitorComunicacion(MonitorComunicacionbyidRequestDto request);
    }
}
