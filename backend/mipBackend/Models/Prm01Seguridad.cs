using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prm01Seguridad
{
    public int Prm01Llave { get; set; }

    public string? Prm01Nombre { get; set; }

    public string? Prm01Descripcion { get; set; }

    public int? Prm01Valor { get; set; }

    public string? Prm01UrlError { get; set; }

    public int? Prm01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
