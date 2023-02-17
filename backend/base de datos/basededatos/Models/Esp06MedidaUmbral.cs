﻿using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Esp06MedidaUmbral
{
    public decimal Esp06Llave { get; set; }

    public string? Esp06Nombre { get; set; }

    public string? Esp06Descripcion { get; set; }

    public int? Esp06Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp04EstadoDanio> Esp04EstadoDanios { get; } = new List<Esp04EstadoDanio>();
}