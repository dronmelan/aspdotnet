using System.ComponentModel.DataAnnotations;

namespace LibraryReservation.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; } = null!;

		public string? Phone { get; set; }

        [Required]
        public string Role { get; set; } = "User";
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

	}

}
