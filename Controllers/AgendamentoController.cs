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
        async public Task<IActionResult> Solicitar( [FromRoute] int id, [FromBody] SolicitarLocacaoIM solicitacao)
        {

            DateTime dataEntrada = DateTime.Parse(solicitacao.DataEntrada);
            DateTime dataSaida = DateTime.Parse(solicitacao.DataSaida);

            // Validando disponibilidade

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


            // Validando se hospede já existe
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Cpf == solicitacao.Cpf );
            Hospede hospede = new Hospede();
            Usuario usuario = new Usuario();

            if (pessoa == null) {
                
                pessoa = new Pessoa
                {
                    Nome = solicitacao.Nome,
                    Nascimento = DateTime.Parse(solicitacao.Nascimento),
                    Cpf = solicitacao.Cpf,
                    Rg = solicitacao.Rg,
                    Email = solicitacao.Email,
                    Telefone = solicitacao.Telefone,
                    Celular = solicitacao.Celular
                };
                
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();

                usuario = new Usuario()
                {
                    Username = pessoa.Cpf.Replace(".", "").Replace("-", ""),
                    Senha = pessoa.Cpf.Replace(".", "").Replace("-", ""),
                    TipoUsuario = "H",
                    Status = true
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                hospede = new Hospede
                {
                    IdUsuario = usuario.Id,
                    IdPessoa = pessoa.Id,
                    Consentimento = false,

                };

                _context.Hospedes.Add(hospede);
                await _context.SaveChangesAsync();

            }   else {
                
                hospede = _context.Hospedes.FirstOrDefault(h => h.IdPessoa == pessoa.Id);
                usuario = _context.Usuarios.FirstOrDefault(u => u.Id == hospede.Id);

            }

            // Inserindo a locação
            Locacao locacao = new Locacao()
            {
                IdQuarto = int.Parse(solicitacao.IdQuarto),
                DataEntrada = DateTime.Parse(solicitacao.DataEntrada),
                DataSaida = DateTime.Parse(solicitacao.DataSaida)
            };

            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();

            // Inserindo hospedagens
            Hospedagem hospedagem = new Hospedagem()
            {
                IdLocacao = locacao.Id,
                IdHospede = hospede.Id,
                Detentor = true
            };
            _context.Hospedagens.Add(hospedagem);
            await _context.SaveChangesAsync();


            // Remover disponibilidades dos dias escolhidos
            foreach (Disponibilidade d in disponibilidades)
            {
                d.Disponivel = false;
                d.IdLocacao = locacao.Id; 
            }
            await _context.SaveChangesAsync();

            return Ok(locacao);
        }

        [HttpGet]
        public IActionResult Sucesso()
        {
            return View();
        }

    }
}
