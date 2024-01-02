using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp04EstadoDanio
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

    public virtual ICollection<esp01especie> esp01especies { get; } = new List<esp01especie>();

    public virtual esp06MedidaUmbral? esp06llaveNavigation { get; set; }
}
