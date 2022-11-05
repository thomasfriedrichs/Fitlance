using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Fitlance.Models;

[Table("Clients")]
public class Client
{
    [Column("ClientId")]
    public int Id { get; set; }
    //[EmailAddress]
    //[Required(ErrorMessage = "Email is required")]
    //public IdentityUser? Email { get; set; }
    //[Required(ErrorMessage = "Password is required")]
    //public string? Password { get; set; }
    public DateTime? CreateTime { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
    public string? City { get; set; }
    public int? ZipCode { get; set; }
    public string? Bio { get; set; }
    public List<Appointment>? Appointments { get; set; }
}