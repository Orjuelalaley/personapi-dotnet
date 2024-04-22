using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiosController : Controller
    {
        private readonly PersonaDbContext _context;

        public EstudiosController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: api/Estudios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estudios = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToListAsync();
            return Ok(estudios);
        }

        // GET: api/Estudios/5
        [HttpGet("{idProf}/{ccPer}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == idProf && m.CcPer == ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            return Ok(estudio);
        }

        // POST: api/Estudios
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Estudio estudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                _context.Estudios.Add(estudio);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Details), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Estudios/5/10
        public async Task<IActionResult> Edit(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return BadRequest();
            }

            _context.Entry(estudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Estudios/5/10
        [HttpDelete("{idProf}/{ccPer}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
