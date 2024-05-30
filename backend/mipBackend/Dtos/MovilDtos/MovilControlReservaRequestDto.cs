namespace mipBackend.Dtos.MovilDtos
{
    public class MovilControlReservaRequestDto
    {
        public int? conteo05_llave { get; set; }

        public string? conteo05_tabla_control { get; set; }

        public string? conteo05_columna_control { get; set; }

        public int? conteo05_valor_control { get; set; }

        public Guid? id_movil { get; set; }

        public Guid? id_usuario { get; set; }

        public int? conteo05_estado_control { get; set; }

        public bool? conteo05_estado { get; set; }

        public string? conteo05_primer { get; set; }

        public string? conteo05_segundo { get; set; }

        public string? conteo05_tercer { get; set; } 

        public DateTime? conteo05_fecha  { get; set; }

    }
}
