using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp09TipoBaseUmbral
{
    public int Esp09Llave { get; set; }

    public string? Esp09Nombre { get; set; }

    public string? Esp09Descripcion { get; set; }

    public int? Esp09Activo { get; set; }

    public int? Esp09Orden { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp05Umbral> Esp05Umbrals { get; } = new List<Esp05Umbral>();
}
