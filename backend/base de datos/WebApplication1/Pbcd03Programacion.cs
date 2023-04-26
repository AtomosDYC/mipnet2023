using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Pbcd03Programacion
{
    public int Pbcd03Llave { get; set; }

    public int? Pbcd01Llave { get; set; }

    public DateTime? Pbcd03InicioFecha { get; set; }

    public DateTime? Pbcd03TerminoFecha { get; set; }

    public int? Pbcd03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Pbcd01Publicidad? Pbcd01LlaveNavigation { get; set; }
}
