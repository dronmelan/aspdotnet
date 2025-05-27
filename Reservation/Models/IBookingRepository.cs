namespace Reservation.Models
{		
	public interface IBookingRepository
	{
		IQueryable<User> Users{ get; }
		IQueryable<Booking> Bookings{ get; }
		IQueryable<Room> Rooms{ get; }
		IQueryable<Hotel> Hotels{ get; }
	}

}
