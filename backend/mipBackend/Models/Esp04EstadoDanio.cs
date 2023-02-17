using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp04EstadoDanio
{
    public int esp04llave { get; set; }

    public string? esp04nombre { get; set; }

    public string? esp04descripcion { get; set; }

    public int? esp06llave { get; set; }

    public int? esp04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp01Especie> Esp01Especies { get; } = new List<Esp01Especie>();

    public virtual Esp06MedidaUmbral? Esp06LlaveNavigation { get; set; }
}
