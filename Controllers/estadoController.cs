using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class estadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEstado _op;

        public estadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEstado(_context);
        }

        [HttpGet]
        public List<TblEstado> Get() => _op.ListarEstados();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarEstados(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblEstado obj)
        {
            _op.tblEstado = obj;
            if (!_op.agregarEstado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return new { message = _op.message };
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblEstado obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblEstado = obj;
            if (!_op.modificarEstado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblEstado = new TblEstado { Codigo = id };
            if (!_op.eliminarEstado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
