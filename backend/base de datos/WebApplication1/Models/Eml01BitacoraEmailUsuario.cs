using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Eml01BitacoraEmailUsuario
{
    public int Eml01Llave { get; set; }

    public int? Eml02Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public DateTime? Eml01Envio { get; set; }

    public string? Eml01De { get; set; }

    public string? Eml01Para { get; set; }

    public string? Eml01Asunto { get; set; }

    public string? Eml01Contenido { get; set; }

    public string? Eml01Text { get; set; }

    public int? Eml04Llave { get; set; }

    public int? Eml01Activo { get; set; }

    public int? Eml01MailPadre { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Eml02MailBase? Eml02LlaveNavigation { get; set; }

    public virtual Eml04ImportanciaMail? Eml04LlaveNavigation { get; set; }

    public virtual ICollection<Eml05ArchivoMail> Eml05ArchivoMails { get; set; } = new List<Eml05ArchivoMail>();

    public virtual ICollection<Frm02Formulario> Frm02Formularios { get; set; } = new List<Frm02Formulario>();

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }
}
