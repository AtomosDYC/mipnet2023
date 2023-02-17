using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu11TipoPerfil
{
    public int Prf02Llave { get; set; }

    public string? Prf02Nombre { get; set; }

    public string? Prf02Descripcion { get; set; }

    public DateTime? Fechaactulizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }
}
