using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Eml02MailBase
{
    public int Eml02Llave { get; set; }

    public int? Eml03Llave { get; set; }

    public string? Eml02CodigoLlamado { get; set; }

    public string? Eml02Descripcion { get; set; }

    public string? Eml02Asunto { get; set; }

    public string? Eml02ContenidoHtml { get; set; }

    public string? Eml02ContenidoText { get; set; }

    public int? Eml02Activo { get; set; }

    public int? Eml04Llave { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; set; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual Eml03TipoMailAccione? Eml03LlaveNavigation { get; set; }

    public virtual Eml04ImportanciaMail? Eml04LlaveNavigation { get; set; }
}
