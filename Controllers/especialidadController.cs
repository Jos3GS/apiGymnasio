using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class especialidadController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEspecialidad _op;

        public especialidadController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEspecialidad(_context);
        }

        [HttpGet]
        public ActionResult<List<TblEspecialidad>> Get() => Ok(_op.ListarEspecialidades());

        [HttpGet("{id}")]
        public ActionResult<TblEspecialidad> Get(int id)
        {
            var res = _op.ListarEspecialidades(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblEspecialidad obj)
        {
            _op.tblEspecialidad = obj;
            if (!_op.agregarEspecialidad()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblEspecialidad obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblEspecialidad = obj;
            if (!_op.modificarEspecialidad()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblEspecialidad = new TblEspecialidad { Codigo = id };
            if (!_op.eliminarEspecialidad()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
