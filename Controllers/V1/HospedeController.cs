using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;


namespace vallezweb.Controllers.V1
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class HospedeController : ControllerBase
    {

        private readonly VallezContext _vallezContext;

        public HospedeController(
            VallezContext vallezContext
        )
        {
            this._vallezContext = vallezContext;
        }


        [HttpGet]
        public IActionResult ValidarCpf([FromQuery] string cpf)
        {

            var pessoa = _vallezContext.Pessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return NoContent();
            }

            return Ok(pessoa);
        }

        [HttpGet("{id}/Locacoes")]
        public async Task<IActionResult> Locacoes([FromRoute] int id)
        {
            var hospedagens = await _vallezContext.Hospedagens.Where(x => x.IdHospede == id).ToListAsync();
            List<Locacao> locacoes  = new List<Locacao>();

            foreach (Hospedagem h in hospedagens)
            {
                var locacao = await _vallezContext.Locacoes.Where(l => l.Id == h.IdLocacao && l.Checkin != null && l.CheckOut == null ).FirstOrDefaultAsync();

                if (locacao != null)
                {
                    locacoes.Add(locacao);
                }
            }

            if (locacoes.Count() > 0)
            {
                locacoes = locacoes.OrderByDescending(l => l.Id).ToList();
            }

            return Ok(locacoes);   
        }
    }
}
