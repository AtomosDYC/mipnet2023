using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp11ReglaGrafico
{
    public int esp11llave { get; set; }

    public int? esp03llave { get; set; }

    public int? esp10llave { get; set; }

    public string? esp11nombre { get; set; }

    public string? esp11signo1 { get; set; }

    public int? esp11valor1 { get; set; }

    public string? esp11signo2 { get; set; }

    public int? esp11valor2 { get; set; }

    public string? esp11signoresultado { get; set; }

    public int? esp11valorresultado { get; set; }

    public int? esp11estado { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual esp10TipoRegla? esp10llaveNavigation { get; set; }
}
