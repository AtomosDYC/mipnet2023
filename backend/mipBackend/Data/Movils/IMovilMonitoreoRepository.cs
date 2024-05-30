using mipBackend.Models;
using mipBackend.Dtos.MovilDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Movils
{
    public interface IMovilMonitoreoRepository
    {

        Task<Int32> mantenimiento_monitoreo(MovilMonitoreoRequestDto request);

        Task<Int32> reservar_registro_monitoreo();

        Task<bool> actualizar_registro_monitoreo(MovilMonitoreoActualizarRequest request);

    }
}
