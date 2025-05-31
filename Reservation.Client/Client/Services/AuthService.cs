using Reservation.Client.Client.shared.Models;
using Reservation.Client.Shared.Models;
using Reservation.Client.Shared.Services;
using System.Net.Http.Json;

namespace Reservation.Client.Client.Services;
public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Register(RegisterDto registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerDto);
        response.EnsureSuccessStatusCode();
    }

    public async Task<JwtTokenResponse> Login(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginDto);
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException("Login failed");

        return await response.Content.ReadFromJsonAsync<JwtTokenResponse>();
    }

    public async Task Logout()
    {
        await Task.CompletedTask;
    }
}
