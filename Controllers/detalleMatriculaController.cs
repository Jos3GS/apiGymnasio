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

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblDetalleMatricula = new TblDetalleMatricula { Codigo = id };
            if (!_op.eliminarDetalleMatricula())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
