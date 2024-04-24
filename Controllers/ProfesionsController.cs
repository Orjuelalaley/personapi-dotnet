using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionsController : ControllerBase
    {
        private readonly PersonaDbContext _context;

        public ProfesionsController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesions
        [HttpGet]
        public async Task<IActionResult> GetAllProfesions()
        {
            var profesions = await _context.Profesions.ToListAsync();
            return Ok(profesions);
        }

        // GET: api/Profesions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesion(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return Ok(profesion);
        }

        // POST: api/Profesions
        [HttpPost]
        public async Task<IActionResult> CreateProfesion([FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.Id }, profesion);
        }

        // PUT: api/Profesions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesion(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
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

        // DELETE: api/Profesions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _context.Profesions.Remove(profesion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesions.Any(e => e.Id == id);
        }
    }
}