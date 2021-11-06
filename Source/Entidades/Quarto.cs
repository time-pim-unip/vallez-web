using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("quartos")]
    public class Quarto
    {
        [Column("id_quarto")]
        public int Id { get; set; }
        [Column("uuid_quarto")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("id_tipo_quarto")]
        public int IdTipoQuarto { get; set; }
        [Column("bloco")]
        public string Bloco { get; set; }
        [Column("numero")]
        public int Numero { get; set; }
        [Column("qtde_banheiros")]
        public int QtBanheiros { get; set; }
        [Column("qtde_camas")]
        public int QtCamas { get; set; }
        [Column("valor_diaria")]
        public double ValorDiaria { get; set; }
    }



    [Table("pessoa")]
    public class Pessoa
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("rg")]
        public string Rg { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("celular")]
        public string Celular { get; set; }

    }



}
