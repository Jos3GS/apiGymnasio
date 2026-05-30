using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ciudadController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeCiudad _op;

        public ciudadController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeCiudad(_context);
        }

        [HttpGet]
        public ActionResult<List<TblCiudad>> Get() => Ok(_op.ListarCiudades());

        [HttpGet("{id}")]
        public ActionResult<TblCiudad> Get(int id)
        {
            var res = _op.ListarCiudades(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblCiudad ciudad)
        {
            _op.tblCiudad = ciudad;
            if (!_op.agregarCiudad()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = ciudad.Codigo }, ciudad);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblCiudad ciudad)
        {
            if (ciudad == null || id != ciudad.Codigo) return BadRequest("Id inválido");
            _op.tblCiudad = ciudad;
            if (!_op.modificarCiudad()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblCiudad = new TblCiudad { Codigo = id };
            if (!_op.borrarCiudad()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
