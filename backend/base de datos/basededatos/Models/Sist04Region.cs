using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Sist04Region
{
    public decimal Sist04Llave { get; set; }

    public string? Sist04Nombre { get; set; }

    public string? Sist04Descripcion { get; set; }

    public decimal? Sist04Orden { get; set; }

    public int? Sist04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Sist03Comuna> Sist03Comunas { get; } = new List<Sist03Comuna>();
}
