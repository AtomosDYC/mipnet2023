using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Secu11TipoPerfil
{
    public decimal Prf02Llave { get; set; }

    public string? Prf02Nombre { get; set; }

    public string? Prf02Descripcion { get; set; }

    public DateTime? Fechaactulizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }
}
