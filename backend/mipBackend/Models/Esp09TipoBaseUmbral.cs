using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp09TipoBaseUmbral
{
    public int esp09llave { get; set; }

    public string? esp09nombre { get; set; }

    public string? esp09descripcion { get; set; }

    public int? esp09activo { get; set; }

    public int? esp09Orden { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<esp05Umbral> esp05Umbrals { get; } = new List<esp05Umbral>();
}
