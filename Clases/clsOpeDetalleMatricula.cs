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

        public List<TblDetalleMatricula> listarDetalleMatriculas(int codigo)
        {
            return oGym.TblDetalleMatriculas.OrderBy(x => x.FechaMatricula).Where(x => x.FkMatricula == codigo).ToList();
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

        public bool agregarDetalleMatricula(int codigo, int idClase)
        {
            try
            {
                TblDetalleMatricula temp = new TblDetalleMatricula()
                {
                    FechaMatricula = DateOnly.Parse(DateTime.Now.ToShortDateString()),
                    FkClase = idClase,
                    FkMatricula = codigo
                };
                if (temp == null)
                {
                    message = "No se proporcionó información de detalle de matrícula.";
                    return false;
                }
                oGym.TblDetalleMatriculas.Add(temp);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al agregar el detalle de matrícula. Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarDetalleMatricula(int codigo, int matricula)
        {
            try
            {
                var temp = oGym.TblDetalleMatriculas.FirstOrDefault(x => x.FkClase == codigo && x.FkMatricula == matricula);
                if (temp == null)
                {
                    message = "No se proporcionó información de detalle de matrícula.";
                    return false;
                }
                oGym.TblDetalleMatriculas.Remove(temp);
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
