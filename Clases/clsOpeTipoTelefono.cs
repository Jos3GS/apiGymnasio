using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoTelefono
    {
        private readonly BdgymnasioContext oGym;
        public TblTipoTelefono? tblTipoTelefono { get; set; }
        public string? message { get; set; }

        public clsOpeTipoTelefono(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoTelefono> ListarTipoTelefono()
        {
            return oGym.TblTipoTelefonos.OrderBy(x => x.Tipo).ToList();
        }

        public TblTipoTelefono? ListarTipoTelefono(int codigo)
        {
            try
            {
                var temp = oGym.TblTipoTelefonos.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el tipo de teléfono para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el tipo de teléfono, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarTipoTelefono()
        {
            try
            {
                if (tblTipoTelefono == null)
                {
                    message = "No se ha asignado un tipo de teléfono para agregar";
                    return false;
                }
                var temp = oGym.TblTipoTelefonos.FirstOrDefault(x => x.Tipo.ToLower() == tblTipoTelefono.Tipo.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un tipo de teléfono con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoTelefonos.Add(tblTipoTelefono);
                oGym.SaveChanges();
                message = "Tipo de teléfono agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el tipo de teléfono, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool modificarTipoTelefono()
        {
            try
            {
                if (tblTipoTelefono == null)
                {
                    message = "No se ha asignado un tipo de teléfono para modificar";
                    return false;
                }
                var temp = oGym.TblTipoTelefonos.FirstOrDefault(x => x.Codigo == tblTipoTelefono.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de teléfono a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblTipoTelefonos.FirstOrDefault(x => x.Tipo.ToLower() == tblTipoTelefono.Tipo.ToLower() && x.Codigo != tblTipoTelefono.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un tipo de teléfono con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoTelefonos.Update(tblTipoTelefono);
                oGym.SaveChanges();
                message = "Tipo de teléfono modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el tipo de teléfono, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarTipoTelefono()
        {
            try
            {
                if (tblTipoTelefono == null)
                {
                    message = "No se ha asignado un tipo de teléfono para eliminar";
                    return false;
                }
                var temp = oGym.TblTipoTelefonos.FirstOrDefault(x => x.Codigo == tblTipoTelefono.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de teléfono a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoTelefonos.Remove(tblTipoTelefono);
                oGym.SaveChanges();
                message = "Tipo de teléfono eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el tipo de teléfono, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
