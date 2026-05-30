using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeProfesion
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeProfesion(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblProfesion> ListarProfesion()
        {
            return oGym.TblProfesions.OrderBy(x => x.Nombre).ToList();
        }
    }
}
