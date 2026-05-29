using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblDireccionEmpleado
{
    public int Codigo { get; set; }

    public string Direccion { get; set; } = null!;

    public bool? Activo { get; set; }

    public int? FkEmpleado { get; set; }

    public int? FkCiudad { get; set; }

    public virtual TblCiudad? FkCiudadNavigation { get; set; }

    public virtual TblEmpleado? FkEmpleadoNavigation { get; set; }
}
