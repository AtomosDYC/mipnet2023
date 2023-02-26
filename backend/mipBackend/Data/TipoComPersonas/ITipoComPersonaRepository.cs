using mipBackend.Models;
using mipBackend.Dtos.TipoComPersonaDtos;

namespace mipBackend.Data.TipoComPersonas
{
    public interface ITipoComPersonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Per04TipoComunicacion>> GetAllTipoComPersonas();

        Task<Per04TipoComunicacion> GetTipoComPersonaById(int id);

        Task CreateTipoComPersona(Per04TipoComunicacion tipocompersona);

        Task UpdateTipoComPersona(Per04TipoComunicacion tipocompersona);

        Task DeleteTipoComPersona(int id);

        Task DisableTipoComPersona(int id);

        Task ActivateTipoComPersona(int id);
    }
}
