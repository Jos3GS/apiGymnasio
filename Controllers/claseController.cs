using apiGymnasio.Clases;
using apiGymnasio.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiGymnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class claseController : ControllerBase
    {
        private readonly BdgymnasioContext _context;
        private readonly clsOpeClase _opclase;

        public claseController(BdgymnasioContext context)
        {
            _context = context;
            _opclase = new clsOpeClase(_context);
        }

        [HttpGet]
        public List<TblClase> Get()
        {
            return _opclase.listarClases();
        }
        [HttpGet("monitor/{id}")]
        public object GetByMonitor(int id)
        {
            var res = _opclase.listarClasesXMonitor(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _opclase.message };
            }
            return res;
        }

        [HttpGet("sala/{id}")]
        public object GetBySala(int id)
        {
            var res = _opclase.listarClasesXSala(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _opclase.message };
            }
            return res;
        }

        [HttpGet("especialidad/{id}")]
        public object GetByEspecialidad(int id)
        {
            var res = _opclase.listarClasesXEspecialidad(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _opclase.message };
            }
            return res;
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var res = _opclase.listarClases(id);
            if (res == null)
            {
                Response.StatusCode = 404;
                return new { message = _opclase.message };
            }
            return res;
        }

        [HttpPost]
        public object Post([FromBody] TblClase clase)
        {
            _opclase.tblClase = clase;
            var ok = _opclase.agregarClase();
            if (!ok)
            {
                Response.StatusCode = 400;
                return new { message = _opclase.message };
            }
            Response.StatusCode = 201;
            return clase;
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] TblClase clase)
        {
            if (clase == null || id != clase.Codigo)
            {
                Response.StatusCode = 400;
                return "Id inválido";
            }
            _opclase.tblClase = clase;
            var ok = _opclase.modificarClase();
            if (!ok)
            {
                Response.StatusCode = 400;
                return _opclase.message;
            }
            return _opclase.message;
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            _opclase.tblClase = new TblClase { Codigo = id };
            var ok = _opclase.eliminarClase();
            if (!ok)
            {
                Response.StatusCode = 400;
                return new { message = _opclase.message };
            }
            return new { message = _opclase.message };
        }
    }
}
