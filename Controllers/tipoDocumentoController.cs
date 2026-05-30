using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tipoDocumentoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTipoDocumento _op;

        public tipoDocumentoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTipoDocumento(_context);
        }

        [HttpGet]
        public ActionResult<List<TblTipoDocumento>> Get() => Ok(_op.ListarTipoDocumento());

        [HttpGet("{id}")]
        public ActionResult<TblTipoDocumento> Get(int id)
        {
            var res = _op.ListarTipoDocumento(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblTipoDocumento obj)
        {
            _op.tblTipoDocumento = obj;
            if (!_op.agregarTipoDocumento()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblTipoDocumento obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblTipoDocumento = obj;
            if (!_op.modificarTipoDocumento()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblTipoDocumento = new TblTipoDocumento { Codigo = id };
            if (!_op.eliminarTipoDocumento()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
