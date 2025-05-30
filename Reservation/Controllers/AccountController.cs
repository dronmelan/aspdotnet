using Microsoft.AspNetCore.Mvc;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User userModel)
        {
            return View();

        }

    }
}
