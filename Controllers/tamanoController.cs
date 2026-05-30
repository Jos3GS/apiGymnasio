using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tamanoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTamano _op;

        public tamanoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTamano(_context);
        }

        [HttpGet]
        public List<TblTamano> Get() => _op.ListarTamano();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarTamano(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTamano obj)
        {
            _op.tblTamano = obj;
            if (!_op.agregarTamano())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTamano obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTamano = obj;
            if (!_op.modificarTamano())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTamano = new TblTamano { Codigo = id };
            if (!_op.eliminarTamano())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
