using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Pbcd01Publicidad
{
    public int Pbcd01Llave { get; set; }

    public int? Pbcd02Llave { get; set; }

    public string? Pbcd01Objetico { get; set; }

    public string? Pbcd01FrasePrincipal { get; set; }

    public string? Pbcd01FraseSecundaria { get; set; }

    public string? Pbcd01SecuenciaHtml { get; set; }

    public string? Pbcd01ImagenNombre { get; set; }

    public string? Pbcd01Producto { get; set; }

    public string? Pbcd01Problema { get; set; }

    public int? Pbcd01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Pbcd02TipoPublicidad? Pbcd02LlaveNavigation { get; set; }

    public virtual ICollection<Pbcd03Programacion> Pbcd03Programacions { get; set; } = new List<Pbcd03Programacion>();
}
