using mipBackend.Models;
using mipBackend.Dtos.TemporadaDtos;

namespace mipBackend.Data.Temporada
{
    public interface ITemporadaBaseRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<Temp02TemporadaBase>> GetAllTemporadaBase();

        Task<Temp02TemporadaBase> GetTemporadaBaseById(int id);

        Task CreateTemporadaBase(Temp02TemporadaBase Tipopersona);

        Task UpdateTemporadaBase(Temp02TemporadaBase Tipopersona);

        Task DeleteTemporadaBase(int id);

        Task DisableTemporadaBase(int id);

        Task ActivateTemporadaBase(int id);

    }
}
