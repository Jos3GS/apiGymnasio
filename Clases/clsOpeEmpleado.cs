using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEmpleado
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeEmpleado(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEmpleado> ListarEmpleados()
        {
            return oGym.TblEmpleados.OrderBy(x => x.Nombre).ToList();
        }


    }
}
