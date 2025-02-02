using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;

namespace PokemonAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Pokemon> Pokemones { get; set; }
        public DbSet<Ataque> Ataques { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relación entre Pokemon y Ataques
            modelBuilder
                .Entity<Ataque>()
                .HasOne(a => a.Pokemon)
                .WithMany(p => p.Ataques)
                .HasForeignKey(a => a.PokemonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de relación entre Pokemon y Habilidades
            modelBuilder
                .Entity<Habilidad>()
                .HasOne(h => h.Pokemon)
                .WithMany(p => p.Habilidades)
                .HasForeignKey(h => h.PokemonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Conversión para la lista de Tipos
            modelBuilder
                .Entity<Pokemon>()
                .Property(p => p.Tipos)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
