using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Trp01Trampa
{
    public int Trp01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public string? Trp01Nombre { get; set; }

    public int? Trp01Activo { get; set; }

    public int? Trp01Numero { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual Esp01Especy? Esp01LlaveNavigation { get; set; }

    public virtual ICollection<Trp02Temporadum> Trp02Temporada { get; set; } = new List<Trp02Temporadum>();
}
