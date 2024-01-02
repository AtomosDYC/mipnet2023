using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pbcd03Programacion
{
    public int Pbcd03llave { get; set; }

    public int? Pbcd01llave { get; set; }

    public DateTime? Pbcd03InicioFecha { get; set; }

    public DateTime? Pbcd03TerminoFecha { get; set; }

    public int? Pbcd03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Pbcd01Publicidad? Pbcd01llaveNavigation { get; set; }
}
