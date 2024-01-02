using mipBackend.Models;
using mipBackend.Dtos.EspecieDtos;

namespace mipBackend.Data.Especies
{
    public interface IReglaEspecieRepository
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<ReglaEspecieResponseDto>> GetReglaEspecie(int id);

        Task<IEnumerable<ReglaEspecieResponseDto>> GetReglaEspecieById(int id);

        Task<esp11ReglaGrafico> GetREglaEspecieByIdUMbral(int id);

        Task CreateReglaEspecie(esp11ReglaGrafico reglaespecie);

        Task DeleteReglaEspecie(int id);

    }
}
