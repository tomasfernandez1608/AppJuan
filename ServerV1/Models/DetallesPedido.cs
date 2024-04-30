using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class DetallesPedido
{
    public int DetallePedidoId { get; set; }

    public int? Cantidad { get; set; }

    public double? Precio { get; set; }

    public int PedidosPedidoId { get; set; }

    public virtual Pedidos oPedido { get; set; } = null!;

    public virtual ICollection<Vianda> oVianda { get; set; } = new List<Vianda>();
}
