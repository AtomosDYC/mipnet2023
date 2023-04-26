using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Esp07Union
{
    public int Esp03Llave { get; set; }

    public int Esp03LlaveUnion { get; set; }

    public int Esp07Llave { get; set; }

    public virtual Esp03EspecieBase Esp03LlaveNavigation { get; set; } = null!;
}
