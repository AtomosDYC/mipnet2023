using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Clbr01Calibracion
{
    public int Clbr01llave { get; set; }

    public int? Sercl01llave { get; set; }

    public int? Clbr02llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? Temp02llave { get; set; }

    public string? Clbr01nombre { get; set; }

    public string? Clbr01UrlPdf { get; set; }

    public string? Clbr01descripcion { get; set; }

    public DateTime? Clbr01FechaCalibracion { get; set; }

    public int? Clbr01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Clbr02TipoCalibracion? Clbr02llaveNavigation { get; set; }
}
