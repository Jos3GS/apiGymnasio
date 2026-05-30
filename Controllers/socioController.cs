using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class socioController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeSocio _opsocio;

        public socioController(BdgymnasioContext context)
        {
            _context = context;
            _opsocio = new clsOpeSocio(_context);
        }

        [HttpGet]
        public List<TblSocio> Get()
        {
            return _opsocio.ListarSocios();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _opsocio.ListarSocios(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _opsocio.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblSocio socio)
        {
            _opsocio.tblSocio = socio;
            var ok = _opsocio.agregarSocio();
            if (!ok)
            {
                Response.StatusCode = 400;
                return new { message = _opsocio.message };
            }
            Response.StatusCode = 201;
            return socio;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody] TblSocio socio)
        {
            if (socio == null || id != socio.NumeroId)
            {
                Response.StatusCode = 400;
                return new { message = "Id inválido" };
            }
            _opsocio.tblSocio = socio;
            var ok = _opsocio.modificarSocio();
            if (!ok)
            {
                Response.StatusCode = 400;
                return new { message = _opsocio.message };
            }
            return new { message = _opsocio.message };
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _opsocio.tblSocio = new TblSocio { NumeroId = id };
            var ok = _opsocio.borrarSocio();
            if (!ok)
            {
                Response.StatusCode = 400;
                return new { message = _opsocio.message };
            }
            return new { message = _opsocio.message };
        }
    }
}
