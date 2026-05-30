using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeUsuario
    {
        private readonly BdgymnasioContext oGym;

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

        public TblUsuario IniciarSesion(string nombreUsuario, string clave)
        {
            return oGym.TblUsuarios.FirstOrDefault(x => x.Usuario == nombreUsuario && x.Contrasena == clave);
        }


    }
}
