using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Trp03Geocordenada
{
    public decimal Trp01Llave { get; set; }

    public decimal Temp02Llave { get; set; }

    public string X { get; set; } = null!;

    public string Y { get; set; } = null!;
}
