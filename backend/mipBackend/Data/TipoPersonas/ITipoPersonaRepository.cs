using mipBackend.Models;
using mipBackend.Dtos.TipoPersonaDtos;

namespace mipBackend.Data.TipoPersonas
{
    public interface ITipoPersonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Per03TipoPersona>> GetAllTipoPersonas();

        Task<Per03TipoPersona> GetTipoPersonaById(int id);

        Task CreateTipoPersona(Per03TipoPersona TipoPersona);

        Task UpdateTipoPersona(Per03TipoPersona TipoPersona);

        Task DeleteTipoPersona(int id);

        Task DisableTipoPersona(int id);

        Task ActivateTipoPersona(int id);
    }
}
