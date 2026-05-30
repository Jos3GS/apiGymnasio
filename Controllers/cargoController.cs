using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cargoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeCargo _op;

        public cargoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeCargo(_context);
        }

        [HttpGet]
        public List<TblCargo> Get() => _op.ListarCargos();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarCargos(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblCargo cargo)
        {
            _op.tblCargo = cargo;
            if (!_op.agregarCargo())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return cargo;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblCargo cargo)
        {
            if (cargo == null || id != cargo.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblCargo = cargo;
            if (!_op.modificarCargo())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblCargo = new TblCargo { Codigo = id };
            if (!_op.borrarCargo())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
