using apiGymnasio.Clases;
using apiGymnasio.Clases.Auxiliar;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class matriculaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeMatricula _op;

        public matriculaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeMatricula(_context);
        }

        [HttpGet]
        public List<TblMatricula> Get() => _op.listarMatriculas();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.listarMatriculas(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblMatricula obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblMatricula = obj;
            if (!_op.modificarMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblMatricula = new TblMatricula { Codigo = id };
            if (!_op.eliminarMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpPost("registrarInscripcion")]
        public int registrarInscripcion([FromBody] inscripCompleta inscripcionWeb)
        {
            try
            {
                clsOpeMatricula opeMatricula = new clsOpeMatricula(_context);
                int idMatricula = opeMatricula.agregarMatricula(inscripcionWeb);
                return idMatricula;
            }
            catch 
            {
                return -1;
            }
        }

    }
}
