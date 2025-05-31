using Microsoft.AspNetCore.Mvc;
using LibraryReservation.Models;
using LibraryReservation.Repository;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IBookingRepository _repository;


        public RoomsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.Rooms.ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _repository.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomDto dto)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType,
                Capacity = dto.Capacity,
                PricePerNight = dto.PricePerNight,
                Description = dto.Description,
                IsAvailable = dto.IsAvailable
            };

            await _repository.AddAsync(room);
            return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Room room)
        {
            if (id != room.Id) return BadRequest();
            await _repository.UpdateAsync(room);
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
