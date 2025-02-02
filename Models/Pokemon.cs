using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public List<string> Tipos { get; set; } = new List<string>();

        public string Descripcion { get; set; } = string.Empty;
        public double Peso { get; set; }
        public string Naturaleza { get; set; } = string.Empty;
        public string? ImagenUrl { get; set; }

        // Estadísticas optimizadas con byte
        [Range(0, 252)]
        public byte PS { get; set; }

        [Range(0, 252)]
        public byte Ataque { get; set; }

        [Range(0, 252)]
        public byte Defensa { get; set; }

        [Range(0, 252)]
        public byte AtaqueEspecial { get; set; }

        [Range(0, 252)]
        public byte DefensaEspecial { get; set; }

        [Range(0, 252)]
        public byte Velocidad { get; set; }

        // Relaciones
        public List<Ataque> Ataques { get; set; } = new List<Ataque>();
        public List<Habilidad> Habilidades { get; set; } = new List<Habilidad>();
    }
}
