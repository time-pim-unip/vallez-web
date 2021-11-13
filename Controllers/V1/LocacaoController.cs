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
    public class LocacaoController : ControllerBase
    {

        private readonly VallezContext _vallezContext;

        public LocacaoController(
            VallezContext vallezContext    
        )
        {
            this._vallezContext = vallezContext;
        }

        [HttpGet("{id}")]
        async public Task<IActionResult> BuscarQuartoLocado([FromRoute] int id)
        {

            LocacaoVM locacaoVM = new LocacaoVM();

            Locacao locacao = await _vallezContext.Locacoes.FirstOrDefaultAsync(l => l.Id == id);
            if (locacao == null) {
                return NoContent();
            }

            locacaoVM.Locacao = locacao;

            Quarto quarto = await _vallezContext.Quartos.FirstOrDefaultAsync(q => q.Id == locacao.IdQuarto );
            if (quarto == null) {
                return NoContent();
            }

            locacaoVM.Quarto = quarto;

            IEnumerable<ServicoSolicitado> servicoSolicitado = await _vallezContext.ServicosSolicitados.Where(s => s.IdLocacao == locacao.Id).ToListAsync();

            if (servicoSolicitado != null) {

                foreach (ServicoSolicitado ss in servicoSolicitado) 
                {

                    Servico servico = await _vallezContext.Servicos.FirstOrDefaultAsync(s => s.Id == ss.IdServico);
                    ss.Servico = servico;

                }

            }

            locacaoVM.ServicosSolicitados = servicoSolicitado.ToList();



            return Ok(locacaoVM);
        }
    }
}
