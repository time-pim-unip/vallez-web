using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;

namespace vallezweb.Controllers.V1
{   
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ServicosController : ControllerBase
    {

        private readonly VallezContext _context;

        public ServicosController(VallezContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public IActionResult List()
        {
            return Ok(_context.Servicos.ToList<Servico>());
        }

        [HttpPost("{id}")]
        public IActionResult Solicitar([FromRoute] int id, [FromBody] ServicoSolicitado servicoSolicitado)
        {

            _context.ServicosSolicitados.Add(servicoSolicitado);
            _context.SaveChanges();

            return Ok(servicoSolicitado);
        }
    }
}
