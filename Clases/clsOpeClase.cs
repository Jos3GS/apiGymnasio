using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeClase
    {
        private readonly BdgymnasioContext oGym;
        public TblClase? tblClase { get; set; }
        public string? message { get; set; }

        public clsOpeClase(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblClase> listarClases()
        {
            return oGym.TblClases.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
        public TblClase? listarClases(int codigo)
        {
            try
            {
                var temp = oGym.TblClases.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null) {
                    message = "No se ha encontrado la clase, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = "Error al listar la clase, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblClase>? listarClasesXMonitor(int idMonitor)
        {
            try
            {
                var temp = oGym.TblClases.OrderBy(x => x.Nombre).Where(x => x.FkMonitor == idMonitor).ToList();
                if(temp.Count == 0)
                {
                    message = "No se encontraron clases para el monitor especificado.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = " Error al listar las clases por monitor, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblClase>? listarClasesXSala(int idSala)
        {
            try
            {
                var temp = oGym.TblClases.OrderBy(x => x.Nombre).Where(x => x.FkSala == idSala).ToList();
                if (temp.Count == 0)
                {
                    message = "No se encontraron clases para la sala especificada.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = " Error al listar las clases por sala, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblClase>? listarClasesXEspecialidad(int idEspecialidad)
        {
            try
            {
                var temp = oGym.TblClases.OrderBy(x => x.Nombre).Where(x => x.FkEspecialidad == idEspecialidad).ToList();
                if (temp.Count == 0)
                {
                    message = "No se encontraron clases para la especialidad especificada.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = " Error al listar las clases por especialidad, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarClase()
        {
            try
            {
                if (tblClase == null)
                {
                    message = "No se ha asignado una clase para agregar";
                    return false;
                }
                oGym.TblClases.Add(tblClase);
                oGym.SaveChanges();
                message = "Clase agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la clase, Reintentalo nuevamente.";
                return false;
            }
        }
        public bool modificarClase()
        {
            try
            {
                if (tblClase == null)
                {
                    message = "No se ha asignado una clase para modificar";
                    return false;
                }
                var existente = oGym.TblClases.FirstOrDefault(x => x.Codigo == tblClase.Codigo);
                if (existente == null)
                {
                    message = "No se encontró la clase a modificar, Reintentalo nuevamente.";
                    return false;
                }

                // Actualizar propiedades en la entidad rastreada por el contexto
                existente.Nombre = tblClase.Nombre;
                existente.Descripcion = tblClase.Descripcion;
                existente.Horario = tblClase.Horario;
                existente.Activo = tblClase.Activo;
                existente.FkMonitor = tblClase.FkMonitor;
                existente.FkSala = tblClase.FkSala;
                existente.FkEspecialidad = tblClase.FkEspecialidad;

                oGym.SaveChanges();
                message = "Clase modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la clase, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarClase()
        {
            try
            {
                if (tblClase == null)
                {
                    message = "No se ha asignado una clase para eliminar";
                    return false;
                }
                var temp = oGym.TblClases.FirstOrDefault(x => x.Codigo == tblClase.Codigo);
                if (temp == null)
                {
                    message = "No se encontró la clase a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblClases.Remove(temp);
                oGym.SaveChanges();
                message = "Clase eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la clase, Reintentalo nuevamente.";
                return false;
            }
        }

    }
}
