using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllProfesionsAsync()
        {
            return await _context.Profesions.ToListAsync();
        }

        public async Task<Profesion> GetProfesionByIdAsync(int id)
        {
            return await _context.Profesions.FindAsync(id);
        }

        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task UpdateProfesionAsync(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesionAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ProfesionExists(int id)
        {
            return await _context.Profesions.AnyAsync(p => p.Id == id);
        }
    }
}
