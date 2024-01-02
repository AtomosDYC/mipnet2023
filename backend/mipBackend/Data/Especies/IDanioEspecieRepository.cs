using mipBackend.Models;
using mipBackend.Dtos.EspecieDtos;

namespace mipBackend.Data.Especies
{
    public interface IDanioEspecieRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<DanioEspecieResponseDto>> GetDanioEspecie(int id);

        Task CreateDanioEspecie(esp01especie especie);

        Task DeleteDanioEspecie(DanioEspecieResponseDto request);
    }
}
