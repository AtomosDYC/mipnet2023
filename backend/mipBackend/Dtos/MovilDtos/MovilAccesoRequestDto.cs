namespace mipBackend.Dtos.MovilDtos
{
    public class MovilAccesoRequestDto
    {
        public Guid? id_movil { get; set; }

        public Guid? id_usuario { get; set; }

        public string? numero_movil { get; set; }

        public string? sistema_operativo { get; set; }

        public string? version_sistema { get; set; }

        public string? version_aplicacion { get; set; }

        public bool? esta_bloqueado { get; set; }

        public string? mensaje_movil { get; set; }

        public DateTime? fecha_mensaje_desde { get; set; }

        public DateTime? fecha_mensaje_hasta { get; set; }

        public DateTime? fecha_registro_desde { get; set; }

        public DateTime? fecha_registro_hasta { get; set; }

        public DateTime? fecha_ultimo_acceso_desde { get; set; }

        public DateTime? fecha_ultimo_acceso_hasta { get; set; }

        public DateTime? fecha_ultima_actividad_desde { get; set; }

        public DateTime? fecha_ultima_actividad_hasta { get; set; }

        public DateTime? fecha_ultima_sincro_desde { get; set; }

        public DateTime? fecha_ultima_sincro_hasta { get; set; }

        public decimal? tamano_basedatos_cliente { get; set; }

        public int? ubicacionactividadx { get; set; }

        public int? ubicacionactividady { get; set; }


    }
}
