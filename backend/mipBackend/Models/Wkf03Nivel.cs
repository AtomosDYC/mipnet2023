using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf03Nivel
{
    public int wkf03llave { get; set; }

    public int? wkf02llave { get; set; }

    public string? wkf03nombre { get; set; }

    public string? wkf03descripcion { get; set; }

    public int? wkf03activo { get; set; }

    public int? wkf03nivel1 { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Wkf01Flujo> Wkf01Flujos { get; } = new List<Wkf01Flujo>();

    public virtual Wkf02TipoFlujo? Wkf02LlaveNavigation { get; set; }

    public virtual ICollection<Wkf04NivelPermiso> Wkf04NivelPermisos { get; } = new List<Wkf04NivelPermiso>();
}
