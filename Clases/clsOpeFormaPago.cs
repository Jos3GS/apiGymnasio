using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeFormaPago
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeFormaPago(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblFormaPago> Listar()
        {
            return oGym.TblFormaPagos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }
    }
}
