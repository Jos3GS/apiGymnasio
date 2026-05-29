using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTelEmpleadoEmpleado
{
    public int Codigo { get; set; }

    public int? FkTelefonoEmpleado { get; set; }

    public int? FkEmpleado { get; set; }

    public virtual TblEmpleado? FkEmpleadoNavigation { get; set; }

    public virtual TblTelefonoEmpleado? FkTelefonoEmpleadoNavigation { get; set; }
}
