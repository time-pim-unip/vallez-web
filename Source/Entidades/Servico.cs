using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vallezweb.Source.Entidades
{
    [Table("servicos")]
    public class Servico
    {
        [Key]
        [Column("id_servico")]
        public int Id { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("valor")]
        public double Valor { get; set; }


    }
}
