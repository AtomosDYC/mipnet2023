using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt23Tipocobro
{
    public int Cnt23Llave { get; set; }

    public string? Cnt23Nombre { get; set; }

    public string? Cnt23Descripcion { get; set; }

    public int? Cnt23Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
