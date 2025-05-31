using LibraryReservation.Models;
using LibraryReservation.Repository;
using Microsoft.AspNetCore.Mvc;
using Reservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            var bookings = await _repository.GetAllAsync<Booking>();
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(int id)
        {
            var booking = await _repository.GetByIdAsync<Booking>(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            await _repository.AddAsync(booking);
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Booking booking)
        {
            if (id != booking.Id)
                return BadRequest("ID mismatch");

            var existing = await _repository.GetByIdAsync<Booking>(id);
            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(booking);
            return NoContent();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync<Booking>(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync<Booking>(id);
            return NoContent();
        }
    }
}
