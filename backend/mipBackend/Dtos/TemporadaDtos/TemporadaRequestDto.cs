using KendoNET.DynamicLinq;


namespace mipBackend.Dtos.TemporadaDtos
{
    public class TemporadaRequestDto
    {

       
        public string? temp01nombre { get; set; } = null!;

        public string? temp01descripcion { get; set; }

        public int? temp02llave { get; set; }

        public int? temp03llave { get; set; }

        public DateTime? temp01minfecha { get; set; }

        public DateTime? temp01maxfecha { get; set; }

        public int? temp01minmes { get; set; }

        public int? temp01maxmes { get; set; }

        public int? temp01periodo { get; set; }

    }

    public class TemporadaDesactivarRequestDto 
    {
        public TemporadaBaseResponseDto[]? ids { get; set; }

        public DataSourceRequest? filtro { get; set; }

    }

    public class TemporadaEliminarRequestDto
    {
        public string? id { get; set; }

        public DataSourceRequest? filtro { get; set; }

    }

}
