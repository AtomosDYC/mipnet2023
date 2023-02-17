using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Conteo03Resuman
{
    public decimal Conteo03Llave { get; set; }

    public decimal? Cnt08Llave { get; set; }

    public decimal? Esp01Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public int? Conteo03Estado { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual ICollection<Sercltemp01ServiciosClientesTemporal> Sercltemp01ServiciosClientesTemporals { get; } = new List<Sercltemp01ServiciosClientesTemporal>();
}
