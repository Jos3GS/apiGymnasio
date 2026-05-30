using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cargoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeCargo _op;

        public cargoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeCargo(_context);
        }

        [HttpGet]
        public ActionResult<List<TblCargo>> Get() => Ok(_op.ListarCargos());

        [HttpGet("{id}")]
        public ActionResult<TblCargo> Get(int id)
        {
            var res = _op.ListarCargos(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblCargo cargo)
        {
            _op.tblCargo = cargo;
            if (!_op.agregarCargo()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = cargo.Codigo }, cargo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblCargo cargo)
        {
            if (cargo == null || id != cargo.Codigo) return BadRequest("Id inválido");
            _op.tblCargo = cargo;
            if (!_op.modificarCargo()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblCargo = new TblCargo { Codigo = id };
            if (!_op.borrarCargo()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
