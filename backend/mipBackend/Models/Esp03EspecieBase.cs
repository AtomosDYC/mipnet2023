using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp03especieBase
{
    public int esp03llave { get; set; }

    public string? esp03nombre { get; set; }

    public string? esp03descripcion { get; set; }

    public int? esp08llave { get; set; }

    public string? esp03ImgGrande { get; set; }

    public string? esp03ImgPequenia { get; set; }

    public int? esp03Union { get; set; }

    public string? esp03EstadoRegistro { get; set; }

    public int? esp03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<esp01especie> esp01especies { get; } = new List<esp01especie>();

    public virtual ICollection<esp07Union> esp07Unions { get; } = new List<esp07Union>();

    public virtual esp08TipoBase? esp08llaveNavigation { get; set; }
}
