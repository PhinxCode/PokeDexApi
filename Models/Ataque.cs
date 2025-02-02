using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models
{
    public class Ataque
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, 150)]
        public byte Poder { get; set; } // Optimizado con byte

        [Required]
        public string Tipo { get; set; } = string.Empty;

        // Relación con Pokémon
        public Guid PokemonId { get; set; }
        public Pokemon? Pokemon { get; set; }
    }
}
