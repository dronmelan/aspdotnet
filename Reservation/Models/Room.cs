using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Reservation.Models
{
	public class Room
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Введіть номер кімнати")]
        public string RoomNumber { get; set; } = null!;

        [Required(ErrorMessage = "Введіть тип кімнати")]
        public string RoomType { get; set; } = null!;

        [Range(1, 10, ErrorMessage = "Місткість має бути від 1 до 10")]
        public int Capacity { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Ціна повинна бути додатньою")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal PricePerNight { get; set; }

		public string? Description { get; set; }

		public bool IsAvailable { get; set; }

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
    }

}
