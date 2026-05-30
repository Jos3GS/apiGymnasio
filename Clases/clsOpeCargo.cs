using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeCargo
    {
        private readonly BdgymnasioContext oGym;
        public TblCargo? tblCargo { get; set; }
        public string? message { get; set; }

        public clsOpeCargo(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblCargo> ListarCargos()
        {
            return oGym.TblCargos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public bool agregarCargo()
        {
            try
            {
                if (tblCargo == null)
                {
                    message = "No se ha asignado un cargo para agregar";
                    return false;
                }
                var temp = oGym.TblCargos.FirstOrDefault(x => x.Nombre.ToLower() == tblCargo.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe un cargo con ese nombre";
                    return false;
                }
                oGym.TblCargos.Add(tblCargo);
                oGym.SaveChanges();
                message = "Cargo agregado correctamente";
                return true;

            }
            catch
            {
                message = "Error al agregar el cargo, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarCargo()
        {
            try
            {
                if (tblCargo == null)
                {
                    message = "No se ha asignado un cargo para modificar";
                    return false;
                }
                var temp = oGym.TblCargos.FirstOrDefault(x => x.Codigo == tblCargo.Codigo);
                if (temp == null)
                {
                    message = "No se encontro el cargo a modificar";
                    return false;
                }
                temp = oGym.TblCargos.FirstOrDefault(x => x.Nombre.ToLower() == tblCargo.Nombre.ToLower());
                if(temp != null)
                {
                    message = "El nombre del cargo no puede ser igual a uno existente";
                    return false;
                }

                oGym.TblCargos.Update(tblCargo);
                oGym.SaveChanges();
                message = "Cargo modificado correctamente";
                return true;
            }
            catch
            {
                message = "Error al modificar el cargo, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool borrarCargo()
        {
            try
            {
                if(tblCargo == null)
                {
                    message = "No se ha asignado un cargo para eliminar";
                    return false;
                }
                var temp = oGym.TblCargos.FirstOrDefault(x => x.Codigo == tblCargo.Codigo);
                if(temp == null)
                {
                    message = "No se encontro el cargo a eliminar";
                    return false;
                }
                oGym.TblCargos.Remove(temp);
                oGym.SaveChanges();
                message = "Cargo eliminado correctamente";
                return true;
            }
            catch
            {
                message = "Error al eliminar el cargo, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
