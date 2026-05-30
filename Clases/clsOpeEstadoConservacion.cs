using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEstadoConservacion
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeEstadoConservacion(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEstadoConservacion> ListarEstadoConservacion()
        {
            return oGym.TblEstadoConservacions.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
