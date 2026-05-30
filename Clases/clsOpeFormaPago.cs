using apiGymnasio.Models;

namespace apiGymnasio.Clases
{
    public class clsOpeFormaPago
    {
        private readonly BdgymnasioContext oGym;
        public TblFormaPago? tblFormaPago { get; set; }
        public string? message { get; set; }

        public clsOpeFormaPago(BdgymnasioContext oGym)
        {
            this.oGym = oGym;
        }

        public List<TblFormaPago> Listar()
        {
            return oGym.TblFormaPagos.OrderBy(x => x.Nombre).Where(x => x.Activo == true).ToList();
        }

        public bool agregarFormaPago()
        {
            try
            {
                if (tblFormaPago == null)
                {
                    message = "No se ha asignado una forma de pago para agregar";
                    return false;
                }
                var temp = oGym.TblFormaPagos.FirstOrDefault(x => x.Nombre.ToLower() == tblFormaPago.Nombre.ToLower());
                if (temp != null)
                {
                    message = "Ya existe una forma de pago con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblFormaPagos.Add(tblFormaPago);
                oGym.SaveChanges();
                message = "Forma de pago agregada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al agregar la forma de pago, Reintentalo nuevamente.";
                return false;
            }
        }

        public bool modificarFormaPago()
        {
            try
            {
                if (tblFormaPago == null)
                {
                    message = "No se ha asignado una forma de pago para modificar";
                    return false;
                }
                var temp = oGym.TblFormaPagos.FirstOrDefault(x => x.Codigo == tblFormaPago.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la forma de pago para modificar, Reintentalo nuevamente.";
                    return false;
                }
                temp = oGym.TblFormaPagos.FirstOrDefault(x => x.Nombre.ToLower() == tblFormaPago.Nombre.ToLower() && x.Codigo != tblFormaPago.Codigo);
                if (temp != null)
                {
                    message = "Ya existe una forma de pago con el mismo nombre, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblFormaPagos.Update(tblFormaPago);
                oGym.SaveChanges();
                message = "Forma de pago modificada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al modificar la forma de pago, Reintentalo nuevamente.";
                return false;
            }

        }

        public bool eliminarFormaPago()
        {
            try
            {
                if (tblFormaPago == null)
                {
                    message = "No se ha asignado una forma de pago para eliminar";
                    return false;
                }
                var temp = oGym.TblFormaPagos.FirstOrDefault(x => x.Codigo == tblFormaPago.Codigo);
                if (temp == null)
                {
                    message = "No se ha encontrado la forma de pago para eliminar, Reintentalo nuevamente.";
                    return false;
                }
                oGym.TblFormaPagos.Remove(temp);
                oGym.SaveChanges();
                message = "Forma de pago eliminada correctamente.";
                return true;
            }
            catch
            {
                message = "Error al eliminar la forma de pago, Reintentalo nuevamente.";
                return false;
            }
        }
    }
}
