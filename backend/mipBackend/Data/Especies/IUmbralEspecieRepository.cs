using mipBackend.Models;
using mipBackend.Dtos.EspecieDtos;

namespace mipBackend.Data.Especies
{
    public interface IUmbralEspecieRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<UmbralEspecieResponseDto>> GetUmbralEspecie(int id);

        Task<IEnumerable<UmbralEspecieResponseDto>> GetUmbralEspecieById(int id);

        Task<esp05Umbral> GetUmbralEspecieByIdUMbral(int id);
        
        Task CreateUmbralEspecie(esp05Umbral umbralespecie);

        Task DeleteUmbralEspecie(int id);
    }
}
