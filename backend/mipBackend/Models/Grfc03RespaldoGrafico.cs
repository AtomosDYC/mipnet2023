using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Grfc03RespaldoGrafico
{
    public int Grfc03llave { get; set; }

    public int? Temp02llave { get; set; }

    public int? esp03llave { get; set; }

    public int? cnt08llave { get; set; }

    public DateTime? Grfc03UltimaFecha { get; set; }

    public string? Grfc03XmlDatos { get; set; }

    public int? Grfc03Estado { get; set; }
}
