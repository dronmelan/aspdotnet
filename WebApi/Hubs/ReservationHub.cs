using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ReservationHub : Hub
{
    public async Task SendReservationNotification(string message)
    {
        await Clients.All.SendAsync("ReceiveReservationNotification", message);
    }
}
