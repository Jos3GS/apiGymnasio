using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblEspecialidad
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public int UsuarioCrea { get; set; }

    public virtual ICollection<TblClase> TblClases { get; set; } = new List<TblClase>();

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();

    public virtual ICollection<TblMonitor> TblMonitors { get; set; } = new List<TblMonitor>();
}
