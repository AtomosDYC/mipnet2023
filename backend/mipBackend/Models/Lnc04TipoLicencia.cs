using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc04TipoLicencia
{
    public int Lnc04Llave { get; set; }

    public string? Lnc04Nombre { get; set; }

    public string? Lnc04Descripcion { get; set; }

    public int? Lnc04Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
