using mipBackend.Models;
using mipBackend.Dtos.TemporadaDtos;

namespace mipBackend.Data.Temporada
{
    public interface ITemporadaRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<TemporadaResponseDto>> GetAllTemporada();

        Task<TemporadaResponseDto> GetTemporadaById(int id);

        Task CreateTemporada(Temp01Temporada Temporada);

        Task UpdateTemporada(Temp01Temporada Temporada);

        Task DeleteTemporada(int id);

        Task DisableTemporada(int id);

        Task ActivateTemporada(int id);

    }
}
