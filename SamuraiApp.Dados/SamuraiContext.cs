﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Dominio;

namespace SamuraiApp.Dados
{
    public class SamuraiContext : DbContext
    {                    
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Frase> Frases { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();

            #pragma warning disable
            loggerFactory.AddConsole();
            #pragma warning restore


            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = SamuraiWpfDemo ;Trusted_Connection= true;");        
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatalhaSamurai>()
                        .HasKey(s => new { s.BatalhaId, s.SamuraiId });
                
            base.OnModelCreating(modelBuilder);
        }


    }
}
