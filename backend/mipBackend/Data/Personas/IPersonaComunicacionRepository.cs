using mipBackend.Models;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Personas
{
    public interface IPersonaComunicacionRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllPersonaComunicacionDatasource(DataSourceRequest requestModel);

        Task<PersonaComunicacionResponseDto> GetPersonaComunicacionById(PersonaComunicacionbyidRequestDto request);

        Task CreatePersonaComunicacion(per05Comunicacion personacomunicacion);

        Task UpdatePersonaComunicacion(per05Comunicacion personacomunicacion);

        Task DeletePersonaComunicacion(PersonaComunicacionbyidRequestDto request);
    }
}
