using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeDetalleMatricula
    {
        private readonly BdgymnasioContext oGym;
        public TblDetalleMatricula? tblDetalleMatricula { get; set; }
        public string? message { get; set; }

        public clsOpeDetalleMatricula(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblDetalleMatricula> listarDetalleMatriculas()
        {
            return oGym.TblDetalleMatriculas.OrderBy(x => x.Codigo).ToList();
        }

        public bool agregarDetalleMatricula()
        {
            try
            {
                if (tblDetalleMatricula == null)
                {
                    message = "No se proporcionó información de detalle de matrícula.";
                    return false;
                }
                oGym.Add(tblDetalleMatricula);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al agregar el detalle de matrícula. Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarDetalleMatricula()
        {
            try
            {
                if (tblDetalleMatricula == null)
                {
                    message = "No se proporcionó información de detalle de matrícula.";
                    return false;
                }
                oGym.Remove(tblDetalleMatricula);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al eliminar el detalle de matrícula. Reintentalo nuevamente.";
                return false;
            }
        }


    }
}
