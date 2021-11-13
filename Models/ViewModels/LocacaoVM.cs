using System.Collections.Generic;
using vallezweb.Source.Entidades;

namespace vallezweb.Models.ViewModels
{
    public class LocacaoVM
    {
        public Locacao Locacao {get;set;}
        public Quarto Quarto { get;set; }
        public List<ServicoSolicitado> ServicosSolicitados { get; set; }
    }
}