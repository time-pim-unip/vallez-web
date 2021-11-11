using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("disponibilidades")]
    public class Disponibilidade
    {
       
        [Key]
        [Column("id_disponibilidade")]
        public int IdDisponibilidade { get; set; }
        [Column("id_quarto")]
        public int IdQuarto { get; set; }
        [Column("id_locacao")]
        public int? IdLocacao { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }
        [Column("dia_disponivel")]
        public bool Disponivel { get; set; }

    }
}
