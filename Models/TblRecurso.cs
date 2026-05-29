using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblRecurso
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaCompra { get; set; }

    public bool? Activo { get; set; }

    public int UsuarioCrea { get; set; }

    public int? FkSala { get; set; }

    public int? FkEstadoConservacion { get; set; }

    public int? FkMarca { get; set; }

    public virtual TblEstadoConservacion? FkEstadoConservacionNavigation { get; set; }

    public virtual TblMarca? FkMarcaNavigation { get; set; }

    public virtual TblSala? FkSalaNavigation { get; set; }
}
