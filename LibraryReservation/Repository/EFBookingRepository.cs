using LibraryReservation.Data;
using LibraryReservation.Repository;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;

namespace LibraryReservation.Models
{
	public class EFBookingRepository : IBookingRepository
	{
		private BookingDbContext _context;
		public EFBookingRepository(BookingDbContext ctx)
		{
			_context = ctx;
		}
		public IQueryable<User> Users => _context.Users;
		public IQueryable<Room> Rooms => _context.Rooms;
		public IQueryable<Booking> Bookings => _context.Bookings;
		public IQueryable<Hotel> Hotels => _context.Hotels;

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class =>
        await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync<T>(int id) where T : class =>
            await _context.Set<T>().FindAsync(id);

        public async Task AddAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(int id) where T : class
        {
            var entity = await GetByIdAsync<T>(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
