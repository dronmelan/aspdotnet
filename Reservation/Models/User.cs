namespace Reservation.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string PasswordHash { get; set; } = null!;

		public string? Phone { get; set; }

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}

}
