using System;
using System.Collections.Generic;

namespace apiGymnasio.Models;

public partial class TblTipoSala
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TblSala> TblSalas { get; set; } = new List<TblSala>();
}
