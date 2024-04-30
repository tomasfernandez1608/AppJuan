using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? FranjaHoraria { get; set; }

    public string? MetodoPago { get; set; }

    public double? Total { get; set; }

    public bool? EstadoPago { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;

    public virtual DetallesPedido? oDetallesPedido { get; set; }

    public virtual Transaccion? oTransaccion { get; set; }
}
