using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMarca
    {
        private readonly BdgymnasioContext oGym;
        public TblMarca? tblMarca { get; set; }
        public string? message { get; set; }

        public clsOpeMarca(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblMarca> ListarMarcas()
        {
            return oGym.TblMarcas.OrderBy(x => x.Nombre).ToList();
        }

        public TblMarca? ListarMarcas(int codigo)
        {
            try
            {
                var temp = oGym.TblMarcas.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la marca para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la marca, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarMarca()
        {
            try
            {
                if (tblMarca == null)
                {
                    message = "No se ha asignado una marca para agregar";
                    return false;
                }
                var temp = oGym.TblMarcas.FirstOrDefault(x => x.Nombre.ToLower() == tblMarca.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una marca con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMarcas.Add(tblMarca);
                oGym.SaveChanges();
                message = "Marca agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la marca, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool modificarMarca()
        {
            try
            {
                if (tblMarca == null)
                {
                    message = "No se ha asignado una marca para modificar";
                    return false;
                }
                var temp = oGym.TblMarcas.FirstOrDefault(x => x.Codigo == tblMarca.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la marca para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblMarcas.FirstOrDefault(x => x.Nombre.ToLower() == tblMarca.Nombre.ToLower() && x.Codigo != tblMarca.Codigo);
                if (temp != null)
                {
                    message = "Ya existe una marca con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMarcas.Update(tblMarca);
                oGym.SaveChanges();
                message = "Marca modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la marca, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool eliminarMarca()
        {
            try
            {
                if (tblMarca == null)
                {
                    message = "No se ha asignado una marca para eliminar";
                    return false;
                }
                var temp = oGym.TblMarcas.FirstOrDefault(x => x.Codigo == tblMarca.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la marca para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblMarcas.Remove(temp);
                oGym.SaveChanges();
                message = "Marca eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la marca, Reintentalo nuevamente.";
                return false;
            }

        }
    }
}
