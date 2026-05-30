using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<TblTelefonoEmpleado>> Get() => Ok(_op.ListarTelefonos());

        [HttpGet("{codigo}")]
        public ActionResult<TblTelefonoEmpleado> Get(int codigo)
        {
            var res = _op.ListarTelefonos(codigo);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTelefonoEmpleado obj)
        {
            _op.tblTelefonoEmpleado = obj;
            if (!_op.agregarTelefono()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { codigo = obj.Codigo }, obj);
        }

        [HttpPut("{codigo}")]
        public ActionResult Put(int codigo, [FromBody] TblTelefonoEmpleado obj)
        {
            if (obj == null || codigo != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTelefonoEmpleado = obj;
            if (!_op.modificarTelefono()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(int codigo)
        {
            _op.tblTelefonoEmpleado = new TblTelefonoEmpleado { Codigo = codigo };
            if (!_op.borrarTelefono()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
