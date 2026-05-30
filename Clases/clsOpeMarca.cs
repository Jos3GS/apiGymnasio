using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMarca
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeMarca(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblMarca> ListarMarcas()
        {
            return oGym.TblMarcas.OrderBy(x => x.Nombre).ToList();
        }
    }
}
