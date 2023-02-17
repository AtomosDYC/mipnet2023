using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf09Parametro
{
    public int wkf09llave { get; set; }

    public int? wkf01llave { get; set; }

    public int? wkf10llave { get; set; }

    public string? wkf09variable { get; set; }

    public string? wkf09valor { get; set; }

    public int? wkf09activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Wkf01Flujo? Wkf01LlaveNavigation { get; set; }

    public virtual Wkf10TipoParametro? Wkf10LlaveNavigation { get; set; }
}
