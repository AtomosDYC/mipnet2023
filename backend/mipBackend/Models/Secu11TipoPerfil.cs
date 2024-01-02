using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu11Tipoperfil
{
    public int prf02llave { get; set; }

    public string? prf02nombre { get; set; }

    public string? prf02descripcion { get; set; }

    public DateTime? Fechaactulizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }
}
