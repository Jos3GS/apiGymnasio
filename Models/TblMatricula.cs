using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblMatricula
{
    public int Codigo { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public double MontoPagado { get; set; }

    public bool? Recurrente { get; set; }

    public int UsuarioCrea { get; set; }

    public int? FkSocio { get; set; }

    public int? FkFormaPago { get; set; }

}
