using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf05Tipopermiso
{
    public int wkf05llave { get; set; }

    public string? wkf05nombre { get; set; }

    public string? wkf05descripcion { get; set; }

    public string? wkf05sigla { get; set; }

    public int? wkf05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<wkf04Nivelpermiso> wkf04Nivelpermisos { get; } = new List<wkf04Nivelpermiso>();

    public virtual ICollection<wkf07perfilespermiso> wkf07perfilespermisos { get; } = new List<wkf07perfilespermiso>();
}
