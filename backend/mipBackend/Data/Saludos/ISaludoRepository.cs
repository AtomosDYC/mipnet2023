using mipBackend.Models;

namespace mipBackend.Data.Saludos
{
    public interface ISaludoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<per02Genero>> GetAllSaludos();

        Task<per02Genero> GetSaludoById(int id);

        Task CreateSaludo(per02Genero region);

        Task UpdateSaludo(per02Genero region);

        Task DeleteSaludo(int id);

        Task DisableSaludo(int id);

        Task ActivateSaludo(int id);
    }
}
