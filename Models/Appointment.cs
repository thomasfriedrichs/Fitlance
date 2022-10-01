using System.ComponentModel.DataAnnotations.Schema;

namespace Fitlance.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey("TrainerId")]
        public int TrainerId { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }

    }
}
