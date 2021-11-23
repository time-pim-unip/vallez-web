using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("faturamentos")]
    public class Faturamento
    {
        [Key]
        [Column("id_faturamento")]
        public int Id { get; set; }
        [Column("id_locacao")]
        public int IdLocacao { get; set; }
        [Column("valor_total")]
        public double Valor { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = new DateTime();


    }
}