using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Transacciones
{
    public int TransaccionId { get; set; }

    public double? Monto { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public bool? EsAprobado { get; set; }

    public int PedidosPedidoId { get; set; }

    public virtual Pedidos oPedido { get; set; } = null!;
}
