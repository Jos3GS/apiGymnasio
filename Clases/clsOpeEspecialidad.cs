using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeEspecialidad
    {
        private readonly BdgymnasioContext oGym;

        public clsOpeEspecialidad(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblEspecialidad> ListarEspecialidades()
        {
            return oGym.TblEspecialidads.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

    }
}
