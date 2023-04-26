﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Prf01Perfile
{
    public int Prf01Llave { get; set; }

    public int? Prf05Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public int? Prf01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Prf05TipoAsignacionUsuario? Prf05LlaveNavigation { get; set; }

    public virtual ICollection<Prf06PermisosUsuario> Prf06PermisosUsuarios { get; set; } = new List<Prf06PermisosUsuario>();

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }

    public virtual ICollection<Prf03Plantilla> Prf03Llaves { get; set; } = new List<Prf03Plantilla>();
}
