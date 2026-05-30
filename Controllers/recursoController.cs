using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class recursoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeRecurso _op;

        public recursoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeRecurso(_context);
        }

        [HttpGet]
        public ActionResult<List<TblRecurso>> Get() => Ok(_op.listarRecursos());

        [HttpGet("marca/{id}")]
        public ActionResult<List<TblRecurso>> GetByMarca(int id)
        {
            var res = _op.listarRecursosXMarca(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("sala/{id}")]
        public ActionResult<List<TblRecurso>> GetBySala(int id)
        {
            var res = _op.listarRecursosXSala(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("estado/{id}")]
        public ActionResult<List<TblRecurso>> GetByEstado(int id)
        {
            var res = _op.listarRecursosXEstadoConservacion(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult<TblRecurso> Get(int id)
        {
            var res = _op.listarRecurso(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblRecurso obj)
        {
            _op.tblRecurso = obj;
            if (!_op.agregarRecurso()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblRecurso obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblRecurso = obj;
            if (!_op.modificarRecurso()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblRecurso = new TblRecurso { Codigo = id };
            if (!_op.eliminarRecurso()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
