using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vallezweb.Models.InputModels
{
    public class SolicitarLocacaoIM
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string IdQuarto { get; set; }
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }
    }
}
