using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vallezweb.Source.Entidades
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }
        [Column("usuario")]
        public string Username { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("tipo_usuario")]
        public string TipoUsuario { get; set; }
        [Column("status")]
        public bool Status { get; set; }

    }
}
