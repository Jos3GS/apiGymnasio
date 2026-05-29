using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblClase
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Horario { get; set; } = null!;

    public bool? Activo { get; set; }

    public int UsuarioCrea { get; set; }

    public int? FkMonitor { get; set; }

    public int? FkSala { get; set; }

    public int? FkEspecialidad { get; set; }

    public virtual TblEspecialidad? FkEspecialidadNavigation { get; set; }

    public virtual TblMonitor? FkMonitorNavigation { get; set; }

    public virtual TblSala? FkSalaNavigation { get; set; }

    public virtual ICollection<TblDetalleMatricula> TblDetalleMatriculas { get; set; } = new List<TblDetalleMatricula>();
}
