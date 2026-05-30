using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tipoSalaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTipoSala _op;

        public tipoSalaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTipoSala(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTipoSala>> Get() => Ok(_op.ListarTipoSala());

        [HttpGet("{id}")]
        public ActionResult<TblTipoSala> Get(int id)
        {
            var res = _op.ListarTipoSala(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTipoSala obj)
        {
            _op.tblTipoSala = obj;
            if (!_op.agregarTipoSala()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTipoSala obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTipoSala = obj;
            if (!_op.modificarTipoSala()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTipoSala = new TblTipoSala { Codigo = id };
            if (!_op.eliminarTipoSala()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
