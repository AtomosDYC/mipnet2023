using mipBackend.Models;
namespace mipBackend.Data.Tipoespecie
{
    public interface ITipoespecieRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<esp08TipoBase>> GetAllTipoespecies();

        Task<esp08TipoBase> GetTipoespecieById(int id);

        Task CreateTipoespecie(esp08TipoBase tipoespecie);

        Task UpdateTipoespecie(esp08TipoBase tipoespecie);

        Task DeleteTipoespecie(int id);

        Task DisableTipoespecie(int id);

        Task ActivateTipoespecie(int id);

    }
}
