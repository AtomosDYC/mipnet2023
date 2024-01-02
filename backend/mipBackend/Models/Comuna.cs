using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class Comuna
    {
        [Key]
        public int Id { get; set; }

        public string? nombre { get; set; }

        public string? descripcion { get; set; }

        public bool? IsCapital { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }

        //llave foranea
        public int? RegionId { get; set; }

        public Region? Region { get; set; }



    }
}
