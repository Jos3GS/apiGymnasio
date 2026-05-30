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
        public object Get()
        {
            return _op.listarMonitores();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.listarMonitores(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] dynamic payload)
        {
            // payload expected: { empleado: {...}, monitor: {...} }
            try
            {
                var empleado = System.Text.Json.JsonSerializer.Deserialize<TblEmpleado>(payload.GetProperty("empleado").ToString());
                var monitor = System.Text.Json.JsonSerializer.Deserialize<TblMonitor>(payload.GetProperty("monitor").ToString());
                _op.tblMonitor = monitor;
                if (!_op.agregarMonitor(empleado))
                {
                    Response.StatusCode = 400;
                    return new { message = _op.message };
                }
                // Return both empleado and monitor in response body
                var response = new { empleado = empleado, monitor = monitor };
                Response.StatusCode = 201;
                return response;
            }
            catch
            {
                Response.StatusCode = 400;
                return new { message = "Payload inválido" };
            }
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] dynamic payload)
        {
            try
            {
                var empleado = System.Text.Json.JsonSerializer.Deserialize<TblEmpleado>(payload.GetProperty("empleado").ToString());
                var monitor = System.Text.Json.JsonSerializer.Deserialize<TblMonitor>(payload.GetProperty("monitor").ToString());
                if (monitor == null || empleado == null || monitor.NumeroId != id || empleado.NumeroId != id)
                {
                    Response.StatusCode = 400;
                    return new { message = "Id inválido" };
                }
                _op.tblMonitor = monitor;
                if (!_op.modificarMonitor(empleado))
                {
                    Response.StatusCode = 400;
                    return new { message = _op.message };
                }
                var response = new { empleado = empleado, monitor = monitor };
                return response;
            }
            catch
            {
                Response.StatusCode = 400;
                return new { message = "Payload inválido" };
            }
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            try
            {
                var empleado = _context.TblEmpleados.FirstOrDefault(x => x.NumeroId == id);
                var monitor = _context.TblMonitors.FirstOrDefault(x => x.NumeroId == id);
                if (monitor == null)
                {
                    Response.StatusCode = 404;
                    return new { message = "Monitor no encontrado" };
                }
                _op.tblMonitor = monitor;
                if (!_op.borrarMonitor(empleado))
                {
                    Response.StatusCode = 400;
                    return new { message = _op.message };
                }
                return new { message = _op.message };
            }
            catch
            {
                Response.StatusCode = 400;
                return new { message = "Error al eliminar" };
            }
        }
    }
}
