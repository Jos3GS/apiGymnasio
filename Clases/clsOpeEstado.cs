using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEstado
    {
        private readonly BdgymnasioContext oGym;
        public TblEstado? tblEstado { get; set; }
        public string? message { get; set; }

        public clsOpeEstado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEstado> ListarEstados()
        {
            return oGym.TblEstados.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblEstado? ListarEstados(int codigo)
        {
            try
            {
                var temp = oGym.TblEstados.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el estado, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarEstado()
        {
            try
            {
                if (tblEstado == null)
                {
                    message = "No se ha asignado un estado para agregar";
                    return false;
                }
                var temp = oGym.TblEstados.FirstOrDefault(x => x.Nombre.ToLower() == tblEstado.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un estado con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEstados.Add(tblEstado);
                oGym.SaveChanges();
                message = "Estado agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el estado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarEstado()
        {
            try
            {
                if (tblEstado == null)
                {
                    message = "No se ha asignado un estado para modificar";
                    return false;
                }
                var temp = oGym.TblEstados.FirstOrDefault(x => x.Codigo == tblEstado.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblEstados.FirstOrDefault(x => x.Nombre.ToLower() == tblEstado.Nombre.ToLower() && x.Codigo != tblEstado.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un estado con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEstados.Update(tblEstado);
                oGym.SaveChanges();
                message = "Estado modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el estado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarEstado()
        {
            try
            {
                if (tblEstado == null)
                {
                    message = "No se ha asignado un estado para eliminar";
                    return false;
                }
                var temp = oGym.TblEstados.FirstOrDefault(x => x.Codigo == tblEstado.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el estado para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                temp.Activo = false;
                oGym.TblEstados.Update(temp);
                oGym.SaveChanges();
                message = "Estado eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el estado, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
