using System;
using System.Collections.Generic;

namespace ServerV1.Models;

public partial class Admin
{
    public int UsuarioId { get; set; }

    public virtual Usuarios Usuario { get; set; } = null!;
}
