using mipBackend.Models;
using mipBackend.Dtos.MovilDtos;
using KendoNET.DynamicLinq;


namespace mipBackend.Data.Movils
{
    public interface IMovilAccesoRepository
    {

        Task<bool> SaveChanges();

        Task<DataSourceResult> GetMonitorMovilAcceso(DataSourceRequest options);

        Task<IEnumerable<MovilAccesoResponseDto>> listMovilAcceso(MovilAccesoRequestDto request);

        Task CreateMonitorMovilAcceso(MovilAccesoCreateRequestDto monitor);

        Task DesactivarMonitorMovilAcceso(MovilAccesoDesactivateRequestDto request);

        Task<int> RegistrarAccesoMovil(MovilAccesoCreateRequestDto monitor);

        Task<bool> Existe_movil_acceso(MovilAccesoExisteRequestDto request);

        Task<bool> Agregar_movil_acceso(MovilAccesoRegistrarRequestDto request);

        Task<bool> Registrar_actividad_movil(MovilAccesoActividadRequestDto request);

        Task<bool> registrar_sincro_movil(MovilAccesoSincroResponseDto request);

        Task<bool> estado_bloqueado_movil(MovilAccesoExisteRequestDto request);

        Task<MovilAccesoEditarFechaResponseDto> edita_fecha_monitoreo_movil(MovilAccesoExisteRequestDto request);

        Task<MovilAccesoVersionResponseDto> version_descarga_movil(MovilAccesoExisteRequestDto request);

    }
}
