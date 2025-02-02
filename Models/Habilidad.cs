using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models
{
    public class Habilidad
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public bool EsPasiva { get; set; }
        public byte Slot { get; set; } // Optimizado con byte

        // Relación con Pokémon
        public Guid PokemonId { get; set; }
        public Pokemon? Pokemon { get; set; }
    }
}
