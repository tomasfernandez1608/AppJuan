using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Transaccion
{
    public int TransaccionId { get; set; }

    public double? Monto { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public bool? EsAprobado { get; set; }

    public int PedidoId { get; set; }

    public virtual Pedido oPedido { get; set; } = null!;
}
