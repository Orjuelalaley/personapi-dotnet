using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IPersonaRepository _personaRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository, IPersonaRepository personaRepository)
        {
            _telefonoRepository = telefonoRepository;
            _personaRepository = personaRepository;
        }

        // GET: api/Telefono
        [HttpGet]
        public async Task<IActionResult> GetAllTelefonos()
        {
            var telefonos = await _telefonoRepository.GetAllTelefonosAsync();
            return Ok(telefonos);
        }

        // GET: api/Telefono/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTelefono(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return Ok(telefono);
        }

        // POST: api/Telefono
        [HttpPost]
        public async Task<IActionResult> CreateTelefono([FromBody] Telefono telefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _telefonoRepository.CreateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefono), new { id = telefono.Num }, telefono);
        }

        // PUT: api/Telefono/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTelefono(string id, [FromBody] Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _telefonoRepository.UpdateTelefonoAsync(telefono);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TelefonoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Telefono/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefono(string id)
        {
            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefonoAsync(id);
            return NoContent();
        }

        private async Task<bool> TelefonoExists(string id)
        {
            return await _telefonoRepository.GetTelefonoByIdAsync(id) != null;
        }
    }
}