using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblSala
{
    public int Numero { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int Capacidad { get; set; }

    public bool? Activo { get; set; }

    public int? FkTamano { get; set; }

    public int? FkTipoSala { get; set; }
}
