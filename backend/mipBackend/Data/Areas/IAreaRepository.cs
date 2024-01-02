using mipBackend.Models;

namespace mipBackend.Data.Areas
{
    public interface IAreaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<wkf08Area>> GetAllAreas();

        Task<wkf08Area> GetAreaById(int id);

        Task CreateArea(wkf08Area region);

        Task UpdateArea(wkf08Area region);

        Task DeleteArea(int id);

        Task DisableArea(int id);

        Task ActivateArea(int id);
    }
}
