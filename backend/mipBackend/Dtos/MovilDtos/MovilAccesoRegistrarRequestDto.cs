namespace mipBackend.Dtos.MovilDtos
{
    public class MovilAccesoRegistrarRequestDto
    {

        public Guid? id_movil { get; set; }

        public Guid? id_usuario { get; set; }

        public string? numero_movil { get; set; }

        public string? sistema_operativo { get; set; }

        public string? version_sistema { get; set; }

        public string? version_aplicacion { get; set; }


    }
}
