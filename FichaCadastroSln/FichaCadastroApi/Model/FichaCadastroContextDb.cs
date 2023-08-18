using Microsoft.EntityFrameworkCore;

namespace FichaCadastroApi.Model
{
    public class FichaCadastroDbContext : DbContext
    {
        public FichaCadastroDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FichaModel> FichaModels { get; set; }
        public DbSet<DetalheModel> DetalheModels { get; set; }

        //[M3S02] Ex 03 - Configurar o Contexto com a Model
        public DbSet<TelefoneModel> TelefoneModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalheModel>()
                       .HasOne(e => e.Ficha)
                       .WithMany(x => x.Detalhes)
                       .Metadata
                       .DeleteBehavior = DeleteBehavior.Restrict;

            //relacionamento configurado

            modelBuilder.Entity<TelefoneModel>()
                .HasOne(e => e.Ficha)
                .WithMany(x => x.Telefones)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
