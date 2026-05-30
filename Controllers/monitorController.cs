using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class monitorController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMonitor _op;

        public monitorController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMonitor(_context);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_op.listarMonitores());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var res = _op.listarMonitores(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] dynamic payload)
        {
            // payload expected: { empleado: {...}, monitor: {...} }
            try
            {
                var empleado = System.Text.Json.JsonSerializer.Deserialize<TblEmpleado>(payload.GetProperty("empleado").ToString());
                var monitor = System.Text.Json.JsonSerializer.Deserialize<TblMonitor>(payload.GetProperty("monitor").ToString());
                _op.tblMonitor = monitor;
                if (!_op.agregarMonitor(empleado)) return BadRequest(_op.message);
                // Return both empleado and monitor in response body
                var response = new { empleado = empleado, monitor = monitor };
                return CreatedAtAction(nameof(Get), new { id = monitor.NumeroId }, response);
            }
            catch
            {
                return BadRequest("Payload inválido");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] dynamic payload)
        {
            try
            {
                var empleado = System.Text.Json.JsonSerializer.Deserialize<TblEmpleado>(payload.GetProperty("empleado").ToString());
                var monitor = System.Text.Json.JsonSerializer.Deserialize<TblMonitor>(payload.GetProperty("monitor").ToString());
                if (monitor == null || empleado == null || monitor.NumeroId != id || empleado.NumeroId != id) return BadRequest("Id inválido");
                _op.tblMonitor = monitor;
                if (!_op.modificarMonitor(empleado)) return BadRequest(_op.message);
                var response = new { empleado = empleado, monitor = monitor };
                return Ok(response);
            }
            catch
            {
                return BadRequest("Payload inválido");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var empleado = _context.TblEmpleados.FirstOrDefault(x => x.NumeroId == id);
                var monitor = _context.TblMonitors.FirstOrDefault(x => x.NumeroId == id);
                if (monitor == null) return NotFound("Monitor no encontrado");
                _op.tblMonitor = monitor;
                if (!_op.borrarMonitor(empleado)) return BadRequest(_op.message);
                return Ok(_op.message);
            }
            catch
            {
                return BadRequest("Error al eliminar");
            }
        }
    }
}
