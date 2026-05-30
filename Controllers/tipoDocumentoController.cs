using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tipoDocumentoController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTipoDocumento _op;

        public tipoDocumentoController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTipoDocumento(_context);
        }

        [HttpGet]
        public List<TblTipoDocumento> Get() => _op.ListarTipoDocumento();

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _op.ListarTipoDocumento(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblTipoDocumento obj)
        {
            _op.tblTipoDocumento = obj;
            if (!_op.agregarTipoDocumento())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblTipoDocumento obj)
        {
            if (obj == null || id != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTipoDocumento = obj;
            if (!_op.modificarTipoDocumento())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _op.tblTipoDocumento = new TblTipoDocumento { Codigo = id };
            if (!_op.eliminarTipoDocumento())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
