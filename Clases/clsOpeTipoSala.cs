using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoSala
    {
        private readonly BdgymnasioContext oGym;
        public TblTipoSala? tblTipoSala { get; set; }
        public string? message { get; set; }

        public clsOpeTipoSala(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoSala> ListarTipoSala()
        {
            return oGym.TblTipoSalas.OrderBy(x => x.Nombre).ToList();
        }

        public bool agregarTipoSala()
        {
            try
            {
                if (tblTipoSala == null)
                {
                    message = "No se ha asignado un tipo de sala para agregar";
                    return false;
                }
                var temp = oGym.TblTipoSalas.FirstOrDefault(x => x.Nombre.ToLower() == tblTipoSala.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un tipo de sala con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoSalas.Add(tblTipoSala);
                oGym.SaveChanges();
                message = "Tipo de sala agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el tipo de sala, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarTipoSala()
        {
            try
            {
                if (tblTipoSala == null)
                {
                    message = "No se ha asignado un tipo de sala para modificar";
                    return false;
                }
                var temp = oGym.TblTipoSalas.FirstOrDefault(x => x.Codigo == tblTipoSala.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de sala a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblTipoSalas.FirstOrDefault(x => x.Nombre.ToLower() == tblTipoSala.Nombre.ToLower() && x.Codigo != tblTipoSala.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un tipo de sala con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoSalas.Update(tblTipoSala);
                oGym.SaveChanges();
                message = "Tipo de sala modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el tipo de sala, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarTipoSala()
        {
            try
            {
                if (tblTipoSala == null)
                {
                    message = "No se ha asignado un tipo de sala para eliminar";
                    return false;
                }
                var temp = oGym.TblTipoSalas.FirstOrDefault(x => x.Codigo == tblTipoSala.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de sala a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoSalas.Remove(tblTipoSala);
                oGym.SaveChanges();
                message = "Tipo de sala eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el tipo de sala, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
