using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardingNestSystem.Data;
using BoardingNestSystem.Models;

namespace BoardingNestSystem.Controllers
{
    public class BedsController : Controller
    {
        private readonly AppDBContext _context;

        public BedsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Beds
        public async Task<IActionResult> Index()
        {
              return _context.Beds != null ? 
                          View(await _context.Beds.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Beds'  is null.");
        }

        // GET: Beds/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Beds == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds
                .FirstOrDefaultAsync(m => m.BedID == id);
            if (bed == null)
            {
                return NotFound();
            }

            return View(bed);
        }

        // GET: Beds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BedID,BedNum")] Bed bed)
        {
            if (ModelState.IsValid)
            {
                bed.BedID = Guid.NewGuid();
                _context.Add(bed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bed);
        }

        // GET: Beds/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Beds == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
            {
                return NotFound();
            }
            return View(bed);
        }

        // POST: Beds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BedID,BedNum")] Bed bed)
        {
            if (id != bed.BedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedExists(bed.BedID))
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
            return View(bed);
        }

        // GET: Beds/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Beds == null)
            {
                return NotFound();
            }

            var bed = await _context.Beds
                .FirstOrDefaultAsync(m => m.BedID == id);
            if (bed == null)
            {
                return NotFound();
            }

            return View(bed);
        }

        // POST: Beds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Beds == null)
            {
                return Problem("Entity set 'AppDBContext.Beds'  is null.");
            }
            var bed = await _context.Beds.FindAsync(id);
            if (bed != null)
            {
                _context.Beds.Remove(bed);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedExists(Guid id)
        {
          return (_context.Beds?.Any(e => e.BedID == id)).GetValueOrDefault();
        }
    }
}
