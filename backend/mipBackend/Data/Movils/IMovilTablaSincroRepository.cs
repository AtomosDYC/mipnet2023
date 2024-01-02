using mipBackend.Models;
using mipBackend.Dtos.MovilSincroDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Movils
{
    public interface IMovilTablaSincroRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetTablaBaseSincro();

        Task<DataSourceResult> GetTablaSincro(MovilSincroRequestDto request);

        Task<int> UpdateTablaSincro(MovilUpdateTablaSincroRequestDto request); 

    }
}
