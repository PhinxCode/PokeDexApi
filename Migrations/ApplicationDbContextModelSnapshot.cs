﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonAPI.Data;

#nullable disable

namespace PokemonAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonAPI.Models.Ataque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Poder")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Ataques");
                });

            modelBuilder.Entity("PokemonAPI.Models.Habilidad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("EsPasiva")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Slot")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("PokemonAPI.Models.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Ataque")
                        .HasColumnType("tinyint");

                    b.Property<byte>("AtaqueEspecial")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Defensa")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DefensaEspecial")
                        .HasColumnType("tinyint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naturaleza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("PS")
                        .HasColumnType("tinyint");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<string>("Tipos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Velocidad")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Pokemones");
                });

            modelBuilder.Entity("PokemonAPI.Models.Ataque", b =>
                {
                    b.HasOne("PokemonAPI.Models.Pokemon", "Pokemon")
                        .WithMany("Ataques")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.Models.Habilidad", b =>
                {
                    b.HasOne("PokemonAPI.Models.Pokemon", "Pokemon")
                        .WithMany("Habilidades")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.Models.Pokemon", b =>
                {
                    b.Navigation("Ataques");

                    b.Navigation("Habilidades");
                });
#pragma warning restore 612, 618
        }
    }
}
