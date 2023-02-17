using mipBackend.Models;
using mipBackend.Dtos.EstadosDanioDtos;

namespace mipBackend.Data.EstadosDanios
{
    public interface IEstadosDanioRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<EstadosDanioResponseDto>> GetAllEstadosDanios();

        Task<Esp04EstadoDanio> GetEstadosDanioById(int id);

        Task CreateEstadosDanio(Esp04EstadoDanio estadodanio);

        Task UpdateEstadosDanio(Esp04EstadoDanio estadodanio);

        Task DeleteEstadosDanio(int id);

        Task DisableEstadosDanio(int id);

        Task ActivateEstadosDanio(int id);
    }
}
