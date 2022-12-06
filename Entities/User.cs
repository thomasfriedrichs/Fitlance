using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Fitlance.Entities;

[Table("Users")]
public class User : IdentityUser
{
    [PersonalData]
    public DateTime? CreateTime { get; set; }
    [PersonalData]
    public string? FirstName { get; set; }
    [PersonalData]
    public string? LastName { get; set; }
    [PersonalData]
    public string? City { get; set; }
    [PersonalData]
    public int? ZipCode { get; set; }
    [PersonalData]
    public string? Bio { get; set; }
    [PersonalData]
    public List<Appointment>? Appointments { get; set; }
}