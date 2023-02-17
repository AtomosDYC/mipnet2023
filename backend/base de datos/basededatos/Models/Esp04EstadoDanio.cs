using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Esp04EstadoDanio
{
    public decimal Esp04Llave { get; set; }

    public string? Esp04Nombre { get; set; }

    public string? Esp04Descripcion { get; set; }

    public decimal? Esp06Llave { get; set; }

    public int? Esp04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp01Especy> Esp01Especies { get; } = new List<Esp01Especy>();

    public virtual Esp06MedidaUmbral? Esp06LlaveNavigation { get; set; }
}
