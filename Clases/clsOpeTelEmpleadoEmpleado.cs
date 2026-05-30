using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTelEmpleadoEmpleado
    {
        private readonly BdgymnasioContext oGym;
        public TblTelEmpleadoEmpleado? tblTel { get; set; }
        public string? message { get; set; }

        public clsOpeTelEmpleadoEmpleado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTelEmpleadoEmpleado> Listar()
        {
            return oGym.TblTelEmpleadoEmpleados.OrderBy(x => x.Codigo).ToList();
        }

        public TblTelEmpleadoEmpleado? Listar(int codigo)
        {
            try
            {
                var temp = oGym.TblTelEmpleadoEmpleados.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el registro, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el registro, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregar()
        {
            try
            {
                if (tblTel == null)
                {
                    message = "No se ha asignado información para agregar";
                    return false;
                }
                oGym.TblTelEmpleadoEmpleados.Add(tblTel);
                oGym.SaveChanges();
                message = "Registro agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el registro, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificar()
        {
            try
            {
                if (tblTel == null)
                {
                    message = "No se ha asignado información para modificar";
                    return false;
                }
                var existente = oGym.TblTelEmpleadoEmpleados.FirstOrDefault(x => x.Codigo == tblTel.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado el registro para modificar, Reintentalo nuevamente.";
                    return false;
                }

                existente.FkTelefonoEmpleado = tblTel.FkTelefonoEmpleado;
                existente.FkEmpleado = tblTel.FkEmpleado;
                oGym.SaveChanges();
                message = "Registro modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el registro, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrar()
        {
            try
            {
                if (tblTel == null)
                {
                    message = "No se ha asignado información para eliminar";
                    return false;
                }
                var temp = oGym.TblTelEmpleadoEmpleados.FirstOrDefault(x => x.Codigo == tblTel.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el registro para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelEmpleadoEmpleados.Remove(temp);
                oGym.SaveChanges();
                message = "Registro eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el registro, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
