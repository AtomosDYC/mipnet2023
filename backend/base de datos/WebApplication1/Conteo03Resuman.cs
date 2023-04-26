using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Conteo03Resuman
{
    public int Conteo03Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public int? Conteo03Estado { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual ICollection<Sercltemp01ServiciosClientesTemporal> Sercltemp01ServiciosClientesTemporals { get; set; } = new List<Sercltemp01ServiciosClientesTemporal>();
}
