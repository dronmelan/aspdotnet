using Microsoft.AspNetCore.Mvc;
using LibraryReservation.Models;
using LibraryReservation.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public HotelsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.Hotels.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _repository.Hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Hotel hotel)
        {
            await _repository.AddAsync(hotel);
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.Id) return BadRequest();
            await _repository.UpdateAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync<Booking>(id);
            return NoContent();
        }
    }
}
