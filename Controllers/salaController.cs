using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class salaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeSala _op;

        public salaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeSala(_context);
        }

        [HttpGet]
        public List<TblSala> Get() => _op.ListarSalas();

        [HttpGet("{numero}")]
        public object Get(int numero)
        {
            var res = _op.ListarSalas(numero);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblSala obj)
        {
            _op.tblSala = obj;
            if (!_op.agregarSala())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{numero}")]
        public string Put(int numero, [FromBody] TblSala obj)
        {
            if (obj == null || numero != obj.Numero)
            {
                Response.StatusCode = 400;
                return "Id inválido";
            }
            _op.tblSala = obj;
            if (!_op.modificarSala())
            {
                Response.StatusCode = 400;
                return _op.message;
            }
            return _op.message;
        }

        [HttpDelete("{numero}")]
        public string Delete(int numero)
        {
            _op.tblSala = new TblSala { Numero = numero };
            if (!_op.borrarSala())
            {
                Response.StatusCode = 400;
                return _op.message;
            }
            return _op.message;
        }
    }
}
