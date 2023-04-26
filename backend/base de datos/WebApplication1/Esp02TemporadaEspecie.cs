using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Esp02TemporadaEspecie
{
    public int Esp02Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp01Llave { get; set; }

    public DateTime? Esp02InicioTemporada { get; set; }

    public DateTime? Esp02TerminoTemporada { get; set; }

    public int? Esp02Sag { get; set; }

    public int? Esp02Mexico { get; set; }

    public int? Esp02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Esp01Especy? Esp01LlaveNavigation { get; set; }

    public virtual Temp01Temporadum? Temp01LlaveNavigation { get; set; }

    public virtual ICollection<Mnt01Monitore> Mnt01Llaves { get; set; } = new List<Mnt01Monitore>();
}
