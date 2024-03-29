﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Frm01TipoFormulario
{
    public int Frm01llave { get; set; }

    public string? Frm01nombre { get; set; }

    public int? Frm01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Frm02Formulario> Frm02Formularios { get; } = new List<Frm02Formulario>();
}
