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

    public virtual TblEstado? FkEstadoNavigation { get; set; }

    public virtual TblMembresium? FkMembresiaNavigation { get; set; }

    public virtual TblProfesion? FkProfesionNavigation { get; set; }

    public virtual TblTipoDocumento? FkTipoDocumentoNavigation { get; set; }

    public virtual ICollection<TblDireccionSocio> TblDireccionSocios { get; set; } = new List<TblDireccionSocio>();

    public virtual ICollection<TblMatricula> TblMatriculas { get; set; } = new List<TblMatricula>();

    public virtual ICollection<TblTelSocioSocio> TblTelSocioSocios { get; set; } = new List<TblTelSocioSocio>();
}
