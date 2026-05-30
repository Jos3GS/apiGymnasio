using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeSocio
    {
        private readonly BdgymnasioContext oGym;
        public TblSocio? tblSocio { get; set; }
        public string? message { get; set; }

        public clsOpeSocio(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblSocio> ListarSocios()
        {
            return oGym.TblSocios.OrderBy(x => x.Nombre).ToList();
        }

        public TblSocio? ListarSocios(int numeroId)
        {
            try
            {
                var temp = oGym.TblSocios.FirstOrDefault(x => x.NumeroId == numeroId);
                if (temp == null)
                {
                    message = "No se ha encontrado el socio, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el socio, Reintentalo nuevamente.";
                return null;
            }
        }

        public bool agregarSocio()
        {
            try
            {
                if (tblSocio == null)
                {
                    message = "No se ha asignado un socio para agregar";
                    return false;
                }
                var temp = oGym.TblSocios.FirstOrDefault(x => x.NumeroId == tblSocio.NumeroId);
                if (temp != null)
                {
                    message = "Ya existe un socio con el mismo número de identificación, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblSocios.Add(tblSocio);
                oGym.SaveChanges();
                message = "Socio agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el socio, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarSocio()
        {
            try
            {
                if (tblSocio == null)
                {
                    message = "No se ha asignado un socio para modificar";
                    return false;
                }
                var existente = oGym.TblSocios.FirstOrDefault(x => x.NumeroId == tblSocio.NumeroId);
                if (existente == null)
                {
                    message = "No se ha encontrado el socio para modificar, Reintentalo nuevamente.";
                    return false;
                }

                existente.FechaAfiliacion = tblSocio.FechaAfiliacion;
                existente.ObservacionMedica = tblSocio.ObservacionMedica;
                existente.Codigo = tblSocio.Codigo;
                existente.Nombre = tblSocio.Nombre;
                existente.Apellido = tblSocio.Apellido;
                existente.UsuarioCrea = tblSocio.UsuarioCrea;
                existente.FkProfesion = tblSocio.FkProfesion;
                existente.FkTipoDocumento = tblSocio.FkTipoDocumento;
                existente.FkEstado = tblSocio.FkEstado;
                existente.FkMembresia = tblSocio.FkMembresia;
                oGym.SaveChanges();
                message = "Socio modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el socio, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarSocio()
        {
            try
            {
                if (tblSocio == null)
                {
                    message = "No se ha asignado un socio para eliminar";
                    return false;
                }
                var temp = oGym.TblSocios.FirstOrDefault(x => x.NumeroId == tblSocio.NumeroId);
                if (temp == null)
                {
                    message = "No se ha encontrado el socio para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblSocios.Remove(temp);
                oGym.SaveChanges();
                message = "Socio eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el socio, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
