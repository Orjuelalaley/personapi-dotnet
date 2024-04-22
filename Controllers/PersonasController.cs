using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController(IPersonaRepository personaRepository) : ControllerBase
    {
        private readonly IPersonaRepository personaRepository = personaRepository;

        ///<summary>
        /// Obtiene todas las Personas en la base de datos   
        /// </summary>

        // GET: api/Personas
        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {
            var personas = await personaRepository.GetAllPersonasAsync();
            return Ok(personas);
        }
        /// <summary>
        /// Obtiene una persona por su id
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonaById(int id)
        {
            var persona = await personaRepository.GetPersonaByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPersona = await personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonaById), new { id = createdPersona.Cc }, createdPersona);
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPersona = await personaRepository.GetPersonaByIdAsync(id);
            if (existingPersona == null)
            {
                return NotFound($"Persona with ID {id} not found.");
            }
            
            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;
            existingPersona.Edad = persona.Edad;
            existingPersona.Genero = persona.Genero;

            try
            {
                await personaRepository.UpdatePersonaAsync(existingPersona);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(409, "Failed to update the persona due to concurrency issue. Please try again.");
            }
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await personaRepository.GetPersonaByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            await personaRepository.DeletePersonaAsync(id);
            return NoContent();
        }
    }
}
