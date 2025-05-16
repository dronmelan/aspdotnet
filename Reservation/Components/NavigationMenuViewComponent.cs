using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Reservation.Models;

namespace Reservation.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookingRepository repository;

        public NavigationMenuViewComponent(IBookingRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"]?.ToString();
            var categories = repository.Rooms
                .Select(r => r.RoomType)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
    