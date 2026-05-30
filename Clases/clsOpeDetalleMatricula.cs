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


    }
}
