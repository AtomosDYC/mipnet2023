using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml01BitacoraEmailUsuario
{
    public int Eml01llave { get; set; }

    public int? Eml02llave { get; set; }

    public Guid? userid { get; set; }

    public DateTime? Eml01Envio { get; set; }

    public string? Eml01De { get; set; }

    public string? Eml01Para { get; set; }

    public string? Eml01Asunto { get; set; }

    public string? Eml01Contenido { get; set; }

    public string? Eml01Text { get; set; }

    public int? Eml04llave { get; set; }

    public int? Eml01activo { get; set; }

    public int? Eml01MailPadre { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Eml02MailBase? Eml02llaveNavigation { get; set; }

    public virtual Eml04ImportanciaMail? Eml04llaveNavigation { get; set; }

    public virtual ICollection<Eml05ArchivoMail> Eml05ArchivoMails { get; } = new List<Eml05ArchivoMail>();

    public virtual ICollection<Frm02Formulario> Frm02Formularios { get; } = new List<Frm02Formulario>();

    public virtual Secu02Usuario? useridNavigation { get; set; }
}
