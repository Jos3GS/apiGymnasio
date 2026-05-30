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
        public ActionResult<List<TblEmpleado>> Get() => Ok(_op.ListarEmpleados());

        [HttpGet("cargo/{id}")]
        public ActionResult<List<TblEmpleado>> GetByCargo(int id)
        {
            var res = _op.buscarEmpleadosXCargo(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("turno/{id}")]
        public ActionResult<List<TblEmpleado>> GetByTurno(int id)
        {
            var res = _op.buscarEmpleadoXTurno(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("especialidad/{id}")]
        public ActionResult<List<TblEmpleado>> GetByEspecialidad(int id)
        {
            var res = _op.buscarEmpleadoXEspecialidad(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<TblEmpleado> GetByUsuario(int id)
        {
            var res = _op.buscarEmpleadoXUsuario(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult<TblEmpleado> Get(int id)
        {
            var res = _op.buscarEmpleadoXNumeroId(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblEmpleado empleado)
        {
            _op.tblEmpleado = empleado;
            if (!_op.agregarEmpleado()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = empleado.NumeroId }, empleado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblEmpleado empleado)
        {
            if (empleado == null || id != empleado.NumeroId) return BadRequest("Id inválido");
            _op.tblEmpleado = empleado;
            if (!_op.modificarEmpleado()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblEmpleado = new TblEmpleado { NumeroId = id };
            if (!_op.borrarEmpleado()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
