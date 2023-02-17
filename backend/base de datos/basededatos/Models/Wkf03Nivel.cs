using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf03Nivel
{
    public decimal Wkf03Llave { get; set; }

    public decimal? Wkf02Llave { get; set; }

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

    public virtual ICollection<Wkf01Flujo> Wkf01Flujos { get; } = new List<Wkf01Flujo>();

    public virtual Wkf02TipoFlujo? Wkf02LlaveNavigation { get; set; }

    public virtual ICollection<Wkf04NivelPermiso> Wkf04NivelPermisos { get; } = new List<Wkf04NivelPermiso>();
}
