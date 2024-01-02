using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sercl01ServiciosCliente
{
    public int Sercl01llave { get; set; }

    public int? cnt19llave { get; set; }

    public int? Serv01llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? Temp02llave { get; set; }

    public int? esp03llave { get; set; }

    public int? esp04llave { get; set; }

    public int? esp08llave { get; set; }

    public int? sist04llave { get; set; }

    public int? sist03llave { get; set; }

    public int? Sercl01TipoGrafico { get; set; }

    public int? Conteo03llave { get; set; }

    public int? Sercl01Costo { get; set; }

    public int? Sercl01Cantidad { get; set; }

    public virtual ICollection<Sercl02MuestreoFruta> Sercl02MuestreoFruta { get; } = new List<Sercl02MuestreoFruta>();
}
