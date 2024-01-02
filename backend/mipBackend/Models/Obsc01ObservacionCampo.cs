using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Obsc01ObservacionCampo
{
    public int Obsc01llave { get; set; }

    public int? esp08llave { get; set; }

    public int? Temp02llave { get; set; }

    public string? Obsc01nombre { get; set; }

    public string? Obsc01Resumen { get; set; }

    public int? Obsc01activo { get; set; }

    public DateTime? Obsc01FechaObservacion { get; set; }

    public string? Obsc01UrlPdf { get; set; }

    public int? Obsc01Interesado { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual esp08TipoBase? esp08llaveNavigation { get; set; }

    public virtual Temp02TemporadaBase? Temp02llaveNavigation { get; set; }
}
