using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo03Resumen
{
    public int Conteo03Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public int? Conteo03Estado { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual ICollection<Sercltemp01ServiciosClientesTemporal> Sercltemp01ServiciosClientesTemporals { get; } = new List<Sercltemp01ServiciosClientesTemporal>();
}
