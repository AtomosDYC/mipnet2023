using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Clbr02TipoCalibracion
{
    public int Clbr02Llave { get; set; }

    public string? Clbr02Nombre { get; set; }

    public string? Clbr02Descripcion { get; set; }

    public int? Clbr02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Clbr01Calibracion> Clbr01Calibracions { get; } = new List<Clbr01Calibracion>();
}
