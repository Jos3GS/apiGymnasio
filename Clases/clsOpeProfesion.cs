using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeProfesion
    {
        private readonly BdgymnasioContext oGym;
        public TblProfesion? tblProfesion { get; set; }
        public string? message { get; set; }

        public clsOpeProfesion(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblProfesion> ListarProfesion()
        {
            return oGym.TblProfesions.OrderBy(x => x.Nombre).ToList();
        }

        public TblProfesion? ListarProfesion(int codigo)
        {
            try
            {
                var temp = oGym.TblProfesions.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la profesión para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la profesión, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarProfesion()
        {
            try
            {
                if (tblProfesion == null)
                {
                    message = "No se ha asignado una profesión para agregar";
                    return false;
                }
                var temp = oGym.TblProfesions.FirstOrDefault(x => x.Nombre.ToLower() == tblProfesion.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una profesión con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblProfesions.Add(tblProfesion);
                oGym.SaveChanges();
                message = "Profesión agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la profesión, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarProfesion()
        {
            try
            {
                if (tblProfesion == null)
                {
                    message = "No se ha asignado una profesión para modificar";
                    return false;
                }
                var temp = oGym.TblProfesions.FirstOrDefault(x => x.Codigo == tblProfesion.Codigo);
                if (temp == null)
                {
                    message = "No se encontró la profesión a modificar, Reintentalo nuevamente.";
                    return false;
                }
                var duplicado = oGym.TblProfesions.FirstOrDefault(x => x.Nombre.ToLower() == tblProfesion.Nombre.ToLower() && x.Codigo != tblProfesion.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe una profesión con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }

                temp.Nombre = tblProfesion.Nombre;
                oGym.SaveChanges();
                message = "Profesión modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la profesión, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarProfesion()
        {
            try
            {
                if (tblProfesion == null)
                {
                    message = "No se ha asignado una profesión para eliminar";
                    return false;
                }
                var temp = oGym.TblProfesions.FirstOrDefault(x => x.Codigo == tblProfesion.Codigo);
                if (temp == null)
                {
                    message = "No se encontró la profesión a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblProfesions.Remove(temp);
                oGym.SaveChanges();
                message = "Profesión eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la profesión, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
