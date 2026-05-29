using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblEmpleado
{
    public int NumeroId { get; set; }

    public double Salario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int UsuarioCrea { get; set; }

    public int? FkTipoDocumento { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkCargo { get; set; }

    public int? FkTurno { get; set; }

    public int? FkEspecialidad { get; set; }

    public virtual TblCargo? FkCargoNavigation { get; set; }

    public virtual TblEspecialidad? FkEspecialidadNavigation { get; set; }

    public virtual TblTipoDocumento? FkTipoDocumentoNavigation { get; set; }

    public virtual TblTurno? FkTurnoNavigation { get; set; }

    public virtual TblUsuario? FkUsuarioNavigation { get; set; }

    public virtual ICollection<TblDireccionEmpleado> TblDireccionEmpleados { get; set; } = new List<TblDireccionEmpleado>();

    public virtual TblMonitor? TblMonitor { get; set; }

    public virtual ICollection<TblTelEmpleadoEmpleado> TblTelEmpleadoEmpleados { get; set; } = new List<TblTelEmpleadoEmpleado>();
}
