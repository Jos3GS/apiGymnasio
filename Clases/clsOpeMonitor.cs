using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMonitor
    {
        private readonly BdgymnasioContext oGym;
        public TblMonitor? tblMonitor { get; set; }
        public string? message { get; set; }

        public clsOpeMonitor(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public IQueryable listarMonitores()
        {
            return from Emp in oGym.Set<TblEmpleado>()
                   join Mon in oGym.Set<TblMonitor>()
                   on Emp.NumeroId equals Mon.NumeroId
                   select new
                   {
                       NumeroId = Emp.NumeroId,
                       Salario = Emp.Salario,
                       Nombre = Emp.Nombre,
                       Apellidos = Emp.Apellidos,
                       UsuarioCrea = Emp.UsuarioCrea,
                       Experiencia = Mon.Experiencia,
                       Titulacion = Mon.Titulacion,
                       FkTipoDocumento = Emp.FkTipoDocumento,
                       FkTurno = Emp.FkTurno,
                       FkCargo = Emp.FkCargo,
                       FkEspecialidad = Emp.FkEspecialidad,
                       FkUsuario = Emp.FkUsuario,
                   };
        }

        public IQueryable listarMonitores(int codigo)
        {
            return from Emp in oGym.Set<TblEmpleado>()
                   join Mon in oGym.Set<TblMonitor>()
                   on Emp.NumeroId equals Mon.NumeroId
                   where Emp.NumeroId == codigo
                   select new
                   {
                       NumeroId = Emp.NumeroId,
                       Salario = Emp.Salario,
                       Nombre = Emp.Nombre,
                       Apellidos = Emp.Apellidos,
                       UsuarioCrea = Emp.UsuarioCrea,
                       Experiencia = Mon.Experiencia,
                       Titulacion = Mon.Titulacion,
                       FkTipoDocumento = Emp.FkTipoDocumento,
                       FkTurno = Emp.FkTurno,
                       FkCargo = Emp.FkCargo,
                       FkEspecialidad = Emp.FkEspecialidad,
                       FkUsuario = Emp.FkUsuario,
                   };
        }

        public bool agregarMonitor(TblEmpleado Empl)
        {
            try
            {
                if (tblMonitor == null || Empl == null)
                {
                    message = "No se ha asignado un monitor para agregar";
                    return false;
                }
                var temp = oGym.TblMonitors.FirstOrDefault(x => x.NumeroId == tblMonitor.NumeroId);
                if (temp != null)
                {
                    message = "Ya existe un monitor con el mismo número de identificación, Reintentalo nuevamente.";
                    return false;
                }
                clsOpeEmpleado oEmp = new clsOpeEmpleado(oGym);
                if (oEmp.buscarEmpleadoXNumeroId(tblMonitor.NumeroId) == null)
                {
                    oEmp.tblEmpleado = Empl;
                    if(!oEmp.agregarEmpleado())
                    {
                        message = "Error al agregar el monitor, Reintentalo nuevamente.";
                        return false;
                    }
                }
                oGym.TblMonitors.Add(tblMonitor);
                oGym.SaveChanges();
                message = "Monitor agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el monitor, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarMonitor(TblEmpleado Empl)
        {
            try
            {
                if (tblMonitor == null || Empl == null)
                {
                    message = "No se ha asignado un monitor para modificar";
                    return false;
                }
                var temp = oGym.TblMonitors.FirstOrDefault(x => x.NumeroId == tblMonitor.NumeroId);
                if (temp == null)
                {
                    message = "No se encontró el monitor a modificar, Reintentalo nuevamente.";
                    return false;
                }
                clsOpeEmpleado oEmp = new clsOpeEmpleado(oGym);
                oEmp.tblEmpleado = Empl;
                if (!oEmp.modificarEmpleado())
                {
                    message = "Error al modificar el monitor, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMonitors.Update(tblMonitor);
                oGym.SaveChanges();
                message = "Monitor modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el monitor, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarMonitor(TblEmpleado Empl)
        {
            try
            {
                if (tblMonitor == null || Empl == null)
                {
                    message = "No se ha asignado un monitor para eliminar";
                    return false;
                }
                var temp = oGym.TblMonitors.FirstOrDefault(x => x.NumeroId == tblMonitor.NumeroId);
                if (temp == null)
                {
                    message = "No se encontró el monitor a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                clsOpeEmpleado oEmp = new clsOpeEmpleado(oGym);
                oEmp.tblEmpleado = Empl;
                oGym.TblMonitors.Remove(tblMonitor);
                if (!oEmp.borrarEmpleado())
                {
                    message = "Error al eliminar el monitor, Reintentalo nuevamente.";
                    return false;
                }
                oGym.SaveChanges();
                message = "Monitor eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el monitor, Reintentalo nuevamente.";
                return false;
            }
        }

    }
}
