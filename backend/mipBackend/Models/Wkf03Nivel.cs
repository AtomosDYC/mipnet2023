using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf03Nivel
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

    public virtual ICollection<wkf01Flujo> wkf01Flujos { get; } = new List<wkf01Flujo>();

    public virtual wkf02TipoFlujo? wkf02llaveNavigation { get; set; }

    public virtual ICollection<wkf04Nivelpermiso> wkf04Nivelpermisos { get; } = new List<wkf04Nivelpermiso>();
}
