using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Sist03Comuna
{
    public decimal Sist03Llave { get; set; }

    public decimal? Sist04Llave { get; set; }

    public string? Sist03Nombre { get; set; }

    public string? Sist03Descripcion { get; set; }

    public int? Sist03Capital { get; set; }

    public int? Sist03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual Sist04Region? Sist04LlaveNavigation { get; set; }

    public virtual ICollection<Sist02Zona> Sist02Llaves { get; } = new List<Sist02Zona>();
}
