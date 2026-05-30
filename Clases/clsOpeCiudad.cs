using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeCiudad
    {
        private readonly BdgymnasioContext oGym;
        public TblCiudad? tblCiudad { get; set; }
        public string? message { get; set; }

        public clsOpeCiudad(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblCiudad> ListarCiudades()
        {
            return oGym.TblCiudads.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblCiudad? ListarCiudades(int codigo)
        {
            try
            {
                var temp = oGym.TblCiudads.FirstOrDefault(x => x.Codigo == codigo);
                if(temp == null)
                {
                    message = "No se ha encontrado la ciudad, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = "Error al listar la ciudad, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarCiudad()
        {
            try
            {
                if (tblCiudad == null)
                {
                    message = "No se ha asignado una ciudad para agregar";
                    return false;
                }
                var temp = oGym.TblCiudads.FirstOrDefault(x => x.Nombre.ToLower() == tblCiudad.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una ciudad con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblCiudads.Add(tblCiudad);
                oGym.SaveChanges();
                message = "Ciudad agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la ciudad, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarCiudad()
        {
            try
            {
                if (tblCiudad == null)
                {
                    message = "No se ha asignado una ciudad para modificar";
                    return false;
                }
                var temp = oGym.TblCiudads.FirstOrDefault(x => x.Codigo == tblCiudad.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la ciudad para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblCiudads.FirstOrDefault(x => x.Nombre.ToLower() == tblCiudad.Nombre.ToLower() && x.Codigo != tblCiudad.Codigo);
                if (temp != null)
                {
                    message = "Ya existe una ciudad con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblCiudads.Update(tblCiudad);
                oGym.SaveChanges();
                message = "Ciudad modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la ciudad, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarCiudad()
        {
            try
            {
                if (tblCiudad == null)
                {
                    message = "No se ha asignado una ciudad para eliminar";
                    return false;
                }
                var temp = oGym.TblCiudads.FirstOrDefault(x => x.Codigo == tblCiudad.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la ciudad para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblCiudads.Remove(temp);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al eliminar la ciudad, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
