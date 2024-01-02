using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pbcd02TipoPublicidad
{
    public int Pbcd02llave { get; set; }

    public string? Pbcd02nombre { get; set; }

    public string? Pbcd02descripcion { get; set; }

    public int? Pbcd02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Pbcd01Publicidad> Pbcd01Publicidads { get; } = new List<Pbcd01Publicidad>();
}
