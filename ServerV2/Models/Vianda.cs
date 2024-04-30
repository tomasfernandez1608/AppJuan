using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Vianda
{
    public int ViandaId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? DetallesViandaId { get; set; }

    public int DetallePedidoId { get; set; }

    public virtual DetallesPedido oDetallePedido { get; set; } = null!;

    public virtual DetallesVianda? oDetallesVianda { get; set; }
}
