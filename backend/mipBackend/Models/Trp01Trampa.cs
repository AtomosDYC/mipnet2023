using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Trp01Trampa
{
    public int Trp01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? esp01llave { get; set; }

    public string? Trp01nombre { get; set; }

    public int? Trp01activo { get; set; }

    public int? Trp01Numero { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt08Segmentacion? cnt08llaveNavigation { get; set; }

    public virtual esp01especie? esp01llaveNavigation { get; set; }

    public virtual ICollection<Trp02Temporada> Trp02Temporada { get; } = new List<Trp02Temporada>();
}
