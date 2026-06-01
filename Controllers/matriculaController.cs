using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class matriculaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMatricula _op;

        public matriculaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMatricula(_context);
        }

        [HttpGet]
        public List<TblMatricula> Get() => _op.listarMatriculas();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.listarMatriculas(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblMatricula obj)
        {
            _op.tblMatricula = obj;
            if (!_op.agregarMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblMatricula obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblMatricula = obj;
            if (!_op.modificarMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblMatricula = new TblMatricula { Codigo = id };
            if (!_op.eliminarMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
