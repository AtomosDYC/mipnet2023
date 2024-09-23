using mipBackend.Models;
using mipBackend.Dtos.EstacionDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Estaciones
{
    public interface IEstacionRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllEstacionesDatasource(DataSourceRequest requestModel);

        Task<IEnumerable<MenuEstacionResponseDto>> getMenuEstacion(string id, string encoid);
    }
}
