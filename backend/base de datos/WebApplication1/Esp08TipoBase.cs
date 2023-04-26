﻿using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Esp08TipoBase
{
    public int Esp08Llave { get; set; }

    public string? Esp08Nombre { get; set; }

    public string? Esp08Descripcion { get; set; }

    public int? Esp08Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp03EspecieBase> Esp03EspecieBases { get; set; } = new List<Esp03EspecieBase>();

    public virtual ICollection<Obsc01ObservacionCampo> Obsc01ObservacionCampos { get; set; } = new List<Obsc01ObservacionCampo>();
}
