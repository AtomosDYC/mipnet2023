using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Obsc02ServicioPostcosecha
{
    public decimal Obsc02Llave { get; set; }

    public decimal? Esp08Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public string? Obsc02Nombre { get; set; }

    public string? Obsc02Resumen { get; set; }

    public int? Obsc02Activo { get; set; }

    public DateTime? Obsc02Fecha { get; set; }

    public string? Obsc02UrlPdf { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
