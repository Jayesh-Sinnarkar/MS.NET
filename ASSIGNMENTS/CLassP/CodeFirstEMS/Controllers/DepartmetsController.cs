using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstEMS.Models;

namespace CodeFirstEMS.Controllers
{
    public class DepartmetsController : Controller
    {
        private readonly EMSContext _context;

        public DepartmetsController(EMSContext context)
        {
            _context = context;
        }

        // GET: Departmets
        public async Task<IActionResult> Index()
        {
              return _context.Departmets != null ? 
                          View(await _context.Departmets.ToListAsync()) :
                          Problem("Entity set 'EMSContext.Departmets'  is null.");
        }

        // GET: Departmets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departmets == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmets
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departmet == null)
            {
                return NotFound();
            }

            return View(departmet);
        }

        // GET: Departmets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departmets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptId,DeptName")] Departmet departmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmet);
        }

        // GET: Departmets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departmets == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmets.FindAsync(id);
            if (departmet == null)
            {
                return NotFound();
            }
            return View(departmet);
        }

        // POST: Departmets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptId,DeptName")] Departmet departmet)
        {
            if (id != departmet.DeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmetExists(departmet.DeptId))
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
            return View(departmet);
        }

        // GET: Departmets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departmets == null)
            {
                return NotFound();
            }

            var departmet = await _context.Departmets
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departmet == null)
            {
                return NotFound();
            }

            return View(departmet);
        }

        // POST: Departmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departmets == null)
            {
                return Problem("Entity set 'EMSContext.Departmets'  is null.");
            }
            var departmet = await _context.Departmets.FindAsync(id);
            if (departmet != null)
            {
                _context.Departmets.Remove(departmet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmetExists(int id)
        {
          return (_context.Departmets?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
