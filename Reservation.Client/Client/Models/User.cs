using System.ComponentModel.DataAnnotations;

namespace Reservation.Client.Client.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string PasswordHash { get; set; } = "";

    public string Role { get; set; } = "";
}

