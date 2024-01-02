using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp06MedidaUmbral
{
    public int esp06llave { get; set; }

    public string? esp06nombre { get; set; }

    public string? esp06descripcion { get; set; }

    public int? esp06activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<esp04EstadoDanio> esp04EstadoDanios { get; } = new List<esp04EstadoDanio>();
}
