using System.ComponentModel.DataAnnotations.Schema;

namespace Fitlance.Entities;

[Table("Appointments")]
public class Appointment
{
    [Column("AppointmentId")]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public string? ClientId { get; set; }
    [ForeignKey("UserId")]
    public string? TrainerId { get; set; }
    public string? Address { get; set; }
    public string? CreateTime { get; set; }
    public string? AppointmentDate { get; set; }
    public bool IsActive { get; set; }
}