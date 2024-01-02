using mipBackend.Models;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Dtos.UsuarioDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Personas
{
    public interface IPersonaAccesoRepository
    {
        Task<bool> SaveChanges();

        Task<PersonaAccesoResponseDto> GetPersonaAccesoById(int id);

        Task<int> RegistroPersonaAcceso(PersonaAccesoRequestDto request);
    }
}


