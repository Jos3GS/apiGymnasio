using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class claseController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeClase _opclase;

        public claseController(BdgymnasioContext context)
        {
            _context = context;
            _opclase = new clsOpeClase(_context);
        }

        [HttpGet]
        public ActionResult<List<TblClase>> Get()
        {
            return Ok(_opclase.listarClases());
        }
        [HttpGet("monitor/{id}")]
        public ActionResult<List<TblClase>> GetByMonitor(int id)
        {
            var res = _opclase.listarClasesXMonitor(id);
            if (res == null) return NotFound(_opclase.message);
            return Ok(res);
        }

        [HttpGet("sala/{id}")]
        public ActionResult<List<TblClase>> GetBySala(int id)
        {
            var res = _opclase.listarClasesXSala(id);
            if (res == null) return NotFound(_opclase.message);
            return Ok(res);
        }

        [HttpGet("especialidad/{id}")]
        public ActionResult<List<TblClase>> GetByEspecialidad(int id)
        {
            var res = _opclase.listarClasesXEspecialidad(id);
            if (res == null) return NotFound(_opclase.message);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult<TblClase> Get(int id)
        {
            var res = _opclase.listarClases(id);
            if (res == null) return NotFound(_opclase.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblClase clase)
        {
            _opclase.tblClase = clase;
            var ok = _opclase.agregarClase();
            if (!ok) return BadRequest(_opclase.message);
            return CreatedAtAction(nameof(Get), new { id = clase.Codigo }, clase);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblClase clase)
        {
            if (clase == null || id != clase.Codigo) return BadRequest("Id inválido");
            _opclase.tblClase = clase;
            var ok = _opclase.modificarClase();
            if (!ok) return BadRequest(_opclase.message);
            return Ok(_opclase.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _opclase.tblClase = new TblClase { Codigo = id };
            var ok = _opclase.eliminarClase();
            if (!ok) return BadRequest(_opclase.message);
            return Ok(_opclase.message);
        }
    }
}
