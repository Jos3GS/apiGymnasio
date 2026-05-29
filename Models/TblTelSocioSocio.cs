using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTelSocioSocio
{
    public int Codigo { get; set; }

    public int? FkTelefonoSocio { get; set; }

    public int? FkSocio { get; set; }

    public virtual TblSocio? FkSocioNavigation { get; set; }

    public virtual TblTelefonoSocio? FkTelefonoSocioNavigation { get; set; }
}
