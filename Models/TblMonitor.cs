using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblMonitor
{
    public int NumeroId { get; set; }

    public string? Experiencia { get; set; }

    public string? Titulacion { get; set; }

    public int? FkEspecialidad { get; set; }

}
