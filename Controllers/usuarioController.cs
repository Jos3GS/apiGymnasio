using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usuarioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeUsuario _op;

        public usuarioController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeUsuario(_context);
        }

        [HttpGet]
        public ActionResult<List<TblUsuario>> Get() => Ok(_op.ListarUsuarios());

        [HttpGet("{id}")]
        public ActionResult<TblUsuario> Get(int id)
        {
            var res = _op.ListarUsuarios(id);
            if (res == null) return NotFound(_op.message);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TblUsuario obj)
        {
            _op.tblUsuario = obj;
            if (!_op.agregarUsuario()) return BadRequest(_op.message);
            return CreatedAtAction(nameof(Get), new { id = obj.Codigo }, obj);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] dynamic cred)
        {
            try
            {
                string usuario = cred.GetProperty("usuario").ToString();
                string clave = cred.GetProperty("clave").ToString();
                var res = _op.IniciarSesion(usuario, clave);
                if (res == null) return Unauthorized("Credenciales inválidas");
                return Ok(res);
            }
            catch
            {
                return BadRequest("Payload inválido");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblUsuario obj)
        {
            if (obj == null || id != obj.Codigo) return BadRequest("Id inválido");
            _op.tblUsuario = obj;
            if (!_op.modificarUsuario()) return BadRequest(_op.message);
            return Ok(_op.message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _op.tblUsuario = new TblUsuario { Codigo = id };
            if (!_op.eliminarUsuario()) return BadRequest(_op.message);
            return Ok(_op.message);
        }
    }
}
