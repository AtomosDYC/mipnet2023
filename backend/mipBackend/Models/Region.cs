using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Orden { get; set; }

        public DateTime? CreatedAt { get; set; }

       
        public DateTime? UpdatedAt { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }

        public IEnumerable<Comuna>? Comunas { get; set; }

    }
}
