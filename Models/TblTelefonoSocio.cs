using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTelefonoSocio
{
    public int Codigo { get; set; }

    public int Numero { get; set; }

    public bool? Principal { get; set; }

    public bool? Activo { get; set; }

    public int? FkTipoTelefono { get; set; }
}
