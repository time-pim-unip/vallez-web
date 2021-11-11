using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("pessoas")]
    public class Pessoa
    {
        [Key]
        [Column("id_pessoa")]
        public int Id { get; set; }
        [Column("uuid_pessoa")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
        [Column("nome")]
        public string Nome { get; set; }
        [Column("data_nascimento")]
        public DateTime Nascimento { get; set; } = new DateTime();
        [Column("cpf")]
        public string Cpf { get; set; }
        [Column("rg")]
        public string Rg { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("telefone")]
        public string Telefone { get; set; }
        [Column("celular")]
        public string Celular { get; set; }

    }
}
