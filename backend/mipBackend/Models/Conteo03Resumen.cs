using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo03Resumen
{
    public int Conteo03llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? esp01llave { get; set; }

    public int? Temp02llave { get; set; }

    public int? Conteo03Estado { get; set; }

    public virtual cnt08Segmentacion? cnt08llaveNavigation { get; set; }

    public virtual ICollection<Sercltemp01ServiciosClientesTemporal> Sercltemp01ServiciosClientesTemporals { get; } = new List<Sercltemp01ServiciosClientesTemporal>();
}
