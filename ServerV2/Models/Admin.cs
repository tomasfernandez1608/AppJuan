using System;
using System.Collections.Generic;

namespace ServerV2.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
