using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblCiudad
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblDireccionEmpleado> TblDireccionEmpleados { get; set; } = new List<TblDireccionEmpleado>();

    public virtual ICollection<TblDireccionSocio> TblDireccionSocios { get; set; } = new List<TblDireccionSocio>();
}
