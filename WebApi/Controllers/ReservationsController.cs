using LibraryReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

public class ReservationsController : Controller
{
    private readonly IHubContext<ReservationHub> _hubContext;

    public ReservationsController(IHubContext<ReservationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Booking model)
    {
        if (ModelState.IsValid)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveReservationNotification",
                $"Нова бронь: з {model.CheckInDate} по {model.CheckOutDate}");

            return RedirectToAction("Index");
        }
        return View(model);
    }
}
