using LibraryReservation.Data;
using LibraryReservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class RoomController : Controller
    {
        private readonly BookingDbContext _context;

        public RoomController(BookingDbContext context)
        {
            _context = context;
        }

        // READ: All Rooms - доступно всім
        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.Include(r => r.Hotel).ToListAsync();
            return View(rooms);
        }

        // READ: Room Details - доступно лише зареєстрованим користувачам
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var room = await _context.Rooms.Include(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null) return NotFound();

            return View(room);
        }

        // CREATE: Form - тільки для адмінів
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Hotels"] = new SelectList(_context.Hotels, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hotels"] = new SelectList(_context.Hotels, "Id", "Name", room.HotelId);
            return View(room);
        }

        // UPDATE: Form - тільки для адмінів
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return NotFound();

            ViewData["Hotels"] = new SelectList(_context.Hotels, "Id", "Name", room.HotelId);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            if (id != room.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hotels"] = new SelectList(_context.Hotels, "Id", "Name", room.HotelId);
            return View(room);
        }

        // DELETE: Confirmation Page - тільки для адмінів
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.Id == id);
            if (room == null) return NotFound();

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}