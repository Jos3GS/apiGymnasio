using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeSala
    {
        private readonly BdgymnasioContext oGym;
        public TblSala? tblSala { get; set; }
        public string? message { get; set; }

        public clsOpeSala(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblSala> ListarSalas()
        {
            return oGym.TblSalas.OrderBy(x => x.Ubicacion).Where(x => x.Activo == true).ToList();
        }

        public TblSala? ListarSalas(int numero)
        {
            try
            {
                var temp = oGym.TblSalas.FirstOrDefault(x => x.Numero == numero);
                if (temp == null)
                {
                    message = "No se ha encontrado la sala, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar la sala, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarSala()
        {
            try
            {
                if (tblSala == null)
                {
                    message = "No se ha asignado una sala para agregar";
                    return false;
                }
                var temp = oGym.TblSalas.FirstOrDefault(x => x.Ubicacion.ToLower() == tblSala.Ubicacion.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una sala con la misma ubicacion, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblSalas.Add(tblSala);
                oGym.SaveChanges();
                message = "Sala agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la sala, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarSala()
        {
            try
            {
                if (tblSala == null)
                {
                    message = "No se ha asignado una sala para modificar";
                    return false;
                }
                var existente = oGym.TblSalas.FirstOrDefault(x => x.Numero == tblSala.Numero);
                if (existente == null)
                {
                    message = "No se ha encontrado la sala para modificar, Reintentalo nuevamente.";
                    return false;
                }

                var duplicado = oGym.TblSalas.FirstOrDefault(x => x.Ubicacion.ToLower() == tblSala.Ubicacion.ToLower() && x.Numero != tblSala.Numero);
                if (duplicado != null)
                {
                    message = "Ya existe una sala con la misma ubicacion, Reintentalo nuevamente.";
                    return false;
                }

                existente.Ubicacion = tblSala.Ubicacion;
                existente.Capacidad = tblSala.Capacidad;
                existente.Activo = tblSala.Activo;
                existente.FkTamano = tblSala.FkTamano;
                existente.FkTipoSala = tblSala.FkTipoSala;
                oGym.SaveChanges();
                message = "Sala modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la sala, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarSala()
        {
            try
            {
                if (tblSala == null)
                {
                    message = "No se ha asignado una sala para eliminar";
                    return false;
                }
                var temp = oGym.TblSalas.FirstOrDefault(x => x.Numero == tblSala.Numero);
                if (temp == null)
                {
                    message = "No se ha encontrado la sala para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblSalas.Remove(temp);
                oGym.SaveChanges();
                message = "Sala eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la sala, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
