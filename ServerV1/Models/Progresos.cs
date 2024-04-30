using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Progresos
{
    public int ProgresoId { get; set; }

    public DateTime? FechaProgreso { get; set; }

    public double? Peso { get; set; }

    public string? Comentario { get; set; }

    public int ClienteUsuarioId { get; set; }

    public virtual Cliente ClienteUsuario { get; set; } = null!;
}
