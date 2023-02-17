using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Conteo04ResumenSag
{
    public decimal Conteo04Llave { get; set; }

    public decimal? Sist03Llave { get; set; }

    public decimal? Esp01Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public decimal? Conteo04Estado { get; set; }

    public virtual Esp01Especy? Esp01LlaveNavigation { get; set; }

    public virtual Sist03Comuna? Sist03LlaveNavigation { get; set; }

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }
}
