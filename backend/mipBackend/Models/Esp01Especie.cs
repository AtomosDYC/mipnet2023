using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp01Especie
{
    public int Esp01Llave { get; set; }

    public int? Esp03Llave { get; set; }

    public int? Esp04Llave { get; set; }

    public int? Esp01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Esp02TemporadaEspecie> Esp02TemporadaEspecies { get; } = new List<Esp02TemporadaEspecie>();

    public virtual Esp03EspecieBase? Esp03LlaveNavigation { get; set; }

    public virtual Esp04EstadoDanio? Esp04LlaveNavigation { get; set; }

    public virtual ICollection<Esp05Umbral> Esp05Umbrals { get; } = new List<Esp05Umbral>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; } = new List<Trp01Trampa>();
}
