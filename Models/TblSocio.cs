using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblSocio
{
    public int NumeroId { get; set; }

    public DateOnly FechaAfiliacion { get; set; }

    public string? ObservacionMedica { get; set; }

    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int UsuarioCrea { get; set; }

    public int? FkProfesion { get; set; }

    public int? FkTipoDocumento { get; set; }

    public int? FkEstado { get; set; }

    public int? FkMembresia { get; set; }
}
