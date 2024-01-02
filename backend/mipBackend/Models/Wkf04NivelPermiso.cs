using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf04Nivelpermiso
{
    public int wkf04llave { get; set; }

    public int? wkf03llave { get; set; }

    public int? wkf05llave { get; set; }

    public int? wkf04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual wkf03Nivel? wkf03llaveNavigation { get; set; }

    public virtual wkf05Tipopermiso? wkf05llaveNavigation { get; set; }
}
