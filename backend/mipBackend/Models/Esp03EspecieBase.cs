using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp03EspecieBase
{
    public int Esp03Llave { get; set; }

    public string? Esp03Nombre { get; set; }

    public string? Esp03Descripcion { get; set; }

    public int? Esp08Llave { get; set; }

    public string? Esp03ImgGrande { get; set; }

    public string? Esp03ImgPequenia { get; set; }

    public int? Esp03Union { get; set; }

    public string? Esp03EstadoRegistro { get; set; }

    public int? Esp03Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp01Especie> Esp01Especies { get; } = new List<Esp01Especie>();

    public virtual ICollection<Esp07Union> Esp07Unions { get; } = new List<Esp07Union>();

    public virtual Esp08TipoBase? Esp08LlaveNavigation { get; set; }
}
