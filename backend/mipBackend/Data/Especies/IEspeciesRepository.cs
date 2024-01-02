using mipBackend.Models;
using mipBackend.Dtos.EspecieDtos;

namespace mipBackend.Data.Especies
{
    public interface IEspeciesRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<EspecieResponseDto>> GetAllEspecies();

        Task<EspecieResponseDto> GetEspecieById(int id);

        Task CreateDatosgenerales(esp03especieBase especie);

        Task UpdateDatosgenerales(EspecieResponseDto especie);

        Task<IEnumerable<UnirEspecieResponseDto>> GetUnirEspecies(int id);

        Task CreateUnirespecie(esp07Union especie);

        Task DeleteUnirespecie(UnirEspecieRequestDto request);

    }
}
