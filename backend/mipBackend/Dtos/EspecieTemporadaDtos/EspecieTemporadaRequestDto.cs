namespace mipBackend.Dtos.EspecieTemporadaDtos
{
    public class EspecieTemporadaRequestDto
    {
       
        public int? esp01llave { get; set; }

        public int? Temp01llave { get; set; }

        public DateTime? esp02InicioTemporada { get; set; }

        public DateTime? esp02TerminoTemporada { get; set; }

        public int? esp02Sag { get; set; }

        public int? esp02Mexico { get; set; }

    }
}
