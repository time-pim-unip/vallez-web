using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vallezweb.Source.Entidades
{
    [Table("locacoes")]
    public class Locacao
    {
        [Key]
        [Column("id_locacao")]
        public int Id { get; set; }
        [Column("uuid_locacao")]
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Column("id_quarto")]
        [ForeignKey("id_quarto")]
        public int IdQuarto { get; set; }
        [Column("dt_entrada")]
        public DateTime? DataEntrada { get; set; }
        [Column("dt_saida")]
        public DateTime? DataSaida {  get; set; }
        [Column("dt_checkin")]
        public DateTime? CheckIn { get; set; }
        [Column("dt_checkout")]
        public DateTime? CheckOut { get; set; }
        

    }
}
