using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeUsuario
    {
        private readonly BdgymnasioContext oGym;
        public TblUsuario? tblUsuario { get; set; }
        public string? message { get; set; }

        public clsOpeUsuario(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblUsuario> ListarUsuarios()
        {
            return oGym.TblUsuarios
               .OrderBy(x => x.Usuario)
               .Select(x => new TblUsuario
               {
                   Codigo = x.Codigo,
                   Usuario = x.Usuario
               })
               .ToList();
        }

        public TblUsuario? ListarUsuarios(int codigo)
        {
            try
            {
                var temp = oGym.TblUsuarios.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el usuario, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el usuario, Reintentalo nuevamente.";
                return null;
            }
        }

        public TblUsuario? IniciarSesion(string nombreUsuario, string clave)
        {
            return oGym.TblUsuarios.FirstOrDefault(x => x.Usuario == nombreUsuario && x.Contrasena == clave);
        }

        public bool agregarUsuario()
        {
            try
            {
                if (tblUsuario == null)
                {
                    message = "No se ha asignado un usuario para agregar";
                    return false;
                }
                var temp = oGym.TblUsuarios.FirstOrDefault(x => x.Usuario.ToLower() == tblUsuario.Usuario.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un usuario con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblUsuarios.Add(tblUsuario);
                oGym.SaveChanges();
                message = "Usuario agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el usuario, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarUsuario()
        {
            try
            {
                if (tblUsuario == null)
                {
                    message = "No se ha asignado un usuario para modificar";
                    return false;
                }
                var temp = oGym.TblUsuarios.FirstOrDefault(x => x.Codigo == tblUsuario.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el usuario a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblUsuarios.FirstOrDefault(x => x.Usuario.ToLower() == tblUsuario.Usuario.ToLower() && x.Codigo != tblUsuario.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un usuario con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblUsuarios.Update(tblUsuario);
                oGym.SaveChanges();
                message = "Usuario modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el usuario, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarUsuario()
        {
            try
            {
                if (tblUsuario == null)
                {
                    message = "No se ha asignado un usuario para eliminar";
                    return false;
                }
                var temp = oGym.TblUsuarios.FirstOrDefault(x => x.Codigo == tblUsuario.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el usuario a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblUsuarios.Remove(tblUsuario);
                oGym.SaveChanges();
                message = "Usuario eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el usuario, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
