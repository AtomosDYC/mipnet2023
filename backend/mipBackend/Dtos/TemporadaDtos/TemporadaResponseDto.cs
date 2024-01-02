namespace mipBackend.Dtos.TemporadaDtos
{
    public class TemporadaResponseDto
    {
        public int temp01llave { get; set; }

        public string? temp01nombre { get; set; } = null!;

        public string? temp01descripcion { get; set; }

        public int? temp02llave { get; set; }

        public string? temp02nombre { get; set; }

        public int? temp03llave { get; set; }

        public string? temp03nombre { get; set; }

        public DateTime? temp01minfecha { get; set; }

        public DateTime? temp01maxfecha { get; set; }

        public int? temp01minmes { get; set; }

        public int? temp01maxmes { get; set; }

        public int? temp01periodo { get; set; }

        public int? temp01activo { get; set; }
    }
}
