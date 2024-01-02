namespace mipBackend.Dtos.MovilDtos
{
    public class MovilAccesoActividadRequestDto
    {
        public Guid? id_movil { get; set; }

        public Guid? id_usuario { get; set; }

        public int? ubicacionactividadx { get; set; }

        public int? ubicacionactividady { get; set; }
    }
}
