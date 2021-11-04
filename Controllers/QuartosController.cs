using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;

namespace vallezweb.Controllers
{
    [Route("[controller]")]
    public class QuartosController : Controller
    {
        private readonly VallezContext _context;

        public QuartosController(VallezContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Quarto> quartos = _context.Quartos.ToList<Quarto>();

            return View(quartos);
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {

            /* Exemplo Insert
            Quarto novoQuarto = new Quarto()
            {
                Descricao = "Suite Plus",
                IdTipoQuarto = 1,
                Bloco = "A",
                Numero = 10,
                ValorDiaria = 1500.52f,
                QtBanheiros = 5,
                QtCamas = 10
            };

            _context.Quartos.Add(novoQuarto);
            _context.SaveChanges();

            return Ok(novoQuarto);
            */

            // Exemplo Select *
            List<Quarto> quartos = _context.Quartos.ToList<Quarto>();

            return Ok(quartos);

        }


    }
}
