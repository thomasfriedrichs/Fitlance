using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;


namespace Fitlance.Models;

[Table("Trainers")]
public class Trainer
{
    [Column("TrainerId")]
    public int Id { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
    public string? City { get; set; }
    public int? Zipcode { get; set; }
    public string? Bio { get; set; }
    public List<Appointment>? Appointments { get; set; }
}
