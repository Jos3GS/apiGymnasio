using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class profesionController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeProfesion _op;

        public profesionController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeProfesion(_context);
        }

        [HttpGet]
        public ActionResult<List<TblProfesion>> Get() => Ok(_op.ListarProfesion());

        [HttpGet("{id}")]
        public ActionResult<TblProfesion> Get(int id)
        {
            var res = _op.ListarProfesion(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblProfesion obj)
        {
            _op.tblProfesion = obj;
            if (!_op.agregarProfesion()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblProfesion obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblProfesion = obj;
            if (!_op.modificarProfesion()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblProfesion = new TblProfesion { Codigo = id };
            if (!_op.eliminarProfesion()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
