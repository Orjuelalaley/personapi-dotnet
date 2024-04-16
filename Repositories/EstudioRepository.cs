using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllEstudiosAsync()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudio> GetEstudioByIdAsync(int idProf, int ccPer)
        {
            return await _context.Estudios.FindAsync(idProf, ccPer);
        }

        public async Task<Estudio> CreateEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<Estudio> UpdateEstudioAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task DeleteEstudioAsync(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EstudioExistsAsync(int idProf, int ccPer)
        {
            return await _context.Estudios.AnyAsync(e => e.IdProf == idProf && e.CcPer == ccPer);
        }
    }
}
