using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoTelefono
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeTipoTelefono(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoTelefono> ListarTipoTelefono()
        {
            return oGym.TblTipoTelefonos.OrderBy(x => x.Tipo).ToList();
        }
    }
}
