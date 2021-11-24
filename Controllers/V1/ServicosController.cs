using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vallezweb.Models.InputModels;
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

        [HttpPost]
        public IActionResult Solicitar( [FromBody] SolicitarServicoIM servicoSolicitado)
        {

            ServicoSolicitado solicitado = new ServicoSolicitado
            {
                IdServico = servicoSolicitado.IdServico,
                IdLocacao = servicoSolicitado.IdLocacao,
                QtdeSolicitado = servicoSolicitado.Quantidade
            };

            _context.ServicosSolicitados.Add(solicitado);
            _context.SaveChanges();

            return Ok(solicitado);
        }
    }
}
