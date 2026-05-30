using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class profesionController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeProfesion _op;

        public profesionController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeProfesion(_context);
        }

        [HttpGet]
        public List<TblProfesion> Get() => _op.ListarProfesion();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarProfesion(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblProfesion obj)
        {
            _op.tblProfesion = obj;
            if (!_op.agregarProfesion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblProfesion obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblProfesion = obj;
            if (!_op.modificarProfesion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblProfesion = new TblProfesion { Codigo = id };
            if (!_op.eliminarProfesion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
