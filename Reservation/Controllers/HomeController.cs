using Microsoft.AspNetCore.Mvc;

namespace Reservation.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index() => View();
	}
}
