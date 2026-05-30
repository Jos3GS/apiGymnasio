using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class socioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeSocio _opsocio;

        public socioController(BdgymnasioContext context)
        {
            _context = context;
            _opsocio = new clsOpeSocio(_context);
        }

        [HttpGet]
        public ActionResult<List<TblSocio>> Get()
        {
            return Ok(_opsocio.ListarSocios());
        }

        [HttpGet("{id}")]
        public ActionResult<TblSocio> Get(int id)
        {
            var res = _opsocio.ListarSocios(id);
            if (res == null) return NotFound(_opsocio.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblSocio socio)
        {
            _opsocio.tblSocio = socio;
            var ok = _opsocio.agregarSocio();
            if (!ok) return BadRequest(_opsocio.message);
            return CreatedAtAction(nameof(Get), new { id = socio.NumeroId }, socio);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblSocio socio)
        {
            if (socio == null || id != socio.NumeroId) return BadRequest("Id inválido");
            _opsocio.tblSocio = socio;
            var ok = _opsocio.modificarSocio();
            if (!ok) return BadRequest(_opsocio.message);
            return Ok(_opsocio.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _opsocio.tblSocio = new TblSocio { NumeroId = id };
            var ok = _opsocio.borrarSocio();
            if (!ok) return BadRequest(_opsocio.message);
            return Ok(_opsocio.message);
        }
    }
}
