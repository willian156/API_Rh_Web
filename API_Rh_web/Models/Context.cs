using Microsoft.EntityFrameworkCore;

namespace API_Rh_web.Models
{
    public class Context : DbContext
    {
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Conhecimento> Conhecimento { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<Curriculo> Curriculo { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaga>().ToTable("Vagas");
            modelBuilder.Entity<Conhecimento>().ToTable("Conhecimentos");
            modelBuilder.Entity<Ponto>().ToTable("Pontos");
            modelBuilder.Entity<Curriculo>().ToTable("Curriculos");



            //tabelas muitos-para-muitos
            modelBuilder.Entity<Ponto>().HasKey(sc => new { sc.VagaPonto, sc.ConhecimentoPonto });
        }

    }
}
