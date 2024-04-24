using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.MVC
{
    public class EstudioMVCController(PersonaDbContext context) : Controller
    {
        private readonly PersonaDbContext _context = context;

        // GET: EstudioMVC
        public async Task<IActionResult> Index()
        {
            var personaDbContext = _context.Estudios.Include(e => e.CcPerNavigation).Include(e => e.IdProfNavigation);
            return View(await personaDbContext.ToListAsync());
        }

        // GET: EstudioMVC/Details/5?cc=10
        public async Task<IActionResult> Details(int? id, int? cc)
        {
            if (id == null || cc == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id && m.CcPer == cc);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: EstudioMVC/Create
        public IActionResult Create()
        {
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id");
            return View();
        }

        // POST: EstudioMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        public async Task<IActionResult> Edit(int? id, int? cc)
        {
            if (id == null || cc == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id && m.CcPer == cc);

            if (estudio == null)
            {
                return NotFound();
            }

            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // POST: EstudioMVC/Edit/5?cc=10
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int cc, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (id != estudio.IdProf || cc != estudio.CcPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudioExists(estudio.IdProf, estudio.CcPer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        private bool EstudioExists(int id, int cc)
        {
            return _context.Estudios.Any(e => e.IdProf == id && e.CcPer == cc);
        }

        // GET: EstudioMVC/Delete/5?cc=10
        public async Task<IActionResult> Delete(int? id, int? cc)
        {
            if (id == null || cc == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id && m.CcPer == cc);

            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: EstudioMVC/Delete/5?cc=10
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int cc)
        {
            var estudio = await _context.Estudios
                .FirstOrDefaultAsync(m => m.IdProf == id && m.CcPer == cc);

            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
