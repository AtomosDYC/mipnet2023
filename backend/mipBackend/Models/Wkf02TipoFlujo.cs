using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf02TipoFlujo
{
    public int wkf02llave { get; set; }

    public string? wkf02nombre { get; set; }

    public string? wkf02descripcion { get; set; }

    public int? wkf02orden { get; set; }

    public int? wkf02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<wkf03Nivel> wkf03Nivels { get; } = new List<wkf03Nivel>();
}
