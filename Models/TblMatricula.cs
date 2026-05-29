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

    public virtual TblFormaPago? FkFormaPagoNavigation { get; set; }

    public virtual TblSocio? FkSocioNavigation { get; set; }

    public virtual ICollection<TblDetalleMatricula> TblDetalleMatriculas { get; set; } = new List<TblDetalleMatricula>();
}
