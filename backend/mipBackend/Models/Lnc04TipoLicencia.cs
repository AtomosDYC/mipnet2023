using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc04TipoLicencia
{
    public int Lnc04llave { get; set; }

    public string? Lnc04nombre { get; set; }

    public string? Lnc04descripcion { get; set; }

    public int? Lnc04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
