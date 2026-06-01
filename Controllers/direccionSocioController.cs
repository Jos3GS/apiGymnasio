using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class direccionSocioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeDireccionSocio _op;

        public direccionSocioController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeDireccionSocio(_context);
        }

        [HttpGet]
        public List<TblDireccionSocio> Get() => _op.ListarDireccionSocio();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarDireccionSocio(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblDireccionSocio obj)
        {
            _op.tblDireccionSocio = obj;
            if (!_op.agregarDireccionSocio())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblDireccionSocio obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblDireccionSocio = obj;
            if (!_op.modificarDireccionSocio())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblDireccionSocio = new TblDireccionSocio { Codigo = id };
            if (!_op.eliminarDireccionSocio())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
