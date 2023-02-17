using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sist04Region
{
    public int sist04llave { get; set; }

    public string? sist04nombre { get; set; }

    public string? sist04descripcion { get; set; }

    public int? sist04orden { get; set; }

    public int? sist04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Sist03Comuna> Sist03Comunas { get; } = new List<Sist03Comuna>();
}
