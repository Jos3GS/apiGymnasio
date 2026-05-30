using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telEmpleadoEmpleadoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelEmpleadoEmpleado _op;

        public telEmpleadoEmpleadoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelEmpleadoEmpleado(_context);
        }

        [HttpGet]
        public List<TblTelEmpleadoEmpleado> Get() => _op.Listar();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.Listar(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTelEmpleadoEmpleado obj)
        {
            _op.tblTel = obj;
            if (!_op.agregar())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTelEmpleadoEmpleado obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTel = obj;
            if (!_op.modificar())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTel = new TblTelEmpleadoEmpleado { Codigo = id };
            if (!_op.borrar())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
