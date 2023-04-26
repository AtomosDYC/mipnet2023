using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Ctt02TipoContrato
{
    public int Ctt02Llave { get; set; }

    public string? Ctt02Nombre { get; set; }

    public string? Ctt02Descripcion { get; set; }

    public int? Ctt02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Ctt01Contrato> Ctt01Contratos { get; set; } = new List<Ctt01Contrato>();
}
