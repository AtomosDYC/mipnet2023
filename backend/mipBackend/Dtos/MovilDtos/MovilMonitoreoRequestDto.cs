namespace mipBackend.Dtos.MovilDtos
{
    public class MovilMonitoreoRequestDto
    {

        public int? CONTEO01_Llave { get; set; }
        public int? TRP01_Llave { get; set; }
        public int? CONTEO01_Valor { get; set; }
        public DateTime CONTEO01_FechaIngreso { get; set; }
        public DateTime CONTEO01_HoraIngreso { get; set; }
        public int? CONTEO01_EstadoVisado { get; set; }
        public string? CONTEO01_x { get; set; }
        public string? CONTEO01_y { get; set; }
        public string? CONTEO01_observacion { get; set; }
        public int? CONTEO01_EstadoConteo { get; set; }
        public int? CONTEO01_TipoSistema { get; set; }
        public int? TEMP02_Llave { get; set; }
        public Guid? MVL01_Llave { get; set; }
        public DateTime FECHAACTUALIZACION { get; set; }
        public Guid? CREATE_BY { get; set; }


    }
}
