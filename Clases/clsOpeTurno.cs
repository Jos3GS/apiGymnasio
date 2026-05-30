using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTurno
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeTurno(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTurno> ListarTurno()
        {
            return oGym.TblTurnos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
