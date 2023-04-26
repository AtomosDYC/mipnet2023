using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Esp01Especy
{
    public int Esp01Llave { get; set; }

    public int? Esp03Llave { get; set; }

    public int? Esp04Llave { get; set; }

    public int? Esp01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; set; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Esp02TemporadaEspecie> Esp02TemporadaEspecies { get; set; } = new List<Esp02TemporadaEspecie>();

    public virtual Esp03EspecieBase? Esp03LlaveNavigation { get; set; }

    public virtual Esp04EstadoDanio? Esp04LlaveNavigation { get; set; }

    public virtual ICollection<Esp05Umbral> Esp05Umbrals { get; set; } = new List<Esp05Umbral>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; set; } = new List<Trp01Trampa>();
}
