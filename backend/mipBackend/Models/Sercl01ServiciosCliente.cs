using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sercl01ServiciosCliente
{
    public int Sercl01Llave { get; set; }

    public int? Cnt19Llave { get; set; }

    public int? Serv01Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public int? Esp03Llave { get; set; }

    public int? Esp04Llave { get; set; }

    public int? Esp08Llave { get; set; }

    public int? sist04llave { get; set; }

    public int? Sist03Llave { get; set; }

    public int? Sercl01TipoGrafico { get; set; }

    public int? Conteo03Llave { get; set; }

    public int? Sercl01Costo { get; set; }

    public int? Sercl01Cantidad { get; set; }

    public virtual ICollection<Sercl02MuestreoFruta> Sercl02MuestreoFruta { get; } = new List<Sercl02MuestreoFruta>();
}
