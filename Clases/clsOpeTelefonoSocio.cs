using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTelefonoSocio
    {
        private readonly BdgymnasioContext oGym;
        public TblTelefonoSocio? tblTelefonoSocio { get; set; }
        public string? message { get; set; }

        public clsOpeTelefonoSocio(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTelefonoSocio> ListarTelefonos()
        {
            return oGym.TblTelefonoSocios.OrderBy(x => x.Codigo).Where(x => x.Activo == true).ToList();
        }

        public TblTelefonoSocio? ListarTelefonos(int codigo)
        {
            try
            {
                var temp = oGym.TblTelefonoSocios.FirstOrDefault(x => x.Codigo == codigo);
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
                if (tblTelefonoSocio == null)
                {
                    message = "No se ha asignado un teléfono para agregar";
                    return false;
                }
                var temp = oGym.TblTelefonoSocios.FirstOrDefault(x => x.Numero == tblTelefonoSocio.Numero);
                if (temp != null)
                {
                    message = "Ya existe un teléfono con el mismo número, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelefonoSocios.Add(tblTelefonoSocio);
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
                if (tblTelefonoSocio == null)
                {
                    message = "No se ha asignado un teléfono para modificar";
                    return false;
                }
                var existente = oGym.TblTelefonoSocios.FirstOrDefault(x => x.Codigo == tblTelefonoSocio.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado el teléfono para modificar, Reintentalo nuevamente.";
                    return false;
                }

                var duplicado = oGym.TblTelefonoSocios.FirstOrDefault(x => x.Numero == tblTelefonoSocio.Numero && x.Codigo != tblTelefonoSocio.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe un teléfono con el mismo número, Reintentalo nuevamente.";
                    return false;
                }

                existente.Numero = tblTelefonoSocio.Numero;
                existente.Principal = tblTelefonoSocio.Principal;
                existente.Activo = tblTelefonoSocio.Activo;
                existente.FkTipoTelefono = tblTelefonoSocio.FkTipoTelefono;
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
                if (tblTelefonoSocio == null)
                {
                    message = "No se ha asignado un teléfono para eliminar";
                    return false;
                }
                var temp = oGym.TblTelefonoSocios.FirstOrDefault(x => x.Codigo == tblTelefonoSocio.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el teléfono para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelefonoSocios.Remove(temp);
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
