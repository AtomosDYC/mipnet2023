using mipBackend.Models;
using mipBackend.Dtos.TipoFlujoDtos;

namespace mipBackend.Data.TipoFlujos
{
    public interface ITipoFlujosRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<wkf02TipoFlujo>> GetAllTipoFlujos();

        Task<wkf02TipoFlujo> GetTipoFlujoById(int id);

        Task CreateTipoFlujo(wkf02TipoFlujo tipoflujo);

        Task UpdateTipoFlujo(wkf02TipoFlujo tipoflujo);

        Task DeleteTipoFlujo(int id);

        Task DisableTipoFlujo(int id);

        Task ActivateTipoFlujo(int id);
    }
}
