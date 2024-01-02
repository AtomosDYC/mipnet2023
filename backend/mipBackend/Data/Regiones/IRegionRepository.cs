using mipBackend.Models;

namespace mipBackend.Data.Regiones
{
    public interface IRegionRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<sist04Region>> GetAllRegiones();

        Task<sist04Region> GetRegionById(int id);

        Task CreateRegion(sist04Region region);

        Task UpdateRegion(sist04Region region);

        Task DeleteRegion(int id);

        Task DisableRegion(int id);

        Task ActivateRegion(int id);

    }
}
