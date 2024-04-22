using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllTelefonosAsync()
        {
            return await _context.Telefonos.Include(t => t.DuenioNavigation).ToListAsync();
        }

        public async Task<Telefono> GetTelefonoByIdAsync(string num)
        {
            return await _context.Telefonos
                                 .Include(t => t.DuenioNavigation)
                                 .FirstOrDefaultAsync(t => t.Num == num);
        }

        public async Task<Telefono> CreateTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Entry(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefonoAsync(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TelefonoExists(string num)
        {
            return await _context.Telefonos.AnyAsync(t => t.Num == num);
        }
    }
}
