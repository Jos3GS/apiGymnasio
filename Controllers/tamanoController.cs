using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tamanoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTamano _op;

        public tamanoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTamano(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTamano>> Get() => Ok(_op.ListarTamano());

        [HttpGet("{id}")]
        public ActionResult<TblTamano> Get(int id)
        {
            var res = _op.ListarTamano(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTamano obj)
        {
            _op.tblTamano = obj;
            if (!_op.agregarTamano()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTamano obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTamano = obj;
            if (!_op.modificarTamano()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTamano = new TblTamano { Codigo = id };
            if (!_op.eliminarTamano()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
