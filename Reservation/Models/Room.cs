using System.ComponentModel.DataAnnotations.Schema;


namespace Reservation.Models
{
	public class Room
	{
		public int Id { get; set; }

		public string RoomNumber { get; set; } = null!;

		public string RoomType { get; set; } = null!;

		public int Capacity { get; set; }

		public decimal PricePerNight { get; set; }

		public string? Description { get; set; }

		public bool IsAvailable { get; set; }

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}

}
