using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class marcasController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMarca _op;

        public marcasController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMarca(_context);
        }

        [HttpGet]
        public List<TblMarca> Get() => _op.ListarMarcas();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarMarcas(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblMarca obj)
        {
            _op.tblMarca = obj;
            if (!_op.agregarMarca())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblMarca obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblMarca = obj;
            if (!_op.modificarMarca())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblMarca = new TblMarca { Codigo = id };
            if (!_op.eliminarMarca())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
