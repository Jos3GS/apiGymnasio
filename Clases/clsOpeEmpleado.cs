using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEmpleado
    {
        private readonly BdgymnasioContext oGym;
        public TblEmpleado? tblEmpleado { get; set; }
        public string? message { get; set; }

        public clsOpeEmpleado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEmpleado> ListarEmpleados()
        {
            return oGym.TblEmpleados.OrderBy(x => x.Nombre).ToList();
        }

        public List<TblEmpleado>? buscarEmpleadosXCargo(int idCargo)
        {
            try
            {
                var temp = oGym.TblEmpleados.OrderBy(x => x.Nombre).Where(x => x.FkCargo == idCargo).ToList();
                if (temp.Count == 0)
                {
                    message = "No se han encontrado empleados para el cargo seleccionado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al buscar los empleados por cargo, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblEmpleado>? buscarEmpleadoXTurno(int idTurno)
        {
            try
            {
                var temp = oGym.TblEmpleados.OrderBy(x => x.Nombre).Where(x => x.FkTurno == idTurno).ToList();
                if (temp.Count == 0)
                {
                    message = "No se han encontrado empleados para el turno seleccionado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = "Error al buscar los empleados por turno, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblEmpleado>? buscarEmpleadoXEspecialidad(int idEspecialidad)
        {
            try
            {
                var temp = oGym.TblEmpleados.OrderBy(x => x.Nombre).Where(x => x.FkEspecialidad == idEspecialidad).ToList();
                if (temp.Count == 0)
                {
                    message = "No se han encontrado empleados para la especialidad seleccionada, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al buscar los empleados por especialidad, Reintentalo nuevamente.";
                return null;
            }
        }

        public TblEmpleado? buscarEmpleadoXNumeroId(int numeroId)
        {
            try
            {
                var temp = oGym.TblEmpleados.FirstOrDefault(x => x.NumeroId == numeroId);
                if (temp == null)
                {
                    message = "No se ha encontrado el empleado para el número de identificación ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al buscar el empleado por número de identificación, Reintentalo nuevamente.";
                return null;
            }
        }

        public TblEmpleado? buscarEmpleadoXUsuario(int idUsuario)
        {
            try
            {
                var temp = oGym.TblEmpleados.FirstOrDefault(x => x.FkUsuario == idUsuario);
                if (temp == null)
                {
                    message = "No se ha encontrado el empleado para el usuario seleccionado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al buscar el empleado por usuario, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarEmpleado()
        {
            try
            {
                if (tblEmpleado == null)
                {
                    message = "No se ha asignado un empleado para agregar";
                    return false;
                }
                var temp = oGym.TblEmpleados.FirstOrDefault(x => x.NumeroId == tblEmpleado.NumeroId);
                if (temp != null)
                {
                    message = "Ya existe un empleado con el mismo número de identificación, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEmpleados.Add(tblEmpleado);
                oGym.SaveChanges();
                message = "Empleado agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el empleado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarEmpleado()
        {
            try
            {
                if (tblEmpleado == null)
                {
                    message = "No se ha asignado un empleado para modificar";
                    return false;
                }
                var temp = oGym.TblEmpleados.FirstOrDefault(x => x.NumeroId == tblEmpleado.NumeroId);
                if (temp == null)
                {
                    message = "No se ha encontrado el empleado para modificar, Reintentalo nuevamente.";
                    return false;
                }

                oGym.TblEmpleados.Update(tblEmpleado);
                oGym.SaveChanges();
                message = "Empleado modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el empleado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarEmpleado()
        {
            try
            {
                if (tblEmpleado == null)
                {
                    message = "No se ha asignado un empleado para eliminar";
                    return false;
                }
                var temp = oGym.TblEmpleados.FirstOrDefault(x => x.NumeroId == tblEmpleado.NumeroId);
                if (temp == null)
                {
                    message = "No se ha encontrado el empleado para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblEmpleados.Remove(temp);
                oGym.SaveChanges();
                message = "Empleado eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el empleado, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
