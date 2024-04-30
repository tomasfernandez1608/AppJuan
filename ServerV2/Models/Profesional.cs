using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Profesional
{
    public int ProfesionalId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Rol { get; set; }

    public int? ConsultasRealizadas { get; set; }

    public virtual ICollection<Agenda> oAgenda { get; set; } = new List<Agenda>();
}
