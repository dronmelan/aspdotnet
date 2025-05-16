namespace Reservation.Models
{		
	public interface IBookingRepository
	{
		IQueryable<Users> Users{ get; }
	}

}
