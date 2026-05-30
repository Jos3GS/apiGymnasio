using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeRecurso
    {
        private readonly BdgymnasioContext oGym;
        public TblRecurso? tblRecurso { get; set; }
        public string? message { get; set; }
        public clsOpeRecurso(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblRecurso> listarRecursos()
        {
            return oGym.TblRecursos.OrderBy(x => x.Codigo).Where(x => x.Activo == true).ToList();
        }

        public TblRecurso? listarRecurso(int codigo)
        {
            try
            {
                var temp = oGym.TblRecursos.FirstOrDefault(x => x.Codigo == codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el recurso para el código ingresado, Reintentalo nuevamente.";
                    return null;
                }
                return temp;
            }
            catch
            {
                message = "Error al listar el recurso, Reintentalo nuevamente.";
                return null;
            }
        }

        public List<TblRecurso> listarRecursosXMarca(int codigo)
        {
            return oGym.TblRecursos.OrderBy(x => x.Codigo).Where(x => x.FkMarca == codigo).ToList();
        } 

        public List<TblRecurso> listarRecursosXSala(int codigo)
        {
            return oGym.TblRecursos.OrderBy(x => x.Codigo).Where(x => x.FkSala == codigo).ToList();
        }

        public List<TblRecurso> listarRecursosXEstadoConservacion (int codigo)
        {
            return oGym.TblRecursos.OrderBy(x => x.Codigo).Where(x => x.FkEstadoConservacion == codigo).ToList();
        }

        public bool agregarRecurso()
        {
            try
            {
                if (tblRecurso == null)
                {
                    message = "No se ha asignado un recurso para agregar";
                    return false;
                }
                var temp = oGym.TblRecursos.FirstOrDefault(x => x.Descripcion.ToLower() == tblRecurso.Descripcion.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un recurso con la misma descripción, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblRecursos.Add(tblRecurso);
                oGym.SaveChanges();
                message = "Recurso agregado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar el recurso, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarRecurso()
        {
            try
            {
                if (tblRecurso == null)
                {
                    message = "No se ha asignado un recurso para modificar";
                    return false;
                }
                var existente = oGym.TblRecursos.FirstOrDefault(x => x.Codigo == tblRecurso.Codigo);
                if (existente == null)
                {
                    message = "No se ha encontrado el recurso para el código ingresado, Reintentalo nuevamente.";
                    return false;
                }

                var duplicado = oGym.TblRecursos.FirstOrDefault(x => x.Descripcion.ToLower() == tblRecurso.Descripcion.ToLower() && x.Codigo != tblRecurso.Codigo);
                if (duplicado != null)
                {
                    message = "Ya existe un recurso con la misma descripción, Reintentalo nuevamente.";
                    return false;
                }

                existente.Descripcion = tblRecurso.Descripcion;
                existente.FechaCompra = tblRecurso.FechaCompra;
                existente.Activo = tblRecurso.Activo;
                existente.UsuarioCrea = tblRecurso.UsuarioCrea;
                existente.FkSala = tblRecurso.FkSala;
                existente.FkEstadoConservacion = tblRecurso.FkEstadoConservacion;
                existente.FkMarca = tblRecurso.FkMarca;
                oGym.SaveChanges();
                message = "Recurso modificado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar el recurso, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool eliminarRecurso()
        {
            try
            {
                if (tblRecurso == null)
                {
                    message = "No se ha asignado un recurso para eliminar";
                    return false;
                }
                var temp = oGym.TblRecursos.FirstOrDefault(x => x.Codigo == tblRecurso.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado el recurso para el código ingresado, Reintentalo nuevamente.";
                    return false;
                }
                oGym.Remove(temp);
                oGym.SaveChanges();
                message = "Recurso eliminado correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar el recurso, Reintentalo nuevamente.";
                return false;
            }


        }
    }
}
