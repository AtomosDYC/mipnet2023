namespace mipBackend.Dtos.EspecieTemporadaDtos
{
    public class EspecieTemporadaResponseDto
    {
        public int esp02llave { get; set; }

        public int? esp01llave { get; set; }

        public int? esp03llave { get; set; }

        public string? esp03nombre { get; set; }
        
        public int? esp04llave { get; set; }

        public string? esp04nombre { get; set; }

        public int? esp08llave { get; set; }

        public string? esp08nombre { get; set; }

        public int? temp01llave { get; set; }

        public int? temp02llave { get; set; }

        public string? temp02nombre { get; set; }

        public DateTime? esp02iniciotemporada { get; set; }

        public DateTime? esp02terminotemporada { get; set; }

        public int? esp02sag { get; set; }

        public int? esp02mexico { get; set; }

        public int? esp02activo { get; set; }

    }
}
