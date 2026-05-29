using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblProfesion
{
    public int Codigo { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<TblSocio> TblSocios { get; set; } = new List<TblSocio>();
}
