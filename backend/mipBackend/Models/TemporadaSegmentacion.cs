using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class TemporadaSegmentacion
    {
        [Key]
        public int Id { get; set; }

        public string? nombre { get; set; }

        public string? descripcion { get; set; }

        public int? numeromeses { get; set; }

        public int? numerosegmentosTotal { get; set; }

        public DateTime? createdat { get; set; }


        public DateTime? updatedat { get; set; }

        public bool? isdeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }

        //referencia cruzada
        public IEnumerable<Temporada>? Temporadas { get; set; }

    }
}
