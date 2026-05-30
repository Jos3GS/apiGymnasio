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
        public List<TblUsuario> Get() => _op.ListarUsuarios();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarUsuarios(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblUsuario obj)
        {
            _op.tblUsuario = obj;
            if (!_op.agregarUsuario())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPost("login")]
        public object Login([FromBody] dynamic cred)
        {
            try
            {
                string usuario = cred.GetProperty("usuario").ToString();
                string clave = cred.GetProperty("clave").ToString();
                var res = _op.IniciarSesion(usuario, clave);
                if (res == null)
                {
                    Response.StatusCode = 401;
                    return new { message = "Credenciales inválidas" };
                }
                return res;
            }
            catch
            {
                Response.StatusCode = 400;
                return new { message = "Payload inválido" };
            }
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblUsuario obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblUsuario = obj;
            if (!_op.modificarUsuario())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblUsuario = new TblUsuario { Codigo = id };
            if (!_op.eliminarUsuario())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
