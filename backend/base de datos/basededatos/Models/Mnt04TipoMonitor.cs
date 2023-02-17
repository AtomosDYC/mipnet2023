using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Mnt04TipoMonitor
{
    public decimal Mnt04Llave { get; set; }

    public string? Mnt04Nombre { get; set; }

    public string? Mnt04Descripcion { get; set; }

    public int? Mnt04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Mnt01Monitore> Mnt01Monitores { get; } = new List<Mnt01Monitore>();
}
