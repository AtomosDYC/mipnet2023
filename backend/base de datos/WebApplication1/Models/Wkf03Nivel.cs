using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Wkf03Nivel
{
    public int Wkf03Llave { get; set; }

    public int? Wkf02Llave { get; set; }

    public string? Wkf03Nombre { get; set; }

    public string? Wkf03Descripcion { get; set; }

    public int? Wkf03Activo { get; set; }

    public int? Wkf03Nivel1 { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Wkf01Flujo> Wkf01Flujos { get; set; } = new List<Wkf01Flujo>();

    public virtual Wkf02TipoFlujo? Wkf02LlaveNavigation { get; set; }

    public virtual ICollection<Wkf04NivelPermiso> Wkf04NivelPermisos { get; set; } = new List<Wkf04NivelPermiso>();
}
