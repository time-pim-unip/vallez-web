using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;
using vallezweb.Models.ViewModels;

namespace vallezweb.Controllers.V1
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly VallezContext _context;

        public FaturamentoController(
            VallezContext context
        )
        {
            this._context = context;
        }
        
        [HttpGet("{idHospede}")]
        async public Task<IActionResult> Listar([FromRoute] int idHospede)
        {

            var hospedagens = await _context.Hospedagens.Where(h => h.IdHospede == idHospede).ToListAsync();

            if (hospedagens == null) {
                return NotFound();
            }


            List<Locacao> locacaos = new List<Locacao>();
            foreach ( Hospedagem h in hospedagens )
            {
                locacaos.Add(await _context.Locacoes.FirstOrDefaultAsync(l => l.Id == h.IdLocacao));
            }

            if (locacaos == null) {
                return NotFound();
            }

            List<Faturamento> faturamentos = new List<Faturamento>();
            foreach ( Hospedagem h in hospedagens )
            {

                Faturamento f = await _context.Faturamentos.FirstOrDefaultAsync(f => f.IdLocacao == h.IdLocacao);
                if (f != null)
                {
                    faturamentos.Add(f);
                }

            }

            faturamentos.OrderByDescending(f => f.Id);

            return Ok(faturamentos);
        }

    }
}