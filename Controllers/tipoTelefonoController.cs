using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tipoTelefonoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTipoTelefono _op;

        public tipoTelefonoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTipoTelefono(_context);
        }

        [HttpGet]
        public List<TblTipoTelefono> Get() => _op.ListarTipoTelefono();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarTipoTelefono(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTipoTelefono obj)
        {
            _op.tblTipoTelefono = obj;
            if (!_op.agregarTipoTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTipoTelefono obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTipoTelefono = obj;
            if (!_op.modificarTipoTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTipoTelefono = new TblTipoTelefono { Codigo = id };
            if (!_op.eliminarTipoTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
