using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telSocioSocioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelSocioSocio _op;

        public telSocioSocioController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelSocioSocio(_context);
        }

        [HttpGet]
        public List<TblTelSocioSocio> Get() => _op.Listar();

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
        public object Post([FromBody] TblTelSocioSocio obj)
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
        public object Put(int id, [FromBody] TblTelSocioSocio obj)
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
            _op.tblTel = new TblTelSocioSocio { Codigo = id };
            if (!_op.borrar())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
