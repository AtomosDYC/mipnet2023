using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sercl02MuestreoFrutum
{
    public int Sercl02Llave { get; set; }

    public int? Sercl01Llave { get; set; }

    public string? Sercl02Nombre { get; set; }

    public string? Sercl02UrlPdf { get; set; }

    public DateTime? Sercl02Fecha { get; set; }

    public int? Sercl02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Sercl01ServiciosCliente? Sercl01LlaveNavigation { get; set; }
}
