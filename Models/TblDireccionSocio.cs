using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblDireccionSocio
{
    public int Codigo { get; set; }

    public string Direccion { get; set; } = null!;

    public bool? Activo { get; set; }

    public int? FkSocio { get; set; }

    public int? FkCiudad { get; set; }

}
