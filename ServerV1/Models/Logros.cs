using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Logros
{
    public int? CantidadObtenidos { get; set; }

    public int? MesesLealtad { get; set; }

    public int? ViandasAdquiridas { get; set; }

    public int ClienteUsuarioId { get; set; }

    public virtual Cliente oClienteUsuario { get; set; } = null!;
}
