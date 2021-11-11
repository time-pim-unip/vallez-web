using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;
using vallezweb.Models.InputModels;

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
        [Route("[controller]/{id}/Solicitar")]
        public IActionResult Solicitar( [FromRoute] int id, [FromBody] SolicitarLocacaoIM solicitacao)
        {

            DateTime dataEntrada = DateTime.Parse(solicitacao.DataEntrada);
            DateTime dataSaida = DateTime.Parse(solicitacao.DataSaida);

            var disponibilidades = _context.Disponibilidades.Where(d => (d.Data >= dataEntrada && d.Data <= dataSaida) && d.IdQuarto == id)
                                                            .OrderByDescending(d => d.Data );

            if (disponibilidades.Count() == 0)
            {
                return BadRequest( new { Erro = "O quarto escolhido não possui datas disponiveis no periodo selecionado." } );
            }


            List<String> datasInvalidas = new List<String>();
            bool possuiDataInvalida = false;
            string mensagemError = "<p>Os seguintes dias não estão disponiveis: </p></br><ul>";
            foreach (Disponibilidade d in disponibilidades)
            {
                if (!d.Disponivel)
                {
                    possuiDataInvalida = true;
                    mensagemError += $"<li> {d.Data.ToString("dd/MM/yyyy")} </li>" ;
                }
            }
            mensagemError += "</ul>";

            if (possuiDataInvalida)
            {
                return BadRequest(new { Erro = mensagemError });
            }


            return Ok(disponibilidades);
        }
    }
}
