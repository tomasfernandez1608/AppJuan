using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class DetallesPedido
{
    public int DetallePedidoId { get; set; }

    public int? Cantidad { get; set; }

    public double? Precio { get; set; }

    public int PedidoId { get; set; }

    public virtual Pedido oPedido { get; set; } = null!;

    public virtual ICollection<Vianda> oVianda { get; set; } = new List<Vianda>();
}
