using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Clbr02TipoCalibracion
{
    public decimal Clbr02Llave { get; set; }

    public string? Clbr02Nombre { get; set; }

    public string? Clbr02Descripcion { get; set; }

    public int? Clbr02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Clbr01Calibracion> Clbr01Calibracions { get; } = new List<Clbr01Calibracion>();
}
