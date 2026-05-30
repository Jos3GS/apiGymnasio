using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telefonoEmpleadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelefonoEmpleado _op;

        public telefonoEmpleadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelefonoEmpleado(_context);
        }

        [HttpGet]
        public List<TblTelefonoEmpleado> Get() => _op.ListarTelefonos();

        [HttpGet("{codigo}")]
        public object Get(int codigo)
        {
            var res = _op.ListarTelefonos(codigo);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("empleado/{id}")]
        public object GetByEmpleado(int id)
        {
            var links = _context.TblTelEmpleadoEmpleados.Where(x => x.FkEmpleado == id).ToList();
            var phoneIds = links.Select(x => x.FkTelefonoEmpleado).Where(x => x.HasValue).Select(x => x.Value).ToList();
            var phones = _context.TblTelefonoEmpleados.Where(x => phoneIds.Contains(x.Codigo)).ToList();
            if (phones == null || phones.Count == 0)
            {
                Response.StatusCode = 404;
                return new { message = "No se han encontrado teléfonos para el empleado" };
            }
            return phones;
        }

        [HttpPost]
        public object Post([FromBody] TblTelefonoEmpleado obj)
        {
            _op.tblTelefonoEmpleado = obj;
            if (!_op.agregarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{codigo}")]
        public object Put(int codigo, [FromBody] TblTelefonoEmpleado obj)
        {
            if (obj == null || codigo != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTelefonoEmpleado = obj;
            if (!_op.modificarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{codigo}")]
        public object Delete(int codigo)
        {
            _op.tblTelefonoEmpleado = new TblTelefonoEmpleado { Codigo = codigo };
            if (!_op.borrarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
