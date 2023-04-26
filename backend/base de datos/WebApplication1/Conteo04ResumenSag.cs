using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Conteo04ResumenSag
{
    public int Conteo04Llave { get; set; }

    public int? Sist03Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public int? Conteo04Estado { get; set; }

    public virtual Esp01Especy? Esp01LlaveNavigation { get; set; }

    public virtual Sist03Comuna? Sist03LlaveNavigation { get; set; }

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }
}
