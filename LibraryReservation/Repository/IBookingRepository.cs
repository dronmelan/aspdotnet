using LibraryReservation.Models;


namespace LibraryReservation.Repository

{
    public interface IBookingRepository
	{
		IQueryable<User> Users{ get; }
		IQueryable<Booking> Bookings{ get; }
		IQueryable<Room> Rooms{ get; }
		IQueryable<Hotel> Hotels{ get; }
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(int id) where T : class;

    }


}
