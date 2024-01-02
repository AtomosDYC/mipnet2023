using mipBackend.Models;
using mipBackend.Dtos.MovilDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Movils
{
    public interface IMovilPeriodoRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetPeriodosMovil(MovilPeriodoRequestDto request);


    }
}
 