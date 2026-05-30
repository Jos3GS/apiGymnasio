using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTelSocioSocio
    {
        private readonly BdgymnasioContext oGym;
        public TblTelSocioSocio? tblTel { get; set; }
        public string? message { get; set; }

        public clsOpeTelSocioSocio(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTelSocioSocio> Listar()
        {
            return oGym.TblTelSocioSocios.OrderBy(x => x.Codigo).ToList();
        }

        public TblTelSocioSocio? Listar(int codigo)
        {
            try
            {
                var temp = oGym.TblTelSocioSocios.FirstOrDefault(x => x.Codigo == codigo);
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
                oGym.TblTelSocioSocios.Add(tblTel);
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
                var existente = oGym.TblTelSocioSocios.FirstOrDefault(x => x.Codigo == tblTel.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado el registro para modificar, Reintentalo nuevamente.";
                    return false;
                }

                existente.FkTelefonoSocio = tblTel.FkTelefonoSocio;
                existente.FkSocio = tblTel.FkSocio;
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
                var temp = oGym.TblTelSocioSocios.FirstOrDefault(x => x.Codigo == tblTel.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el registro para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTelSocioSocios.Remove(temp);
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
