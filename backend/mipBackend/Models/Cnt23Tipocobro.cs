using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt23Tipocobro
{
    public int cnt23llave { get; set; }

    public string? cnt23nombre { get; set; }

    public string? cnt23descripcion { get; set; }

    public int? cnt23activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
