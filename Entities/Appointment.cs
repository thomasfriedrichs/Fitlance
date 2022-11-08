using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitlance.Entities;

[Table("Appointments")]
public class Appointment
{
    [Column("AppointmentId")]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public string? UserId { get; set; }
    public string? Adress { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime AppointmentDate { get; set; }
    public bool IsActive { get; set; }

}
