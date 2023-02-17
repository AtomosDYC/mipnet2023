using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Eml03TipoMailAccione
{
    public decimal Eml03Llave { get; set; }

    public string? Eml03Nombre { get; set; }

    public string? Eml03Descripcion { get; set; }

    public int? Eml03Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Eml02MailBase> Eml02MailBases { get; } = new List<Eml02MailBase>();
}
