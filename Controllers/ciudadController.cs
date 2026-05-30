using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ciudadController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeCiudad _op;

        public ciudadController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeCiudad(_context);
        }

        [HttpGet]
        public List<TblCiudad> Get() => _op.ListarCiudades();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarCiudades(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblCiudad ciudad)
        {
            _op.tblCiudad = ciudad;
            if (!_op.agregarCiudad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return ciudad;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblCiudad ciudad)
        {
            if (ciudad == null || id != ciudad.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblCiudad = ciudad;
            if (!_op.modificarCiudad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblCiudad = new TblCiudad { Codigo = id };
            if (!_op.borrarCiudad())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
