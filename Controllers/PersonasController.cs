using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonasController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personas = await _personaRepository.GetAllPersonasAsync();
            return Ok(personas); // Changed to return Ok() for API consistency
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var persona = await _personaRepository.GetPersonaByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona); // Changed to return Ok() for API consistency
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPersona = await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(Details), new { id = createdPersona.Cc }, createdPersona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Persona persona)
        {
            if (id != persona.Cc)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _personaRepository.UpdatePersonaAsync(persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PersonaExists(persona.Cc))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Indicates successful update without returning data
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _personaRepository.GetPersonaByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(id);
            return NoContent(); // Indicates successful deletion without returning data
        }

        private async Task<bool> PersonaExists(int id)
        {
            var persona = await _personaRepository.GetPersonaByIdAsync(id);
            return persona != null;
        }
    }
}
