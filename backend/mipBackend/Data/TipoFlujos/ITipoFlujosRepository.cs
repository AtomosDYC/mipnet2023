using mipBackend.Models;
using mipBackend.Dtos.TipoFlujoDtos;

namespace mipBackend.Data.TipoFlujos
{
    public interface ITipoFlujosRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Wkf02TipoFlujo>> GetAllTipoFlujos();

        Task<Wkf02TipoFlujo> GetTipoFlujoById(int id);

        Task CreateTipoFlujo(Wkf02TipoFlujo tipoflujo);

        Task UpdateTipoFlujo(Wkf02TipoFlujo tipoflujo);

        Task DeleteTipoFlujo(int id);

        Task DisableTipoFlujo(int id);

        Task ActivateTipoFlujo(int id);
    }
}
