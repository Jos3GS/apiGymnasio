using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEstadoConservacion
    {
        private readonly BdgymnasioContext oGym;
        public TblEstadoConservacion? tblEstadoConservacion { get; set; }
        public string? message { get; set; }

        public clsOpeEstadoConservacion(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEstadoConservacion> ListarEstadoConservacion()
        {
            return oGym.TblEstadoConservacions.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblEstadoConservacion? ListarEstadoConservacion(int codigo)
        {
            try
            {
                var temp = oGym.TblEstadoConservacions.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado de conservación, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el estado de conservación, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarEstadoConservacion()
        {
            try
            {
                if (tblEstadoConservacion == null)
                {
                    message = "No se ha asignado un estado de conservación para agregar";
                    return false;
                }
                var temp = oGym.TblEstadoConservacions.FirstOrDefault(x => x.Nombre.ToLower() == tblEstadoConservacion.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un estado de conservación con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEstadoConservacions.Add(tblEstadoConservacion);
                oGym.SaveChanges();
                message = "Estado de conservación agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el estado de conservación, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarEstadoConservacion()
        {
            try
            {
                if (tblEstadoConservacion == null)
                {
                    message = "No se ha asignado un estado de conservación para modificar";
                    return false;
                }
                var temp = oGym.TblEstadoConservacions.FirstOrDefault(x => x.Codigo == tblEstadoConservacion.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado de conservación para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblEstadoConservacions.FirstOrDefault(x => x.Nombre.ToLower() == tblEstadoConservacion.Nombre.ToLower() && x.Codigo != tblEstadoConservacion.Codigo);
                if (temp == null)
                {
                    message = "Ya existe un estado de conservación con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEstadoConservacions.Update(tblEstadoConservacion);
                oGym.SaveChanges();
                message = "Estado de conservación modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el estado de conservación, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarEstadoConservacion()
        {
            try
            {
                if (tblEstadoConservacion == null)
                {
                    message = "No se ha asignado un estado de conservación para eliminar";
                    return false;
                }
                var temp = oGym.TblEstadoConservacions.FirstOrDefault(x => x.Codigo == tblEstadoConservacion.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado de conservación para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEstadoConservacions.Remove(temp);
                oGym.SaveChanges();
                message = "Estado de conservación eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el estado de conservación, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
