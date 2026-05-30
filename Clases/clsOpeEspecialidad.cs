using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEspecialidad
    {
        private readonly BdgymnasioContext oGym;
        public TblEspecialidad? tblEspecialidad { get; set; }
        public string? message { get; set; }

        public clsOpeEspecialidad(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEspecialidad> ListarEspecialidades()
        {
            return oGym.TblEspecialidads.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public bool agregarEspecialidad()
        {
            try
            {
                if (tblEspecialidad == null)
                {
                    message = "No se ha asignado una especialidad para agregar";
                    return false;
                }
                var temp = oGym.TblEspecialidads.FirstOrDefault(x => x.Nombre.ToLower() == tblEspecialidad.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una especialidad con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEspecialidads.Add(tblEspecialidad);
                oGym.SaveChanges();
                message = "Especialidad agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la especialidad, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool modificarEspecialidad()
        {
            try
            {
                if (tblEspecialidad == null)
                {
                    message = "No se ha asignado una especialidad para modificar";
                    return false;
                }
                var temp = oGym.TblEspecialidads.FirstOrDefault(x => x.Codigo == tblEspecialidad.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la especialidad para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblEspecialidads.FirstOrDefault(x => x.Nombre.ToLower() == tblEspecialidad.Nombre.ToLower() && x.Codigo != tblEspecialidad.Codigo);
                if (temp != null)
                {
                    message = "Ya existe una especialidad con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEspecialidads.Update(tblEspecialidad);
                oGym.SaveChanges();
                message = "Especialidad modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la especialidad, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool eliminarEspecialidad()
        {
            try
            {
                if (tblEspecialidad == null)
                {
                    message = "No se ha asignado una especialidad para eliminar";
                    return false;
                }
                var temp = oGym.TblEspecialidads.FirstOrDefault(x => x.Codigo == tblEspecialidad.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la especialidad para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEspecialidads.Remove(temp);
                oGym.SaveChanges();
                message = "Especialidad eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la especialidad, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
