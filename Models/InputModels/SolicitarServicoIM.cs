using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vallezweb.Models.InputModels
{
    public class SolicitarServicoIM
    {
        public int IdServico {get;set;}
        public int IdLocacao { get;set; }
        public int Quantidade {get;set;}
    }
}