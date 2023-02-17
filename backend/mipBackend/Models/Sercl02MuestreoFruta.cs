using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sercl02MuestreoFruta
{
    public int Sercl02Llave { get; set; }

    public int? Sercl01Llave { get; set; }

    public string? Sercl02Nombre { get; set; }

    public string? Sercl02UrlPdf { get; set; }

    public DateTime? Sercl02Fecha { get; set; }

    public int? Sercl02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Sercl01ServiciosCliente? Sercl01LlaveNavigation { get; set; }
}
