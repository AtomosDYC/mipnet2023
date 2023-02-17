using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Obsc01ObservacionCampo
{
    public int Obsc01Llave { get; set; }

    public int? Esp08Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public string? Obsc01Nombre { get; set; }

    public string? Obsc01Resumen { get; set; }

    public int? Obsc01Activo { get; set; }

    public DateTime? Obsc01FechaObservacion { get; set; }

    public string? Obsc01UrlPdf { get; set; }

    public int? Obsc01Interesado { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Esp08TipoBase? Esp08LlaveNavigation { get; set; }

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }
}
