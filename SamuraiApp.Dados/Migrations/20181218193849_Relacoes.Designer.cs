﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamuraiApp.Dados;

namespace SamuraiApp.Dados.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20181218193849_Relacoes")]
    partial class Relacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SamuraiApp.Dominio.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal");

                    b.Property<DateTime>("DataInicial");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("SamuraiApp.Dominio.BatalhaSamurai", b =>
                {
                    b.Property<int>("BatalhaId");

                    b.Property<int>("SamuraiId");

                    b.HasKey("BatalhaId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("BatalhaSamurai");
                });

            modelBuilder.Entity("SamuraiApp.Dominio.Frase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SamuraiId");

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Frases");
                });

            modelBuilder.Entity("SamuraiApp.Dominio.IdentidadeSecreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeReal");

                    b.Property<int>("SamuraiId");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId")
                        .IsUnique();

                    b.ToTable("IdentidadeSecreta");
                });

            modelBuilder.Entity("SamuraiApp.Dominio.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiApp.Dominio.BatalhaSamurai", b =>
                {
                    b.HasOne("SamuraiApp.Dominio.Batalha", "Batalha")
                        .WithMany("BatalhaSamurai")
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SamuraiApp.Dominio.Samurai", "Samurai")
                        .WithMany("BatalhaSamurai")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiApp.Dominio.Frase", b =>
                {
                    b.HasOne("SamuraiApp.Dominio.Samurai", "Samurai")
                        .WithMany("Frases")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiApp.Dominio.IdentidadeSecreta", b =>
                {
                    b.HasOne("SamuraiApp.Dominio.Samurai")
                        .WithOne("IdentidadeSecreta")
                        .HasForeignKey("SamuraiApp.Dominio.IdentidadeSecreta", "SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
