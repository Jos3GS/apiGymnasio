using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTamano
    {
        private readonly BdgymnasioContext oGym;
        public TblTamano? tblTamano { get; set; }
        public string? message { get; set; }

        public clsOpeTamano(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTamano> ListarTamano()
        {
            return oGym.TblTamanos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public bool agregarTamano()
        {
            try
            {
                if (tblTamano == null)
                {
                    message = "No se ha asignado un tamaño para agregar";
                    return false;
                }
                var temp = oGym.TblTamanos.FirstOrDefault(x => x.Nombre.ToLower() == tblTamano.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un tamaño con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTamanos.Add(tblTamano);
                oGym.SaveChanges();
                message = "Tamaño agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el tamaño, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarTamano()
        {
            try
            {
                if (tblTamano == null)
                {
                    message = "No se ha asignado un tamaño para modificar";
                    return false;
                }
                var temp = oGym.TblTamanos.FirstOrDefault(x => x.Codigo == tblTamano.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tamaño a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblTamanos.FirstOrDefault(x => x.Nombre.ToLower() == tblTamano.Nombre.ToLower() && x.Codigo != tblTamano.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un tamaño con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTamanos.Update(tblTamano);
                oGym.SaveChanges();
                message = "Tamaño modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el tamaño, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarTamano()
        {
            try
            {
                if (tblTamano == null)
                {
                    message = "No se ha asignado un tamaño para eliminar";
                    return false;
                }
                var temp = oGym.TblTamanos.FirstOrDefault(x => x.Codigo == tblTamano.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tamaño a eliminar, Reintentalo nuevamente.";
                    return false;
                }

                oGym.TblTamanos.Remove(temp);
                oGym.SaveChanges();
                message = "Tamaño eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el tamaño, Reintentalo nuevamente.";
                return false;
            }


        }
    }
}
