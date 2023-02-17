using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Esp05Umbral
{
    public decimal Esp05Llave { get; set; }

    public decimal? Esp01Llave { get; set; }

    public decimal? Esp05MinUmbral { get; set; }

    public decimal? Esp05MaxUmbral { get; set; }

    public string? Esp05Color { get; set; }

    public decimal? Esp09Llave { get; set; }

    public int? Esp05Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Esp01Especy? Esp01LlaveNavigation { get; set; }

    public virtual Esp09TipoBaseUmbral? Esp09LlaveNavigation { get; set; }
}
