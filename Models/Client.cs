using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Fitlance.Models
{
    [Table("Clients")]
    public class Client
    {
        public int ID { get; set; }
        public DateTime? CreateTime { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? City { get; set; }
        public int? ZipCode { get; set; }
        public string? Bio { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}