using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Logro
{
    public int? CantidadObtenido { get; set; }

    public int? MesesLealtad { get; set; }

    public int? ViandasAdquirida { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;
}
