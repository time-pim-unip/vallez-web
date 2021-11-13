using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vallezweb.Source.Entidades
{
    [Table("servicos_solicitados")]
    public class ServicoSolicitado
    {
        [Key]
        [Column("id_servico_solicitado")]
        public int Id { get; set; }
        [Column("uuid_servico_solicitado")]
        public Guid Uuid { get;set; } = Guid.NewGuid();
        [Column("id_servico")]
        public int IdServico { get; set; }
        [Column("id_locacao")]
        public int IdLocacao { get; set; }
        [Column("data_solicitacao")]
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        [Column("qtde_solicitacao")]
        public int QtdeSolicitado { get; set; }
        [Column("notificar")]
        public bool Notificar { get; set; } = true;
        [NotMapped]
        public Servico Servico { get;set; }

    }
}
