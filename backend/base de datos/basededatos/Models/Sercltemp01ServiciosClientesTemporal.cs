using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Sercltemp01ServiciosClientesTemporal
{
    public decimal Sercltemp01Llave { get; set; }

    public decimal? Sercltemp01TipoGrafico { get; set; }

    public decimal? Cntemp01Llave { get; set; }

    public decimal? Cntemp02Llave { get; set; }

    public decimal? Conteo03Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public virtual Conteo03Resuman? Conteo03LlaveNavigation { get; set; }
}
