using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telEmpleadoEmpleadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelEmpleadoEmpleado _op;

        public telEmpleadoEmpleadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelEmpleadoEmpleado(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTelEmpleadoEmpleado>> Get() => Ok(_op.Listar());

        [HttpGet("{id}")]
        public ActionResult<TblTelEmpleadoEmpleado> Get(int id)
        {
            var res = _op.Listar(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTelEmpleadoEmpleado obj)
        {
            _op.tblTel = obj;
            if (!_op.agregar()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTelEmpleadoEmpleado obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTel = obj;
            if (!_op.modificar()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTel = new TblTelEmpleadoEmpleado { Codigo = id };
            if (!_op.borrar()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
