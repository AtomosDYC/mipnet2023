using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Regione
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Orden { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? UsuarioId { get; set; }

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();
}
