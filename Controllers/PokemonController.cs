using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PokemonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/Pokemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemones()
        {
            return await _context
                .Pokemones.Include(value => value.Ataques)
                .Include(value => value.Habilidades)
                .ToListAsync(); // conviertelo en lista
        }

        // ✅ GET: api/Pokemon/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(Guid id)
        {
            var pokemon = await _context
                .Pokemones.Include(value => value.Ataques)
                .Include(value => value.Habilidades)
                .FirstOrDefaultAsync(value => value.Id == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // ✅ POST: api/Pokemon
        [HttpPost]
        public async Task<ActionResult<Pokemon>> CreatePokemon(Pokemon pokemon)
        {
            pokemon.Id = Guid.NewGuid(); // Aseguramos que se genere un nuevo GUID
            _context.Pokemones.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
        }

        // ✅ PUT: api/Pokemon/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemon(Guid id, Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // ✅ DELETE: api/Pokemon/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(Guid id)
        {
            var pokemon = await _context.Pokemones.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemones.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonExists(Guid id)
        {
            return _context.Pokemones.Any(e => e.Id == id);
        }
    }
}
