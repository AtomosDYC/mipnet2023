﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu01Rol
{
    public Guid Secu01Llave { get; set; }

    public string? Secu01Nombre { get; set; }

    public string? Secu01Descripcion { get; set; }

    public int? Secu01Orden { get; set; }

    public string? Secu01Info { get; set; }

    public bool? Secu01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Secu06UsuarioRol> Secu06UsuarioRols { get; } = new List<Secu06UsuarioRol>();
}
