using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sercltemp01ServiciosClientesTemporal
{
    public int Sercltemp01llave { get; set; }

    public int? Sercltemp01TipoGrafico { get; set; }

    public int? cntemp01llave { get; set; }

    public int? cntemp02llave { get; set; }

    public int? Conteo03llave { get; set; }

    public int? Temp02llave { get; set; }

    public virtual Conteo03Resumen? Conteo03llaveNavigation { get; set; }
}
