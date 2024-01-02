using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp05Umbral
{
    public int esp05llave { get; set; }

    public int esp01llave { get; set; }

    public int? esp05MinUmbral { get; set; }

    public int? esp05MaxUmbral { get; set; }

    public string? esp05Color { get; set; }

    public int? esp09llave { get; set; }

    public int? esp05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual esp01especie? esp01llaveNavigation { get; set; }

    public virtual esp09TipoBaseUmbral? esp09llaveNavigation { get; set; }
}
