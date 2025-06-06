﻿using Microsoft.EntityFrameworkCore;
using LibraryReservation.Models;


namespace LibraryReservation.Data
{
    public class BookingDbContext : DbContext
	{
		public BookingDbContext (DbContextOptions <BookingDbContext> options) : base(options) { }
		public DbSet<User> Users => Set<User>();  
		public DbSet<Booking> Bookings => Set<Booking>();  
		public DbSet<Room> Rooms => Set<Room>();  
		public DbSet<Hotel> Hotels => Set<Hotel>();  
	}
}
