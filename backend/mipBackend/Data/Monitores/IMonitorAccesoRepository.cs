using mipBackend.Models;
using mipBackend.Dtos.PersonaDtos;
using mipBackend.Dtos.UsuarioDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public interface IMonitorAccesoRepository
    {
        Task<bool> SaveChanges();

        Task<PersonaAccesoResponseDto> GetMonitorAccesoById(int id);

        Task<int> RegistroMonitorAcceso(PersonaAccesoRequestDto request);
    }
}


