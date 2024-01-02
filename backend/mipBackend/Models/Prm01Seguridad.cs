using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Prm01Seguridad
{
    public int Prm01llave { get; set; }

    public string? Prm01nombre { get; set; }

    public string? Prm01descripcion { get; set; }

    public int? Prm01Valor { get; set; }

    public string? Prm01UrlError { get; set; }

    public int? Prm01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
