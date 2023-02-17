using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp05Umbral
{
    public int Esp05Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Esp05MinUmbral { get; set; }

    public int? Esp05MaxUmbral { get; set; }

    public string? Esp05Color { get; set; }

    public int? Esp09Llave { get; set; }

    public int? Esp05Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Esp01Especie? Esp01LlaveNavigation { get; set; }

    public virtual Esp09TipoBaseUmbral? Esp09LlaveNavigation { get; set; }
}
