﻿using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Pbcd02TipoPublicidad
{
    public decimal Pbcd02Llave { get; set; }

    public string? Pbcd02Nombre { get; set; }

    public string? Pbcd02Descripcion { get; set; }

    public int? Pbcd02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Pbcd01Publicidad> Pbcd01Publicidads { get; } = new List<Pbcd01Publicidad>();
}