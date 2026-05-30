using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class estadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEstado _op;

        public estadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEstado(_context);
        }

        [HttpGet]
        public ActionResult<List<TblEstado>> Get() => Ok(_op.ListarEstados());

        [HttpGet("{id}")]
        public ActionResult<TblEstado> Get(int id)
        {
            var res = _op.ListarEstados(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblEstado obj)
        {
            _op.tblEstado = obj;
            if (!_op.agregarEstado()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblEstado obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblEstado = obj;
            if (!_op.modificarEstado()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblEstado = new TblEstado { Codigo = id };
            if (!_op.eliminarEstado()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
