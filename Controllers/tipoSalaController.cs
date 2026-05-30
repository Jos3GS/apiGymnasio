using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tipoSalaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTipoSala _op;

        public tipoSalaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTipoSala(_context);
        }

        [HttpGet]
        public List<TblTipoSala> Get() => _op.ListarTipoSala();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarTipoSala(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTipoSala obj)
        {
            _op.tblTipoSala = obj;
            if (!_op.agregarTipoSala())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTipoSala obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTipoSala = obj;
            if (!_op.modificarTipoSala())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTipoSala = new TblTipoSala { Codigo = id };
            if (!_op.eliminarTipoSala())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
