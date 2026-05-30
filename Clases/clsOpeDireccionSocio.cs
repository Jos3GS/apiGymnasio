using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeDireccionSocio
    {
        private readonly BdgymnasioContext oGym;
        public TblDireccionSocio? tblDireccionSocio { get; set; }
        public string? message { get; set; }

        public clsOpeDireccionSocio(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblDireccionSocio> ListarDireccionSocio()
        {
            return oGym.TblDireccionSocios.OrderBy(x => x.Codigo).Where(x => x.Activo == true).ToList();
        }

        public TblDireccionSocio? ListarDireccionSocio(int codigo)
        {
            try
            {
                var temp = oGym.TblDireccionSocios.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la dirección del socio para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la dirección del socio, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarDireccionSocio()
        {
            try
            {
                if (tblDireccionSocio == null)
                {
                    message = "No se ha asignado una dirección del socio para agregar";
                    return false;
                }   
                oGym.TblDireccionSocios.Add(tblDireccionSocio);
                oGym.SaveChanges();
                message = "Dirección del socio agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la dirección del socio, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarDireccionSocio()
        {
            try
            {
                if (tblDireccionSocio == null)
                {
                    message = "No se ha asignado una dirección del socio para modificar";
                    return false;
                }
                var existente = oGym.TblDireccionSocios.FirstOrDefault(x => x.Codigo == tblDireccionSocio.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado la dirección del socio para el código ingresado, Reintentalo nuevamente.";
                    return false;
                }

                var duplicado = oGym.TblDireccionSocios.FirstOrDefault(x => x.Direccion == tblDireccionSocio.Direccion && x.Codigo != tblDireccionSocio.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe la dirección del socio, Reintentalo nuevamente.";
                    return false;
                }

                existente.Direccion = tblDireccionSocio.Direccion;
                existente.Activo = tblDireccionSocio.Activo;
                existente.FkSocio = tblDireccionSocio.FkSocio;
                existente.FkCiudad = tblDireccionSocio.FkCiudad;
                oGym.SaveChanges();
                message = "Dirección del socio modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la dirección del socio, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarDireccionSocio()
        {
            try
            {
                if (tblDireccionSocio == null)
                {
                    message = "No se ha asignado una dirección del socio para eliminar";
                    return false;
                }
                var temp = oGym.TblDireccionSocios.FirstOrDefault(x => x.Codigo == tblDireccionSocio.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la dirección del socio, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblDireccionSocios.Remove(temp);
                oGym.SaveChanges();
                message = "Dirección del socio eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la dirección del socio, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
