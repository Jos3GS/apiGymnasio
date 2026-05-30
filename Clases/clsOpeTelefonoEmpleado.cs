using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTelefonoEmpleado
    {
        private readonly BdgymnasioContext oGym;
        public TblTelefonoEmpleado? tblTelefonoEmpleado { get; set; }
        public string? message { get; set; }

        public clsOpeTelefonoEmpleado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTelefonoEmpleado> ListarTelefonos()
        {
            return oGym.TblTelefonoEmpleados.OrderBy(x => x.Codigo).Where(x => x.Activo == true).ToList();
        }

        public TblTelefonoEmpleado? ListarTelefonos(int codigo)
        {
            try
            {
                var temp = oGym.TblTelefonoEmpleados.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el teléfono, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el teléfono, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarTelefono()
        {
            try
            {
                if (tblTelefonoEmpleado == null)
                {
                    message = "No se ha asignado un teléfono para agregar";
                    return false;
                }
                var temp = oGym.TblTelefonoEmpleados.FirstOrDefault(x => x.Numero == tblTelefonoEmpleado.Numero);
                if (temp != null)
                {
                    message = "Ya existe un teléfono con el mismo número, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelefonoEmpleados.Add(tblTelefonoEmpleado);
                oGym.SaveChanges();
                message = "Teléfono agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el teléfono, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarTelefono()
        {
            try
            {
                if (tblTelefonoEmpleado == null)
                {
                    message = "No se ha asignado un teléfono para modificar";
                    return false;
                }
                var existente = oGym.TblTelefonoEmpleados.FirstOrDefault(x => x.Codigo == tblTelefonoEmpleado.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado el teléfono para modificar, Reintentalo nuevamente.";
                    return false;
                }

                var duplicado = oGym.TblTelefonoEmpleados.FirstOrDefault(x => x.Numero == tblTelefonoEmpleado.Numero && x.Codigo != tblTelefonoEmpleado.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe un teléfono con el mismo número, Reintentalo nuevamente.";
                    return false;
                }

                existente.Numero = tblTelefonoEmpleado.Numero;
                existente.Principal = tblTelefonoEmpleado.Principal;
                existente.Activo = tblTelefonoEmpleado.Activo;
                existente.FkTipoTelefono = tblTelefonoEmpleado.FkTipoTelefono;
                oGym.SaveChanges();
                message = "Teléfono modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el teléfono, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarTelefono()
        {
            try
            {
                if (tblTelefonoEmpleado == null)
                {
                    message = "No se ha asignado un teléfono para eliminar";
                    return false;
                }
                var temp = oGym.TblTelefonoEmpleados.FirstOrDefault(x => x.Codigo == tblTelefonoEmpleado.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el teléfono para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelefonoEmpleados.Remove(temp);
                oGym.SaveChanges();
                message = "Teléfono eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el teléfono, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
