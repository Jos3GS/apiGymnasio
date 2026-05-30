using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class marcasController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMarca _op;

        public marcasController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMarca(_context);
        }

        [HttpGet]
        public ActionResult<List<TblMarca>> Get() => Ok(_op.ListarMarcas());

        [HttpGet("{id}")]
        public ActionResult<TblMarca> Get(int id)
        {
            var res = _op.ListarMarcas(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblMarca obj)
        {
            _op.tblMarca = obj;
            if (!_op.agregarMarca()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblMarca obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblMarca = obj;
            if (!_op.modificarMarca()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblMarca = new TblMarca { Codigo = id };
            if (!_op.eliminarMarca()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
