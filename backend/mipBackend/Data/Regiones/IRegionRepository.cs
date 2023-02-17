using mipBackend.Models;

namespace mipBackend.Data.Regiones
{
    public interface IRegionRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Sist04Region>> GetAllRegiones();

        Task<Sist04Region> GetRegionById(int id);

        Task CreateRegion(Sist04Region region);

        Task UpdateRegion(Sist04Region region);

        Task DeleteRegion(int id);

        Task DisableRegion(int id);

        Task ActivateRegion(int id);

    }
}
