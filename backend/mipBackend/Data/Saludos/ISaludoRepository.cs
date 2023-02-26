using mipBackend.Models;

namespace mipBackend.Data.Saludos
{
    public interface ISaludoRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Per02Genero>> GetAllSaludos();

        Task<Per02Genero> GetSaludoById(int id);

        Task CreateSaludo(Per02Genero region);

        Task UpdateSaludo(Per02Genero region);

        Task DeleteSaludo(int id);

        Task DisableSaludo(int id);

        Task ActivateSaludo(int id);
    }
}
