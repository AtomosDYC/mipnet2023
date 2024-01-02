using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf09Parametro
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

    public virtual wkf01Flujo? wkf01llaveNavigation { get; set; }

    public virtual wkf10TipoParametro? wkf10llaveNavigation { get; set; }
}
