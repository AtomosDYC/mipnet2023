using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo04ResumenSag
{
    public int Conteo04llave { get; set; }

    public int? sist03llave { get; set; }

    public int? esp01llave { get; set; }

    public int? Temp02llave { get; set; }

    public int? Conteo04Estado { get; set; }

    public virtual esp01especie? esp01llaveNavigation { get; set; }

    public virtual sist03Comuna? sist03llaveNavigation { get; set; }

    public virtual Temp02TemporadaBase? Temp02llaveNavigation { get; set; }
}
