using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Models;

namespace Reservation
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

			context.Database.Migrate();

            context.Hotels.AddRange(
				new Hotel {Name = "Grand Hotel", Address = "123 Main St" }
			);

            if (!context.Rooms.Any())
			{
				context.Rooms.AddRange(
					new Room
					{
						RoomNumber = "101",
						RoomType = "Standard",
						Capacity = 2,
						PricePerNight = 850,
						Description = "Стандартна кімната з ліжком",
						IsAvailable = true,
						HotelId = 1
                    },
					new Room
					{
						RoomNumber = "201",
						RoomType = "Deluxe",
						Capacity = 3,
						PricePerNight = 1300,
						Description = "Покращена кімната з великим ліжком і видом на сад",
						IsAvailable = true,
                        HotelId = 1
                    },
					new Room
					{
						RoomNumber = "301",
						RoomType = "Family",
						Capacity = 4,
						PricePerNight = 2100,
						Description = "Кімната з двома ліжками",
						IsAvailable = true,
                        HotelId = 1
                    },
                    new Room
                    {
                        RoomNumber = "102",
                        RoomType = "Standard",
                        Capacity = 1,
                        PricePerNight = 600,
                        Description = "Стандартна кімната з ліжком",
                        IsAvailable = true,
                        HotelId = 1
                    }
                );

				context.SaveChanges();
			}
		}
	}
}
