using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telSocioSocioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelSocioSocio _op;

        public telSocioSocioController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelSocioSocio(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTelSocioSocio>> Get() => Ok(_op.Listar());

        [HttpGet("{id}")]
        public ActionResult<TblTelSocioSocio> Get(int id)
        {
            var res = _op.Listar(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTelSocioSocio obj)
        {
            _op.tblTel = obj;
            if (!_op.agregar()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTelSocioSocio obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTel = obj;
            if (!_op.modificar()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTel = new TblTelSocioSocio { Codigo = id };
            if (!_op.borrar()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
