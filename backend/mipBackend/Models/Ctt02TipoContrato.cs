using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Ctt02TipoContrato
{
    public int Ctt02llave { get; set; }

    public string? Ctt02nombre { get; set; }

    public string? Ctt02descripcion { get; set; }

    public int? Ctt02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Ctt01Contrato> Ctt01Contratos { get; } = new List<Ctt01Contrato>();
}
