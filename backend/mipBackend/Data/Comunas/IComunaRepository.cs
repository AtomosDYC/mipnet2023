using mipBackend.Models;
using mipBackend.Dtos.ComunaDtos;

namespace mipBackend.Data.Comunas
{
    public interface IComunaRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<ComunaResponseDto>> GetAllComunas();

        Task<sist03Comuna> GetComunaById(int id);

        Task CreateComuna(sist03Comuna region);

        Task UpdateComuna(sist03Comuna region);

        Task DeleteComuna(int id);

        Task DisableComuna(int id);

        Task ActivateComuna(int id);
    }
}
