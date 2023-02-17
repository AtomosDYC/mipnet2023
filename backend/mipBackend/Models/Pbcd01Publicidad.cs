﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pbcd01Publicidad
{
    public int Pbcd01Llave { get; set; }

    public int? Pbcd02Llave { get; set; }

    public string? Pbcd01Objetico { get; set; }

    public string? Pbcd01FrasePrincipal { get; set; }

    public string? Pbcd01FraseSecundaria { get; set; }

    public string? Pbcd01SecuenciaHtml { get; set; }

    public string? Pbcd01ImagenNombre { get; set; }

    public string? Pbcd01Producto { get; set; }

    public string? Pbcd01Problema { get; set; }

    public int? Pbcd01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Pbcd02TipoPublicidad? Pbcd02LlaveNavigation { get; set; }

    public virtual ICollection<Pbcd03Programacion> Pbcd03Programacions { get; } = new List<Pbcd03Programacion>();
}
