using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTurno
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
