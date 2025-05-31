using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Reservation.Models;
using Reservation.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using LibraryReservation.Repository;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookingRepository repository;
        public int PageSize = 2;

        public HomeController(IBookingRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string? roomType, int page = 1)
        {
            if (roomType != null)
            {
                HttpContext.Session.SetString("SelectedRoomType", roomType);
            }
            else if (HttpContext.Session.Keys.Contains("SelectedRoomType"))
            {
                roomType = HttpContext.Session.GetString("SelectedRoomType");
            }

            var rooms = repository.Rooms
                .Where(r => roomType == null || r.RoomType == roomType)
                .OrderBy(r => r.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var totalItems = repository.Rooms
                .Where(r => roomType == null || r.RoomType == roomType)
                .Count();

            // Передаємо інформацію про роль користувача у ViewBag
            ViewBag.UserRole = User.IsInRole("Admin") ? "Admin" : User.IsInRole("User") ? "User" : "Guest";
            ViewBag.IsAuthenticated = User.Identity?.IsAuthenticated ?? false;

            return View(new RoomListViewModel
            {
                Rooms = rooms,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems
                },
                CurrentCategory = roomType
            });
        }
    }
}