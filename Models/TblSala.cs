using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblSala
{
    public int Numero { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int Capacidad { get; set; }

    public bool? Activo { get; set; }

    public int? FkTamano { get; set; }

    public int? FkTipoSala { get; set; }

    public virtual TblTamano? FkTamanoNavigation { get; set; }

    public virtual TblTipoSala? FkTipoSalaNavigation { get; set; }

    public virtual ICollection<TblClase> TblClases { get; set; } = new List<TblClase>();

    public virtual ICollection<TblRecurso> TblRecursos { get; set; } = new List<TblRecurso>();
}
