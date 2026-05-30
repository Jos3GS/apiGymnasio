using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTamano
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeTamano(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTamano> ListarTamano()
        {
            return oGym.TblTamanos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
