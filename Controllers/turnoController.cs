using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class turnoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTurno _op;

        public turnoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTurno(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTurno>> Get() => Ok(_op.ListarTurno());

        [HttpGet("{id}")]
        public ActionResult<TblTurno> Get(int id)
        {
            var res = _op.ListarTurno(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTurno obj)
        {
            _op.tblTurno = obj;
            if (!_op.agregarTurno()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTurno obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTurno = obj;
            if (!_op.modificarTurno()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTurno = new TblTurno { Codigo = id };
            if (!_op.eliminarTurno()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
