using Microsoft.EntityFrameworkCore;
using SamuraiApp.Dominio;

namespace SamuraiApp.Dados
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais;
        public DbSet<Frase> Frases;
        public DbSet<Batalha> Batalhas;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = SamuraiAppDados ;Trusted_Connection= true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
