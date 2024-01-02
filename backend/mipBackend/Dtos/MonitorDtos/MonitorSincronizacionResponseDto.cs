namespace mipBackend.Dtos.MonitorDtos
{
    public class MonitorSincronizacionResponseDto
    {

        public int mnt01llave { get; set; }

        public int? per01llave { get; set; }

        public string? per01nombrerazon { get; set; }

        public Guid userid { get; set; }

        public string? nombreTabla { get; set; }

        public DateTime? FechaUltimaActualizacion { get; set; }

        public DateTime? fechaeliminacion { get; set; }

    }
}
