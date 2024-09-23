using mipBackend.Models;
using mipBackend.Dtos.TemporadaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Temporada
{
    public interface ITemporadaBaseRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllTemporadaBase(DataSourceRequest requestModel);

        Task<Temp02TemporadaBase> GetTemporadaBaseById(int id);

        Task CreateTemporadaBase(Temp02TemporadaBase Tipopersona);

        Task UpdateTemporadaBase(Temp02TemporadaBase Tipopersona);

        Task DeleteTemporadaBase(int id);

        Task DisableTemporadaBase(int id);

        Task ActivateTemporadaBase(int id);

    }
}
