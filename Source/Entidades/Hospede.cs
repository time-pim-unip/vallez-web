using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("hospedes")]
    public class Hospede
    {
        [Key]
        [Column("id_hospede")]
        public int Id { get; set; }
        [Column("uuid_hospede")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
        [Column("id_pessoa")]
        public int IdPessoa { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("consentimento_pais")]
        public bool Consentimento { get; set; }


    }
}
