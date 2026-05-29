using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblUsuario
{
    public int Codigo { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
