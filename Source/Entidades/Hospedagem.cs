using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("hospedagens")]
    public class Hospedagem
    {
        [ForeignKey("id_locacao")]
        [Column("id_locacao")]
        public int IdLocacao { get; set; }
        [ForeignKey("id_hospede")]
        [Column("id_hospede")]
        public int IdHospede { get; set; }
        [Column("uuid_hospedagem")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
        [Column("detentor")]
        public bool Detentor { get; set; }
    }
}
