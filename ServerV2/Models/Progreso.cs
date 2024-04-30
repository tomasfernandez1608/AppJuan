using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Progreso
{
    public int ProgresoId { get; set; }

    public DateTime? FechaProgreso { get; set; }

    public double? Peso { get; set; }

    public string? Comentario { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente oCliente { get; set; } = null!;
}
