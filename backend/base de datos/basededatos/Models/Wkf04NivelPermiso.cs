﻿using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf04NivelPermiso
{
    public decimal Wkf04Llave { get; set; }

    public decimal? Wkf03Llave { get; set; }

    public decimal? Wkf05Llave { get; set; }

    public int? Wkf04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Wkf03Nivel? Wkf03LlaveNavigation { get; set; }

    public virtual Wkf05TipoPermiso? Wkf05LlaveNavigation { get; set; }
}
