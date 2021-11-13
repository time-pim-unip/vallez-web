using System.Collections.Generic;
using vallezweb.Source.Entidades;

namespace vallezweb.Models.ViewModels
{

    public class LocacoesVM 
    {
        public List<Locacao> LocacoesAtivas {get;set;}
        public List<Locacao> LocacoesFuturas {get;set;}
        public List<Locacao> LocacoesHoje {get;set;}

        public LocacoesVM()
        {
            this.LocacoesAtivas = new List<Locacao>();
            this.LocacoesFuturas = new List<Locacao>();
            this.LocacoesHoje = new List<Locacao>();
        }

    }

}