using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Clbr01Calibracion
{
    public decimal Clbr01Llave { get; set; }

    public decimal? Sercl01Llave { get; set; }

    public decimal? Clbr02Llave { get; set; }

    public decimal? Cnt01Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

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
