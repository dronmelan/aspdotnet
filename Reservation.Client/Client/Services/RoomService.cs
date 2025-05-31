using Reservation.Client.Client.Models;
using System.Net.Http.Json;

public class RoomService
{
    private readonly HttpClient _http;

    public RoomService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Room>>("api/Rooms");
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Room>($"api/Rooms/{id}");
    }

    public async Task AddAsync(Room room)
    {
        await _http.PostAsJsonAsync("api/Rooms", room);
    }

    public async Task UpdateAsync(int id, Room room)
    {
        await _http.PutAsJsonAsync($"api/Rooms/{id}", room);
    }

    public async Task DeleteAsync(int id)
    {
        await _http.DeleteAsync($"api/Rooms/{id}");
    }
}
