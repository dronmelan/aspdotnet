using System.ComponentModel.DataAnnotations;

namespace LibraryReservation.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

}
