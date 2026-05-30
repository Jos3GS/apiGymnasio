using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class telefonoSocioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeTelefonoSocio _op;

        public telefonoSocioController(BdgymnasioContext context)
        {
            _context = context;
            _op = new clsOpeTelefonoSocio(_context);
        }

        [HttpGet]
        public List<TblTelefonoSocio> Get() => _op.ListarTelefonos();

        [HttpGet("{codigo}")]
        public object Get(int codigo)
        {
            var res = _op.ListarTelefonos(codigo);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _op.message };
            }
            return res;
        }

        [HttpGet("socio/{id}")]
        public object GetBySocio(int id)
        {
            var links = _context.TblTelSocioSocios.Where(x => x.FkSocio == id).ToList();
            var phoneIds = links.Select(x => x.FkTelefonoSocio).Where(x => x.HasValue).Select(x => x.Value).ToList();
            var phones = _context.TblTelefonoSocios.Where(x => phoneIds.Contains(x.Codigo)).ToList();
            if (phones == null || phones.Count == 0)
            {
                Response.StatusCode = 404;
                return new { message = "No se han encontrado teléfonos para el socio" };
            }
            return phones;
        }

        [HttpPost]
        public object Post([FromBody] TblTelefonoSocio obj)
        {
            _op.tblTelefonoSocio = obj;
            if (!_op.agregarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            Response.StatusCode = 201;
            return obj;
        }

        [HttpPut("{codigo}")]
        public object Put(int codigo, [FromBody] TblTelefonoSocio obj)
        {
            if (obj == null || codigo != obj.Codigo)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _op.tblTelefonoSocio = obj;
            if (!_op.modificarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }

        [HttpDelete("{codigo}")]
        public object Delete(int codigo)
        {
            _op.tblTelefonoSocio = new TblTelefonoSocio { Codigo = codigo };
            if (!_op.borrarTelefono())
            {
                Response.StatusCode = 400;
                return new { message = _op.message };
            }
            return new { message = _op.message };
        }
    }
}
