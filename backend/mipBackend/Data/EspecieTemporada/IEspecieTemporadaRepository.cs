using mipBackend.Models;
using mipBackend.Dtos.EspecieTemporadaDtos;

using KendoNET.DynamicLinq;

namespace mipBackend.Data.EspecieTemporada
{
    public interface IEspecietemporadaRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllEspecieTemporadaDatasource(DataSourceRequest requestModel);

        Task<EspecieTemporadaResponseDto> GetEspecieTemporadaById(int id);

        Task Create(esp02Temporadaespecie request);

        Task Update(EspecieTemporadaResponseDto request);

        Task Delete(int id);

        Task Disable(int id);

        Task Activate(int id);


    }
}
