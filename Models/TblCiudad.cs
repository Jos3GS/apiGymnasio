using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblCiudad
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }
}
