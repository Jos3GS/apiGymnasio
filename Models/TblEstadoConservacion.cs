using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblEstadoConservacion
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<TblRecurso> TblRecursos { get; set; } = new List<TblRecurso>();
}
