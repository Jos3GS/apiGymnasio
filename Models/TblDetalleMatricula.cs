using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblDetalleMatricula
{
    public int Codigo { get; set; }

    public int? FkClase { get; set; }

    public int? FkMatricula { get; set; }
}
