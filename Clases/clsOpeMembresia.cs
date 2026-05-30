using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMembresia
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeMembresia(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblMembresium> ListarMembresias()
        {
            return oGym.TblMembresia.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
