using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;
using vallezweb.Models.ViewModels;


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

            LocacoesVM locacoesVm = new LocacoesVM();

            foreach (Hospedagem h in hospedagens)
            {
                // var locacao = await _vallezContext.Locacoes.Where(l => l.Id == h.IdLocacao && l.Checkin != null && l.CheckOut == null ).FirstOrDefaultAsync();

                var locacao = await _vallezContext.Locacoes.FirstOrDefaultAsync(l => l.Id == h.IdLocacao);

                if (locacao.DataEntrada >= System.DateTime.Now && locacao.CheckIn == null && locacao.CheckOut == null) {
                    locacoesVm.LocacoesFuturas.Add(locacao);

                } 
                else if(locacao.CheckIn != null && locacao.CheckOut == null) 
                {
                    locacoesVm.LocacoesAtivas.Add(locacao);
                }
                else if (locacao.DataEntrada.Value.ToString("dd/MM/yyyy") == System.DateTime.Now.ToString("dd/MM/yyyy") && locacao.CheckIn == null)
                {
                    locacoesVm.LocacoesHoje.Add(locacao);
                }
            }

            locacoesVm.LocacoesAtivas.OrderBy(l => l.DataEntrada);
            locacoesVm.LocacoesFuturas.OrderBy(l => l.DataEntrada);

            // if (locacoes.Count() > 0)
            // {
            //     locacoes = locacoes.OrderByDescending(l => l.Id).ToList();
            // }

            return Ok(locacoesVm);   
        }
    }
}
