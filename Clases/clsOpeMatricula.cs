using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeMatricula
    {
        private readonly BdgymnasioContext oGym;
        public TblMatricula? tblMatricula { get; set; }
        public string? message { get; set; }

        public clsOpeMatricula(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblMatricula> listarMatriculas()
        {
            return oGym.TblMatriculas.OrderBy(x => x.FechaInicio).ToList();
        }

        public TblMatricula? listarMatriculas(int codigo)
        {
            try
            {
                var temp = oGym.TblMatriculas.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la matrícula para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch 
            {
                message = "Error al buscar la matrícula. Reintentalo nuevamente.";
                return null;
            }
        }



        public bool agregarMatricula()
        {
            try
            {
                if (tblMatricula == null)
                {
                    message = "No se proporcionó información de matrícula.";
                    return false;
                }
                oGym.Add(tblMatricula);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al agregar la matrícula. Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarMatricula()
        {
            try
            {
                if (tblMatricula == null)
                {
                    message = "No se proporcionó información de matrícula.";
                    return false;
                }
                var temp = oGym.TblMatriculas.FirstOrDefault(x => x.Codigo == tblMatricula.Codigo);
                if (temp == null)
                {
                    message = "No se encontró la matrícula a modificar.";
                    return false;
                }
                oGym.Update(tblMatricula);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al modificar la matrícula. Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarMatricula()
        {
            try
            {
                if (tblMatricula == null)
                {
                    message = "No se proporcionó información de matrícula.";
                    return false;
                }
                var temp = oGym.TblMatriculas.FirstOrDefault(x => x.Codigo == tblMatricula.Codigo);
                if (temp == null)
                {
                    message = "No se encontró la matrícula a eliminar.";
                    return false;
                }
                oGym.Remove(tblMatricula);
                oGym.SaveChanges();
                return true;
            }
            catch
            {
                message = "Error al eliminar la matrícula. Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
