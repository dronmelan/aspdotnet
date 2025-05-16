using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Reservation.Models;
using Reservation.Models.ViewModels;


namespace SportsStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBookingRepository repository;
		public int PageSize = 3;

		public HomeController(IBookingRepository repo)
		{
			repository = repo;
		}

		public IActionResult Index(int page = 1)
		{
			var rooms = repository.Rooms
				.OrderBy(r => r.Id)
				.Skip((page - 1) * PageSize)
				.Take(PageSize);

			var viewModel = new RoomListViewModel
			{
				Rooms = rooms,
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = repository.Rooms.Count()
				}
			};

			return View(viewModel);
		}
	}
}
