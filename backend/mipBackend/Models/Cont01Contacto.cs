﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cont01Contacto
{
    public int Cont01Llave { get; set; }

    public int? Cont02Llave { get; set; }

    public int? Cont01Titulo { get; set; }

    public string? Cont01Nombre { get; set; }

    public string? Cont01Apellido { get; set; }

    public string? Cont01Email { get; set; }

    public string? Cont01Direccion { get; set; }

    public string? Cont01Telefono { get; set; }

    public string? Cont01PeticionContacto { get; set; }

    public string? Cont01CodigoValidacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Cont02TipoContacto? Cont02LlaveNavigation { get; set; }
}
