using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vallezweb.Source.Entidades;

namespace vallezweb.Source.DB
{
    public class VallezContext: DbContext
    {
        public VallezContext(DbContextOptions options) : base(options) { }

        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Hospedagem> Hospedagens { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hospedagem>().HasKey(x => new { x.IdLocacao, x.IdHospede });
            //modelBuilder.Entity<Hospedagem>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }



    }
}
