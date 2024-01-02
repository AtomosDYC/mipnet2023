using mipBackend.Models;
using mipBackend.Dtos.EstadosDanioDtos;

namespace mipBackend.Data.EstadosDanios
{
    public interface IEstadosDanioRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<EstadosDanioResponseDto>> GetAllEstadosDanios();

        Task<EstadosDanioResponseDto> GetEstadosDanioById(int id);

        Task CreateEstadosDanio(esp04EstadoDanio estadodanio);

        Task UpdateEstadosDanio(esp04EstadoDanio estadodanio);

        Task DeleteEstadosDanio(int id);

        Task DisableEstadosDanio(int id);

        Task ActivateEstadosDanio(int id);
    }
}
