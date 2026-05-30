using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeTurno
    {
        private readonly BdgymnasioContext oGym;
        public TblTurno? tblTurno { get; set; }
        public string? message { get; set; }

        public clsOpeTurno(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblTurno> ListarTurno()
        {
            return oGym.TblTurnos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public TblTurno? ListarTurno(int codigo)
        {
            try
            {
                var temp = oGym.TblTurnos.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el turno, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el turno, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarTurno()
        {
            try
            {
                if (tblTurno == null)
                {
                    message = "No se ha asignado un turno para agregar";
                    return false;
                }
                var temp = oGym.TblTurnos.FirstOrDefault(x => x.Nombre.ToLower() == tblTurno.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un turno con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTurnos.Add(tblTurno);
                oGym.SaveChanges();
                message = "Turno agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el turno, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarTurno()
        {
            try
            {
                if (tblTurno == null)
                {
                    message = "No se ha asignado un turno para modificar";
                    return false;
                }
                var temp = oGym.TblTurnos.FirstOrDefault(x => x.Codigo == tblTurno.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el turno a modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblTurnos.FirstOrDefault(x => x.Nombre.ToLower() == tblTurno.Nombre.ToLower() && x.Codigo != tblTurno.Codigo);
                if (temp != null)
                {
                    message = "Ya existe un turno con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTurnos.Update(tblTurno);
                oGym.SaveChanges();
                message = "Turno modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el turno, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarTurno()
        {
            try
            {
                if (tblTurno == null)
                {
                    message = "No se ha asignado un turno para eliminar";
                    return false;
                }
                var temp = oGym.TblTurnos.FirstOrDefault(x => x.Codigo == tblTurno.Codigo);
                if (temp == null)
                {
                    message = "No se encontró el turno a eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblTurnos.Remove(tblTurno);
                oGym.SaveChanges();
                message = "Turno eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el turno, Reintentalo nuevamente.";
                return false;
            }
        }

    }
}
