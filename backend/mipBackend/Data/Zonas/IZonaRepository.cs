using mipBackend.Models;

namespace mipBackend.Data.Zonas
{
    public interface IZonaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Sist02Zona>> GetAllZonas();

        Task<Sist02Zona> GetZonaById(int id);

        Task CreateZona(Sist02Zona zona);

        Task UpdateZona(Sist02Zona zona);

        Task DeleteZona(int id);

        Task DisableZona(int id);

        Task ActivateZona(int id);
    }
}