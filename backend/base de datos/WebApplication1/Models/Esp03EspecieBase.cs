using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp01Especy> Esp01Especies { get; set; } = new List<Esp01Especy>();

    public virtual ICollection<Esp07Union> Esp07Unions { get; set; } = new List<Esp07Union>();

    public virtual Esp08TipoBase? Esp08LlaveNavigation { get; set; }
}
