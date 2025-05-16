namespace Reservation.Models
{
	public class Booking
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public int RoomId { get; set; }

		public DateTime CheckInDate { get; set; }

		public DateTime CheckOutDate { get; set; }

		public decimal TotalAmount { get; set; }

		public string Status { get; set; } = "pending";

		public DateTime BookedAt { get; set; } = DateTime.Now;

		public User User { get; set; } = null!;

		public Room Room { get; set; } = null!;
	}

}
