using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMembresia
    {
        private readonly BdgymnasioContext oGym;

        public TblMembresium? tblMembresia { get; set; }
        public string? message { get; set; }

        public clsOpeMembresia(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblMembresium> ListarMembresias()
        {
            return oGym.TblMembresia.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblMembresium? ListarMembresias(int codigo)
        {
            try
            {
                var temp = oGym.TblMembresia.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la membresía para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la membresía, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarMembresia()
        {
            try
            {
                if (tblMembresia == null)
                {
                    message = "No se ha asignado una membresía para agregar";
                    return false;
                }
                var temp = oGym.TblMembresia.FirstOrDefault(x => x.Nombre.ToLower() == tblMembresia.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una membresía con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMembresia.Add(tblMembresia);
                oGym.SaveChanges();
                message = "Membresía agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la membresía, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarMembresia()
        {
            try
            {
                if (tblMembresia == null)
                {
                    message = "No se ha asignado una membresía para modificar";
                    return false;
                }
                var temp = oGym.TblMembresia.FirstOrDefault(x => x.Codigo == tblMembresia.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la membresía para modificar, Reintentalo nuevamente.";
                    return false;
                }
                var duplicado = oGym.TblMembresia.FirstOrDefault(x => x.Nombre.ToLower() == tblMembresia.Nombre.ToLower() && x.Codigo != tblMembresia.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe una membresía con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }

                temp.Nombre = tblMembresia.Nombre;
                temp.Activo = tblMembresia.Activo;
                oGym.SaveChanges();
                message = "Membresía modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la membresía, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarMembresia()
        {
            try
            {
                if (tblMembresia == null)
                {
                    message = "No se ha asignado una membresía para eliminar";
                    return false;
                }
                var temp = oGym.TblMembresia.FirstOrDefault(x => x.Codigo == tblMembresia.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la membresía para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMembresia.Remove(temp);
                oGym.SaveChanges();
                message = "Membresía eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la membresía, Reintentalo nuevamente.";
                return false;
            }
        }

    }
}
