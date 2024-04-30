using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Profesionales
{
    public int UsuarioId { get; set; }

    public int? ConsultasRealizadas { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Agenda> oAgenda { get; set; } = new List<Agenda>();

    public virtual Usuarios Usuario { get; set; } = null!;
}
