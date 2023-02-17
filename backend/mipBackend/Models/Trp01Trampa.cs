using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Trp01Trampa
{
    public int Trp01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public string? Trp01Nombre { get; set; }

    public int? Trp01Activo { get; set; }

    public int? Trp01Numero { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual Esp01Especie? Esp01LlaveNavigation { get; set; }

    public virtual ICollection<Trp02Temporada> Trp02Temporada { get; } = new List<Trp02Temporada>();
}
