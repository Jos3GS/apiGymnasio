using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTipoTelefono
{
    public int Codigo { get; set; }

    public string Tipo { get; set; } = null!;

    public bool? Activo { get; set; }

}
