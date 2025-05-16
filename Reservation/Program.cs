using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Reservation.Models;

namespace Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<BookingDbContext>(opts => {
				opts.UseSqlServer(builder.Configuration.GetConnectionString("RoomBookingConnection"));
			});

			builder.Services.AddScoped<IBookingRepository, EFBookingRepository>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.MapDefaultControllerRoute();

			SeedData.EnsurePopulated(app);

			app.Run();

        }
    }
}
