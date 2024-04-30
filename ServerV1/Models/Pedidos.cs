using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Pedidos
{
    public int PedidoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? FranjaHoraria { get; set; }

    public string? MetodoPago { get; set; }

    public double? Total { get; set; }

    public bool? EstadoPago { get; set; }

    public int UsuariosUsuarioId { get; set; }

    public virtual DetallesPedido? oDetallesPedido { get; set; }

    public virtual Transacciones? oTransacciones { get; set; }

    public virtual Usuarios oUsuarios { get; set; } = null!;
}
