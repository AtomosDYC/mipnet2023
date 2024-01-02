using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp01Temporada
{
    public int temp01llave { get; set; }

    public string temp01nombre { get; set; } = null!;

    public string? temp01descripcion { get; set; }

    public int? temp02llave { get; set; }

    public int? temp03llave { get; set; }

    public DateTime? temp01minfecha { get; set; }

    public DateTime? temp01maxfecha { get; set; }

    public int? temp01minmes { get; set; }

    public int? temp01maxmes { get; set; }

    public int? temp01periodo { get; set; }

    public int? temp01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<esp02Temporadaespecie> esp02Temporadaespecies { get; } = new List<esp02Temporadaespecie>();

    public virtual Temp02TemporadaBase? Temp02llaveNavigation { get; set; }

    public virtual Temp03Segmentacion? Temp03llaveNavigation { get; set; }
}
