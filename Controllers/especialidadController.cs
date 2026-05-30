using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class especialidadController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEspecialidad _op;

        public especialidadController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEspecialidad(_context);
        }

        [HttpGet]
        public List<TblEspecialidad> Get() => _op.ListarEspecialidades();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarEspecialidades(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblEspecialidad obj)
        {
            _op.tblEspecialidad = obj;
            if (!_op.agregarEspecialidad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblEspecialidad obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblEspecialidad = obj;
            if (!_op.modificarEspecialidad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblEspecialidad = new TblEspecialidad { Codigo = id };
            if (!_op.eliminarEspecialidad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
