using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt04TipoMonitor
{
    public int Mnt04Llave { get; set; }

    public string? Mnt04Nombre { get; set; }

    public string? Mnt04Descripcion { get; set; }

    public int? Mnt04Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Mnt01Monitor> Mnt01Monitores { get; } = new List<Mnt01Monitor>();
}
