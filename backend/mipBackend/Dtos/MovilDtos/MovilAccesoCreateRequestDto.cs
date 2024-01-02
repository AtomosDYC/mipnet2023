namespace mipBackend.Dtos.MovilDtos
{
    public class MovilAccesoCreateRequestDto
    {
        public Guid? id_movil { get; set; }

        public Guid? id_usuario { get; set; }

        public string? numero_movil { get; set; }

        public string? sistema_operativo { get; set; }

        public string? version_sistema { get; set; }

        public string? version_aplicacion { get; set; }

        public bool? esta_bloqueado { get; set; }

        public string? mensaje_movil { get; set; }

        public DateTime? fecha_mensaje { get; set; }

        public DateTime? fecha_registro { get; set; }

        public DateTime? fecha_ultimo_acceso { get; set; }

        public DateTime? fecha_ultima_actividad { get; set; }

        public DateTime? fecha_ultima_sincro { get; set; }

        public decimal? tamano_basedatos_cliente { get; set; }




        public int? ubicacionactividadx { get; set; }

        public int? ubicacionactividady { get; set; }
    }
}
