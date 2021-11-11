using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;

namespace vallezweb.Controllers
{
    public class AgendamentoController: Controller
    {

        private readonly VallezContext _context;

        public AgendamentoController(VallezContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Index([FromRoute] int id)
        {

            Quarto quarto = _context.Quartos.FirstOrDefault(x => x.Id == id);

            return View(quarto);
        }

        [HttpPost]
        public IActionResult Solicitar()
        {
            return Ok("Teste");
        }
    }
}
