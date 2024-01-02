using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp01especie
{
    public int esp01llave { get; set; }

    public int esp03llave { get; set; }

    public int? esp04llave { get; set; }

    public int? esp01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<esp02Temporadaespecie> esp02Temporadaespecies { get; } = new List<esp02Temporadaespecie>();

    public virtual esp03especieBase? esp03llaveNavigation { get; set; }

    public virtual esp04EstadoDanio? esp04llaveNavigation { get; set; }

    public virtual ICollection<esp05Umbral> esp05Umbrals { get; } = new List<esp05Umbral>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; } = new List<Trp01Trampa>();
}
