using Microsoft.EntityFrameworkCore;

namespace API_Rh_web.Models
{
    public class Context : DbContext
    {
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Conhecimento> Conhecimento { get; set; }
        public DbSet<Curriculo_Conhecimento> Curriculo_Conhecimento { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<Curriculo> Curriculo { get; set; }
        public DbSet<Vaga_curriculo> Vaga_curriculo { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaga>().ToTable("Vagas");
            modelBuilder.Entity<Conhecimento>().ToTable("Conhecimentos");
            modelBuilder.Entity<Curriculo_Conhecimento>().ToTable("Curriculo_conhecimento");
            modelBuilder.Entity<Ponto>().ToTable("Pontos");
            modelBuilder.Entity<Curriculo>().ToTable("Curriculos");
            modelBuilder.Entity<Vaga_curriculo>().ToTable("Vaga_Curriculo");


            //tabelas muitos-para-muitos
            modelBuilder.Entity<Curriculo_Conhecimento>().HasKey(sc => new { sc.id_Conhecimentos, sc.id_Curriculo });
            modelBuilder.Entity<Vaga_curriculo>().HasKey(sc => new { sc.id_vaga, sc.id_curriculo});
            modelBuilder.Entity<Ponto>().HasKey(sc => new { sc.id_vaga, sc.id_Conhecimentos });
        }

    }
}
