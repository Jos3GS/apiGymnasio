using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class turnoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTurno _op;

        public turnoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTurno(_context);
        }

        [HttpGet]
        public List<TblTurno> Get() => _op.ListarTurno();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarTurno(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTurno obj)
        {
            _op.tblTurno = obj;
            if (!_op.agregarTurno())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTurno obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTurno = obj;
            if (!_op.modificarTurno())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTurno = new TblTurno { Codigo = id };
            if (!_op.eliminarTurno())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
