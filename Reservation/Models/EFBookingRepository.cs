namespace Reservation.Models
{
	public class EFBookingRepository : IBookingRepository
	{
		private BookingDbContext context;
		public EFBookingRepository(BookingDbContext ctx)
		{
			context = ctx;
		}
		public IQueryable<User> Users => context.Users;
		public IQueryable<Room> Rooms => context.Rooms;
		public IQueryable<Booking> Bookings => context.Bookings;
		public IQueryable<Hotel> Hotels => context.Hotels;
	}
}
