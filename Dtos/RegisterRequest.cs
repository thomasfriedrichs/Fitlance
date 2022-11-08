using System.ComponentModel.DataAnnotations;

namespace Fitlance.Dtos;

public class RegisterRequest
{
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Role { get; set; }
}