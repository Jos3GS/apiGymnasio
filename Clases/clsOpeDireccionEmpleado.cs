using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeDireccionEmpleado
    {
        private readonly BdgymnasioContext oGym;
        public TblDireccionEmpleado? tblDireccionEmpleado { get; set; }
        public string? message { get; set; }

        public clsOpeDireccionEmpleado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblDireccionEmpleado> ListarDireccionEmpleado()
        {
            return oGym.TblDireccionEmpleados.OrderBy(x => x.Codigo).Where(x => x.Activo == true).ToList();
        }

        public TblDireccionEmpleado? ListarDireccionEmpleado(int codigo)
        {
            try
            {
                var temp = oGym.TblDireccionEmpleados.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la dirección del empleado para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la dirección del empleado, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarDireccionEmpleado()
        {
            try
            {
                if (tblDireccionEmpleado == null)
                {
                    message = "No se ha asignado una dirección del empleado para agregar";
                    return false;
                }
                oGym.TblDireccionEmpleados.Add(tblDireccionEmpleado);
                oGym.SaveChanges();
                message = "Dirección del empleado agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la dirección del empleado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarDireccionEmpleado()
        {
            try
            {
                if (tblDireccionEmpleado == null)
                {
                    message = "No se ha asignado una dirección del empleado para modificar";
                    return false;
                }
                var temp = oGym.TblDireccionEmpleados.FirstOrDefault(x => x.Codigo == tblDireccionEmpleado.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la dirección del empleado para el código ingresado, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblDireccionEmpleados.FirstOrDefault(x => x.Direccion == tblDireccionEmpleado.Direccion && x.Codigo != tblDireccionEmpleado.Codigo);
                if (temp != null)
                {
                    message = "Ya existe la dirección del empleado, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblDireccionEmpleados.Update(tblDireccionEmpleado);
                oGym.SaveChanges();
                message = "Dirección del empleado modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la dirección del empleado, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarDireccionEmpleado()
        {
            try
            {
                if (tblDireccionEmpleado == null)
                {
                    message = "No se ha asignado una dirección del empleado para modificar";
                    return false;
                }
                var temp = oGym.TblDireccionEmpleados.FirstOrDefault(x => x.Codigo == tblDireccionEmpleado.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la dirección del empleado, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblDireccionEmpleados.Remove(tblDireccionEmpleado);
                oGym.SaveChanges();
                message = "Dirección del empleado eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la dirección del empleado, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
