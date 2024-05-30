using mipBackend.Models;
using mipBackend.Dtos.MovilDtos;
using KendoNET.DynamicLinq;

namespace mipBackend.Data.Movils
{
    public interface IMovilControlReservaRepository
    {
        Task<IEnumerable<MovilControlReservaResponseDto>> listar_control_reserva(MovilControlReservaRequestDto request);

        Task<Int32> mantenimiento_control_reserva(MovilControlReservaRequestDto request);

        Task<Int32?> existe_llave_control_reserva(MovilControlReservaExisteRequestDto request);

        Task<bool> insertar_control_reserva(MovilControlReservaInsertarRequestDto request);

        /*
        Task mantencion_control_reserva();

        

        Task existe_llave_reserva_conteo();

        Task existe_llave_reserva_manejo();

        */

    }
}
