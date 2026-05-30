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

}
