using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTipoDocumento
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeTipoDocumento(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTipoDocumento> ListarTipoDocumento()
        {
            return oGym.TblTipoDocumentos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
