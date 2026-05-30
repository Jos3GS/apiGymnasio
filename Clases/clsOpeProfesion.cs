using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeProfesion
    {
        private readonly BdgymnasioContext oGym;
        public TblProfesion? tblProfesion { get; set; }
        public string? message { get; set; }

        public clsOpeProfesion(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblProfesion> ListarProfesion()
        {
            return oGym.TblProfesions.OrderBy(x => x.Nombre).ToList();
        }

        public bool agregarProfesion()
        {
            try
            {
                if (tblProfesion == null)
                {
                    message = "No se ha asignado una profesión para agregar";
                    return false;
                }
                var temp = oGym.TblProfesions.FirstOrDefault(x => x.Nombre.ToLower() == tblProfesion.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una profesión con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblProfesions.Add(tblProfesion);
                oGym.SaveChanges();
                message = "Profesión agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la profesión, Reintentalo nuevamente.";
                return false;
            }
        }

        }
}
