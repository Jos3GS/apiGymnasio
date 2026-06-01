using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class direccionEmpleadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeDireccionEmpleado _op;

        public direccionEmpleadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeDireccionEmpleado(_context);
        }

        [HttpGet]
        public List<TblDireccionEmpleado> Get() => _op.ListarDireccionEmpleado();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarDireccionEmpleado(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblDireccionEmpleado obj)
        {
            _op.tblDireccionEmpleado = obj;
            if (!_op.agregarDireccionEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblDireccionEmpleado obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblDireccionEmpleado = obj;
            if (!_op.modificarDireccionEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblDireccionEmpleado = new TblDireccionEmpleado { Codigo = id };
            if (!_op.eliminarDireccionEmpleado())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
