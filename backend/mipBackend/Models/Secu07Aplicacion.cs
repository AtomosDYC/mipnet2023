﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu07Aplicacion
{
    public Guid Secu07Llave { get; set; }

    public string? Secu07Nombre { get; set; }

    public string? Secu07Descripcion { get; set; }

    public string? Secu07Info { get; set; }

    public bool? Secu07Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Secu08UsuarioAplicacion> Secu08UsuarioAplicacions { get; } = new List<Secu08UsuarioAplicacion>();
}
