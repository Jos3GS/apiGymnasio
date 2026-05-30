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

        public int agregarMatricula()
        {
            try
            {
                if(tblMatricula == null)
                {
                    message = "No se proporcionó información de matrícula.";
                    return -1;
                }
                oGym.Add(tblMatricula);
                oGym.SaveChanges();
                return oGym.TblMatriculas.Max(x => x.Codigo);
            }
            catch
            {
                message = "Error al agregar la matrícula. Reintentalo nuevamente.";
                return -1;
            }
        }
    }
}
