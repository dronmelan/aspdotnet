using Reservation.Client.Client.Models;
using System.Net.Http.Json;

public class UserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }
    public async Task AddUserAsync(User user)
    {
        await _http.PostAsJsonAsync("api/users", user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _http.DeleteAsync($"api/users/{id}");
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        await _http.PutAsJsonAsync($"api/users/{id}", user);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _http.GetFromJsonAsync<List<User>>("api/users");
    }
}
