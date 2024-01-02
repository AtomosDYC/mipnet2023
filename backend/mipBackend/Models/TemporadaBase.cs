using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class TemporadaBase
    {
        [Key]
        public int Id { get; set; }

        public string? nombre { get; set; }

        public string? descripcion { get; set; }

        public int? Predeterminada { get; set; }

        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }

        //referencia cruzada
        public IEnumerable<Temporada>? Temporadas { get; set; }
    }
}
