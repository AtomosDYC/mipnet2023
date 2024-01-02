using mipBackend.Models;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Personas
{
    public interface IPersonaRepository
    {
        Task<bool> SaveChanges();

        Task<DataSourceResult> GetAllPersonasDatasource(DataSourceRequest requestModel);

        Task<IEnumerable<PersonaResponseDto>> GetAllPersonas();

        Task<PersonaResponseDto> GetPersonaByRut(PersonaBuscarRutRepositoryDto buscador);

        Task<PersonaResponseDto> GetPersonaById(int id);

        Task CreatePersonas(per01persona Persona);

        Task UpdatePersonas(per01persona Persona);

        Task DeletePersonas(int id);
    }
}
