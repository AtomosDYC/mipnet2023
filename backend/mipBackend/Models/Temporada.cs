using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models
{
    public class Temporada
    {

        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Termino { get; set; }

        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid? UsuarioId { get; set; }

        //llave foranea
        public int? TemporadaBaseId { get; set; }

        public TemporadaBase? TemporadaBase { get; set; }

        public int? TemporadaSegmentacionId { get; set; }

        public TemporadaSegmentacion? TemporadaSegmentacion { get; set; }

    }
}
