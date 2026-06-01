using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class formaPagoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeFormaPago _op;

        public formaPagoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeFormaPago(_context);
        }

        [HttpGet]
        public List<TblFormaPago> Get() => _op.Listar();

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
        public object Post([FromBody] TblFormaPago obj)
        {
            _op.tblFormaPago = obj;
            if (!_op.agregarFormaPago())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblFormaPago obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblFormaPago = obj;
            if (!_op.modificarFormaPago())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblFormaPago = new TblFormaPago { Codigo = id };
            if (!_op.eliminarFormaPago())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
