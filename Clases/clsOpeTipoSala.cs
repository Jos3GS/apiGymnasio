using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoSala
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeTipoSala(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoSala> ListarTipoSala()
        {
            return oGym.TblTipoSalas.OrderBy(x => x.Nombre).ToList();
        }
    }
}
