using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class membresiaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMembresia _op;

        public membresiaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMembresia(_context);
        }

        [HttpGet]
        public List<TblMembresium> Get() => _op.ListarMembresias();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarMembresias(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblMembresium obj)
        {
            _op.tblMembresia = obj;
            if (!_op.agregarMembresia())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblMembresium obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblMembresia = obj;
            if (!_op.modificarMembresia())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblMembresia = new TblMembresium { Codigo = id };
            if (!_op.eliminarMembresia())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
