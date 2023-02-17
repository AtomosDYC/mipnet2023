using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Eml01BitacoraEmailUsuario
{
    public decimal Eml01Llave { get; set; }

    public decimal? Eml02Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public DateTime? Eml01Envio { get; set; }

    public string? Eml01De { get; set; }

    public string? Eml01Para { get; set; }

    public string? Eml01Asunto { get; set; }

    public string? Eml01Contenido { get; set; }

    public string? Eml01Text { get; set; }

    public decimal? Eml04Llave { get; set; }

    public decimal? Eml01Activo { get; set; }

    public decimal? Eml01MailPadre { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Eml02MailBase? Eml02LlaveNavigation { get; set; }

    public virtual Eml04ImportanciaMail? Eml04LlaveNavigation { get; set; }

    public virtual ICollection<Eml05ArchivoMail> Eml05ArchivoMails { get; } = new List<Eml05ArchivoMail>();

    public virtual ICollection<Frm02Formulario> Frm02Formularios { get; } = new List<Frm02Formulario>();

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }
}
