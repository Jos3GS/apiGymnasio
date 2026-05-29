using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblMembresium
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblSocio> TblSocios { get; set; } = new List<TblSocio>();
}
