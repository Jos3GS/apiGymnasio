using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTamano
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int Espacio { get; set; }

    public bool? Activo { get; set; }

}
