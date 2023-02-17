using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Esp01Especy
{
    public decimal Esp01Llave { get; set; }

    public decimal? Esp03Llave { get; set; }

    public decimal? Esp04Llave { get; set; }

    public int? Esp01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Esp02TemporadaEspecie> Esp02TemporadaEspecies { get; } = new List<Esp02TemporadaEspecie>();

    public virtual Esp03EspecieBase? Esp03LlaveNavigation { get; set; }

    public virtual Esp04EstadoDanio? Esp04LlaveNavigation { get; set; }

    public virtual ICollection<Esp05Umbral> Esp05Umbrals { get; } = new List<Esp05Umbral>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; } = new List<Trp01Trampa>();
}
