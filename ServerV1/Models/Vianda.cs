using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Vianda
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? DetallesViandaDetalleId { get; set; }

    public int DetallesPedidoDetallePedidoId { get; set; }

    public virtual DetallesPedido oDetallePedido { get; set; } = null!;

    public virtual DetallesVianda? oDetalleVianda { get; set; }
}
