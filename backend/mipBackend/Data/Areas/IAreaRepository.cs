using mipBackend.Models;

namespace mipBackend.Data.Areas
{
    public interface IAreaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Wkf08Area>> GetAllAreas();

        Task<Wkf08Area> GetAreaById(int id);

        Task CreateArea(Wkf08Area region);

        Task UpdateArea(Wkf08Area region);

        Task DeleteArea(int id);

        Task DisableArea(int id);

        Task ActivateArea(int id);
    }
}
