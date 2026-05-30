using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class membresiaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMembresia _op;

        public membresiaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMembresia(_context);
        }

        [HttpGet]
        public ActionResult<List<TblMembresium>> Get() => Ok(_op.ListarMembresias());

        [HttpGet("{id}")]
        public ActionResult<TblMembresium> Get(int id)
        {
            var res = _op.ListarMembresias(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblMembresium obj)
        {
            _op.tblMembresia = obj;
            if (!_op.agregarMembresia()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblMembresium obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblMembresia = obj;
            if (!_op.modificarMembresia()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblMembresia = new TblMembresium { Codigo = id };
            if (!_op.eliminarMembresia()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
