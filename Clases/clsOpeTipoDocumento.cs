using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoDocumento
    {
        private readonly BdgymnasioContext oGym;
        public TblTipoDocumento? tblTipoDocumento { get; set; }
        public string? message { get; set; }

        public clsOpeTipoDocumento(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoDocumento> ListarTipoDocumento()
        {
            return oGym.TblTipoDocumentos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblTipoDocumento? ListarTipoDocumento(int codigo)
        {
            try
            {
                var temp = oGym.TblTipoDocumentos.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el tipo de documento, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el tipo de documento, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarTipoDocumento()
        {
            try
            {
                if (tblTipoDocumento == null)
                {
                    message = "No se ha asignado un tipo de documento para agregar";
                    return false;
                }
                var temp = oGym.TblTipoDocumentos.FirstOrDefault(x => x.Nombre.ToLower() == tblTipoDocumento.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un tipo de documento con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoDocumentos.Add(tblTipoDocumento);
                oGym.SaveChanges();
                message = "Tipo de documento agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el tipo de documento, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarTipoDocumento()
        {
            try
            {
                if (tblTipoDocumento == null)
                {
                    message = "No se ha asignado un tipo de documento para modificar";
                    return false;
                }
                var temp = oGym.TblTipoDocumentos.FirstOrDefault(x => x.Codigo == tblTipoDocumento.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de documento a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblTipoDocumentos.FirstOrDefault(x => x.Nombre.ToLower() == tblTipoDocumento.Nombre.ToLower() && x.Codigo != tblTipoDocumento.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un tipo de documento con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoDocumentos.Update(tblTipoDocumento);
                oGym.SaveChanges();
                message = "Tipo de documento modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el tipo de documento, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarTipoDocumento()
        {
            try
            {
                if (tblTipoDocumento == null)
                {
                    message = "No se ha asignado un tipo de documento para eliminar";
                    return false;
                }
                var temp = oGym.TblTipoDocumentos.FirstOrDefault(x => x.Codigo == tblTipoDocumento.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el tipo de documento a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTipoDocumentos.Remove(temp);
                oGym.SaveChanges();
                message = "Tipo de documento eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el tipo de documento, Reintentalo nuevamente.";
                return false;
            }
        }

        }
}
