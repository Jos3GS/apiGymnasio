using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblCargo
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
