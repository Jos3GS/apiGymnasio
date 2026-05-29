using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTipoDocumento
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();

    public virtual ICollection<TblSocio> TblSocios { get; set; } = new List<TblSocio>();
}
