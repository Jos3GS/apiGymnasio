using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class empleadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEmpleado _op;

        public empleadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEmpleado(_context);
        }

        [HttpGet]
        public List<TblEmpleado> Get() => _op.ListarEmpleados();

        [HttpGet("cargo/{id}")]
        public object GetByCargo(int id)
        {
            var res = _op.buscarEmpleadosXCargo(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("turno/{id}")]
        public object GetByTurno(int id)
        {
            var res = _op.buscarEmpleadoXTurno(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("especialidad/{id}")]
        public object GetByEspecialidad(int id)
        {
            var res = _op.buscarEmpleadoXEspecialidad(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("usuario/{id}")]
        public object GetByUsuario(int id)
        {
            var res = _op.buscarEmpleadoXUsuario(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.buscarEmpleadoXNumeroId(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblEmpleado empleado)
        {
            _op.tblEmpleado = empleado;
            if (!_op.agregarEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return empleado;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblEmpleado empleado)
        {
            if (empleado == null || id != empleado.NumeroId)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblEmpleado = empleado;
            if (!_op.modificarEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblEmpleado = new TblEmpleado { NumeroId = id };
            if (!_op.borrarEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
