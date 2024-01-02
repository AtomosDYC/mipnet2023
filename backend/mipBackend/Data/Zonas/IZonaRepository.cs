using mipBackend.Models;

namespace mipBackend.Data.Zonas
{
    public interface IZonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<sist02Zona>> GetAllZonas();

        Task<sist02Zona> GetZonaById(int id);

        Task CreateZona(sist02Zona zona);

        Task UpdateZona(sist02Zona zona);

        Task DeleteZona(int id);

        Task DisableZona(int id);

        Task ActivateZona(int id);
    }
}