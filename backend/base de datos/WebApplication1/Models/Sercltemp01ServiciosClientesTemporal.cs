using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sercltemp01ServiciosClientesTemporal
{
    public int Sercltemp01Llave { get; set; }

    public int? Sercltemp01TipoGrafico { get; set; }

    public int? Cntemp01Llave { get; set; }

    public int? Cntemp02Llave { get; set; }

    public int? Conteo03Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public virtual Conteo03Resuman? Conteo03LlaveNavigation { get; set; }
}
