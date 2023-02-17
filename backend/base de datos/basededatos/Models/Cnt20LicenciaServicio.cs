using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt20LicenciaServicio
{
    public decimal Cnt19Llave { get; set; }

    public decimal Serv01Llave { get; set; }

    public int? Cnt20Habilitaservicio { get; set; }

    public decimal? Cnt20Valor { get; set; }

    public virtual Cnt19LicenciaCliente Cnt19LlaveNavigation { get; set; } = null!;
}
