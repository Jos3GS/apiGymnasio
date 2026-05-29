using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblMarca
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contacto { get; set; } = null!;

}
