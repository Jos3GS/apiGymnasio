using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class estadoConservacionController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeEstadoConservacion _op;

        public estadoConservacionController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeEstadoConservacion(_context);
        }

        [HttpGet]
        public List<TblEstadoConservacion> Get() => _op.ListarEstadoConservacion();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarEstadoConservacion(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblEstadoConservacion obj)
        {
            _op.tblEstadoConservacion = obj;
            if (!_op.agregarEstadoConservacion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblEstadoConservacion obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblEstadoConservacion = obj;
            if (!_op.modificarEstadoConservacion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblEstadoConservacion = new TblEstadoConservacion { Codigo = id };
            if (!_op.eliminarEstadoConservacion())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
