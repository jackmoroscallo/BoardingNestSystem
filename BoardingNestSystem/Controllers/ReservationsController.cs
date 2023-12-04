using BoardingNestSystem.Data;
using BoardingNestSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardingNestSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppDBContext _context;

        public ReservationsController(AppDBContext context)
        {
            _context = context;
        }
        // GET: Reservation/Details/5
        public async Task<IActionResult> CreateReservation(Guid? id)
        {
            if (id == null || _context.BoardingHouses == null)
            {
                return NotFound();
            }

            var boardingHouse = await _context.BoardingHouses
                .FirstOrDefaultAsync(m => m.BoardingID == id);
            if (boardingHouse == null)
            {
                return NotFound();
            }

            Reservation reservation = new Reservation();
            reservation.BoardingHouseID = id.Value;
            reservation.BoardingHouse = boardingHouse;


            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            if (reservation.BoardingHouseID == null || _context.BoardingHouses == null)
            {
                return NotFound();
            }

            var boardingHouse = await _context.BoardingHouses
                .FirstOrDefaultAsync(m => m.BoardingID == reservation.BoardingHouseID);
            if (boardingHouse == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                reservation.ReservationId = Guid.NewGuid();
                reservation.IsFinished = false;
                boardingHouse.HasActiveReservation = true;
                _context.Add(reservation);
                _context.Update(boardingHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexReservation));
            }
            return View(reservation);
        }

        // GET: RentInfos
        public async Task<IActionResult> IndexReservation()
     {
         var appDBContext = _context.Reservations.Include(r => r.BoardingHouse);
         return View(await appDBContext.ToListAsync());
     }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> DeleteReservation(Guid? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.BoardingHouseID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: BoardingHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'AppDBContext.BoardingHouses'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexReservation));
        }
    }
}
