using static apiGymnasio.Clases.Auxiliar.clsInscripCompleta;

namespace apiGymnasio.Clases.Auxiliar
{
    public class clsInscripCompleta
    {
        public class detalleInsc
        {
            public int FkClase { get; set; }

            public int FkMatricula { get; set; }
        }
    }

    public class inscripCompleta
    {
        public int Codigo { get; set; }
        public double MontoPagado { get; set; }

        public bool Recurrente { get; set; }

        public int UsuarioCrea { get; set; }

        public int FkFormaPago { get; set; }
        public required List<detalleInsc> inscritos { get; set; }
    }
}
