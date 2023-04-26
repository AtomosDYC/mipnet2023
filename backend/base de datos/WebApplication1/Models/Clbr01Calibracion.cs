using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Clbr01Calibracion
{
    public int Clbr01Llave { get; set; }

    public int? Sercl01Llave { get; set; }

    public int? Clbr02Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public string? Clbr01Nombre { get; set; }

    public string? Clbr01UrlPdf { get; set; }

    public string? Clbr01Descripcion { get; set; }

    public DateTime? Clbr01FechaCalibracion { get; set; }

    public int? Clbr01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Clbr02TipoCalibracion? Clbr02LlaveNavigation { get; set; }
}
