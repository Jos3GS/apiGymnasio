using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class salaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeSala _op;

        public salaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeSala(_context);
        }

        [HttpGet]
        public ActionResult<List<TblSala>> Get() => Ok(_op.ListarSalas());

        [HttpGet("{numero}")]
        public ActionResult<TblSala> Get(int numero)
        {
            var res = _op.ListarSalas(numero);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblSala obj)
        {
            _op.tblSala = obj;
            if (!_op.agregarSala()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { numero = obj.Numero }, obj);
        }

        [HttpPut("{numero}")]
        public ActionResult Put(int numero, [FromBody] TblSala obj)
        {
            if (obj == null || numero != obj.Numero) return BadRequest("Id inválido");
            _op.tblSala = obj;
            if (!_op.modificarSala()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{numero}")]
        public ActionResult Delete(int numero)
        {
            _op.tblSala = new TblSala { Numero = numero };
            if (!_op.borrarSala()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
