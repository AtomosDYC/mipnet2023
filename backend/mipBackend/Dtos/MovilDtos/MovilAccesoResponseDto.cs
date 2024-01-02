namespace mipBackend.Dtos.MovilDtos
{
    public class MovilAccesoResponseDto
    {
        public Guid? id_movil { get; set; }
        public int ? id_usuario { get; set; }

        public Guid? llave_usuario { get; set; }
        public string? numero_movil { get; set; }
        public string? sistema_operativo { get; set; }
        public string? version_sistema { get; set; }
        public string? version_aplicacion { get; set; }

        public string? version_descarga { get; set; }

        public bool? esta_bloqueado { get; set; }

        public string? mensaje_movil { get; set; }
        public string? fecha_mensaje { get; set; }

        public DateTime? fecha_registro { get; set; }

        public DateTime? ultimo_acceso { get; set; }

        public DateTime? ultima_actividad { get; set; }

        public DateTime? ultima_sincro { get; set; }

        public string? basedatos_cliente { get; set; }

        public string? ubicacion_actividad_x { get; set; }

        public string? ubicacion_actividad_y { get; set; }

        public bool? edita_fecha_monitoreo { get; set; }

        public int? dias_umbral_edicion { get; set; }

        public DateTime? fechaactualizacion { get; set; }

        public DateTime? fechaeliminacion { get; set; }

    }
}
