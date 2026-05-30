using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class recursoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeRecurso _op;

        public recursoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeRecurso(_context);
        }

        [HttpGet]
        public List<TblRecurso> Get() => _op.listarRecursos();

        [HttpGet("marca/{id}")]
        public object GetByMarca(int id)
        {
            var res = _op.listarRecursosXMarca(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("sala/{id}")]
        public object GetBySala(int id)
        {
            var res = _op.listarRecursosXSala(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("estado/{id}")]
        public object GetByEstado(int id)
        {
            var res = _op.listarRecursosXEstadoConservacion(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.listarRecurso(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblRecurso obj)
        {
            _op.tblRecurso = obj;
            if (!_op.agregarRecurso())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblRecurso obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblRecurso = obj;
            if (!_op.modificarRecurso())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblRecurso = new TblRecurso { Codigo = id };
            if (!_op.eliminarRecurso())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
