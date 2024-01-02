using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Trp03Geocordenada
{
    public int Trp01llave { get; set; }

    public int Temp02llave { get; set; }

    public string X { get; set; } = null!;

    public string Y { get; set; } = null!;
}
