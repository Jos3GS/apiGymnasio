using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEstado
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeEstado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEstado> ListarEstados()
        {
            return oGym.TblEstados.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
