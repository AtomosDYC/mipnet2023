using mipBackend.Models;
namespace mipBackend.Data.TipoEspecie
{
    public interface ITipoEspecieRepository
    {

        Task<bool> SaveChanges();

        Task<IEnumerable<Esp08TipoBase>> GetAllTipoEspecies();

        Task<Esp08TipoBase> GetTipoEspecieById(int id);

        Task CreateTipoEspecie(Esp08TipoBase tipoespecie);

        Task UpdateTipoEspecie(Esp08TipoBase tipoespecie);

        Task DeleteTipoEspecie(int id);

        Task DisableTipoEspecie(int id);

        Task ActivateTipoEspecie(int id);

    }
}
