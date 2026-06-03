using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class detalleMatriculaController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeDetalleMatricula _op;

        public detalleMatriculaController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeDetalleMatricula(_context);
        }

        [HttpGet]
        public List<TblDetalleMatricula> Get() => _op.listarDetalleMatriculas();

        [HttpGet("{id}")]
        public List<TblDetalleMatricula> Get(int id)
        {
            return _op.listarDetalleMatriculas(id);
        }

        [HttpPost]
        public object Post([FromBody] TblDetalleMatricula obj)
        {
            _op.tblDetalleMatricula = obj;
            if (!_op.agregarDetalleMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPost("AgregarDetalleInd")]
        public int AdicionarDetalleInd(int codigo, int idClase)
        {
            try
            {
                if (_op.agregarDetalleMatricula(codigo, idClase)) return 1;
                else return -1;
            }
            catch 
            {
                return -1;
            }
        }

        [HttpDelete]
        public object Delete(int codigo, int matricula)
        {
            if (!_op.eliminarDetalleMatricula(codigo, matricula))
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
