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
    public class BoardingHousesController : Controller
    {
        private readonly AppDBContext _context;

        public BoardingHousesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: BoardingHouses
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.BoardingHouses.Where(bh => bh.HasActiveReservation == false);
            return View(await appDBContext.ToListAsync());
        }

        // GET: BoardingHouses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.BoardingHouses == null)
            {
                return NotFound();
            }

            var boardingHouse = await _context.BoardingHouses
                .Include(b => b.Bed)
                .FirstOrDefaultAsync(m => m.BoardingID == id);
            if (boardingHouse == null)
            {
                return NotFound();
            }

            return View(boardingHouse);
        }

        // GET: BoardingHouses/Create
        public IActionResult Create()
        {
            ViewData["BedID"] = new SelectList(_context.Beds, "BedID", "BedNum");
            return View();
        }

        // POST: BoardingHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoardingID,Name,Description,Address,Owner,OwnerNumber,Price,BedID,HasActiveReservation")] BoardingHouse boardingHouse)
        {
            if (ModelState.IsValid)
            {
                boardingHouse.BoardingID = Guid.NewGuid();
                _context.Add(boardingHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BedID"] = new SelectList(_context.Beds, "BedID", "BedNum", boardingHouse.BedID);
            return View(boardingHouse);
        }

        // GET: BoardingHouses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.BoardingHouses == null)
            {
                return NotFound();
            }

            var boardingHouse = await _context.BoardingHouses.FindAsync(id);
            if (boardingHouse == null)
            {
                return NotFound();
            }
            ViewData["BedID"] = new SelectList(_context.Beds, "BedID", "BedNum", boardingHouse.BedID);
            return View(boardingHouse);
        }

        // POST: BoardingHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BoardingID,Name,Description,Address,Owner,OwnerNumber,Price,BedID,HasActiveReservation")] BoardingHouse boardingHouse)
        {
            if (id != boardingHouse.BoardingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardingHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardingHouseExists(boardingHouse.BoardingID))
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
            ViewData["BedID"] = new SelectList(_context.Beds, "BedID", "BedNum", boardingHouse.BedID);
            return View(boardingHouse);
        }

        // GET: BoardingHouses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.BoardingHouses == null)
            {
                return NotFound();
            }

            var boardingHouse = await _context.BoardingHouses
                .Include(b => b.Bed)
                .FirstOrDefaultAsync(m => m.BoardingID == id);
            if (boardingHouse == null)
            {
                return NotFound();
            }

            return View(boardingHouse);
        }

        // POST: BoardingHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.BoardingHouses == null)
            {
                return Problem("Entity set 'AppDBContext.BoardingHouses'  is null.");
            }
            var boardingHouse = await _context.BoardingHouses.FindAsync(id);
            if (boardingHouse != null)
            {
                _context.BoardingHouses.Remove(boardingHouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardingHouseExists(Guid id)
        {
          return (_context.BoardingHouses?.Any(e => e.BoardingID == id)).GetValueOrDefault();
        }
    }
}
